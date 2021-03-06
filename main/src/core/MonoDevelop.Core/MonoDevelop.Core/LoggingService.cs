// 
// LoggingService.cs
// 
// Author:
//   Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MonoDevelop.Core.Logging;

namespace MonoDevelop.Core
{
	
	public static class LoggingService
	{
		static List<ILogger> loggers = new List<ILogger> ();
		static RemoteLogger remoteLogger;
		static int logId = 0;
		
		static LoggingService ()
		{
			ConsoleLogger consoleLogger = new ConsoleLogger ();
			loggers.Add (consoleLogger);
			loggers.Add (new InstrumentationLogger ());
			
			string consoleLogLevelEnv = Environment.GetEnvironmentVariable ("MONODEVELOP_CONSOLE_LOG_LEVEL");
			if (!string.IsNullOrEmpty (consoleLogLevelEnv)) {
				try {
					consoleLogger.EnabledLevel = (EnabledLoggingLevel) Enum.Parse (typeof (EnabledLoggingLevel), consoleLogLevelEnv, true);
				} catch {}
			}
			
			string consoleLogUseColourEnv = Environment.GetEnvironmentVariable ("MONODEVELOP_CONSOLE_LOG_USE_COLOUR");
			if (!string.IsNullOrEmpty (consoleLogUseColourEnv) && consoleLogUseColourEnv.ToLower () == "false") {
				consoleLogger.UseColour = false;
			} else {
				consoleLogger.UseColour = true;
			}
			
			string logFileEnv = Environment.GetEnvironmentVariable ("MONODEVELOP_LOG_FILE");
			if (!string.IsNullOrEmpty (logFileEnv)) {
				try {
					FileLogger fileLogger = new FileLogger (logFileEnv);
					loggers.Add (fileLogger);
					string logFileLevelEnv = Environment.GetEnvironmentVariable ("MONODEVELOP_FILE_LOG_LEVEL");
					fileLogger.EnabledLevel = (EnabledLoggingLevel) Enum.Parse (typeof (EnabledLoggingLevel), logFileLevelEnv, true);
				} catch (Exception e) {
					LogError (e.ToString ());
				}
			}
		}

		static FilePath GenericLogFile {
			get { return "MonoDevelop.log"; }
		}

		static string FormattedGenericLogFile (int value)
		{
			return string.Format ("MonoDevelop-{0}.log", value);
		}

		static string FormattedUniqueFileName (DateTime timestamp)
		{
			return string.Format ("MonoDevelop.{0}.log", timestamp.ToString ("yyyy-MM-dd__HH-mm-ss"));
		}
		
		public static int LogId {
			get { return logId; }
		}
		
		public static void Initialize (bool redirectOutput)
		{
			PurgeOldLogs ();
			
			if (Platform.IsWindows || redirectOutput)
				RedirectOutputToLogFile ();
		}
		
		static void PurgeOldLogs ()
		{
			// Delete all logs older than a week
			if (!Directory.Exists (UserProfile.Current.LogDir))
				return;

			var files = Directory.EnumerateFiles (UserProfile.Current.LogDir, "*.log")
				.Select (f => new FileInfo (f))
				.Where (f => f.CreationTimeUtc < DateTime.UtcNow.Subtract (TimeSpan.FromDays (7)));

			foreach (var v in files)
				v.Delete ();
		}
		
		static void RedirectOutputToLogFile ()
		{
			FilePath logDir = UserProfile.Current.LogDir;
			if (!Directory.Exists (logDir))
				Directory.CreateDirectory (logDir);
		
			try {
				if (Platform.IsWindows) {
					//TODO: redirect the file descriptors on Windows, just plugging in a textwriter won't get everything
					RedirectOutputToFileWindows (logDir);
				} else {
					RedirectOutputToFileUnix (logDir);
				}
			} catch {
			}
		}

		static IEnumerable<string> GetGenericLogFiles (FilePath logDirectory)
		{
			// Look for MonoDevelop.log and also MonoDevelop-XXX.log
			string additonalGenericLogs = Path.GetFileNameWithoutExtension (GenericLogFile) + "-";
			return Directory.GetFiles (logDirectory)
				.Where (f => f == GenericLogFile || f.StartsWith (additonalGenericLogs))
				.OrderBy (f => f);
		}

		static void RedirectOutputToFileWindows (FilePath logDirectory)
		{
			// First try to move any generic MonoDevelop.log files to a timestamped filename
			foreach (var path in GetGenericLogFiles (logDirectory)) {
				try {
					var creationTime = File.GetCreationTime (path);
					var destination = logDirectory.Combine (FormattedUniqueFileName (creationTime));
					FileService.RenameFile (path, destination);
				} catch {}
			}

			// Find the first free filename, try MonoDevelop.log first and then MonoDevelop-{0}.log
			string logName = GenericLogFile;
			FileStream stream = null;
			
			do {
				try {
					stream = File.Open (logDirectory.Combine (logName), FileMode.CreateNew, FileAccess.Write);
					break;
				} catch (IOException) {
					// the file already exists...
				}
				
				logName = FormattedGenericLogFile (++logId);
			} while (true);
			
			var logFile = new StreamWriter (stream) { AutoFlush = true };
			
			Console.SetOut (logFile);
			Console.SetError (logFile);
		}
		
		static void RedirectOutputToFileUnix (FilePath logDirectory)
		{
			const int STDOUT_FILENO = 1;
			const int STDERR_FILENO = 2;
			
			Mono.Unix.Native.OpenFlags flags = Mono.Unix.Native.OpenFlags.O_WRONLY
				| Mono.Unix.Native.OpenFlags.O_CREAT | Mono.Unix.Native.OpenFlags.O_TRUNC;
			var mode = Mono.Unix.Native.FilePermissions.S_IFREG
				| Mono.Unix.Native.FilePermissions.S_IRUSR | Mono.Unix.Native.FilePermissions.S_IWUSR
				| Mono.Unix.Native.FilePermissions.S_IRGRP | Mono.Unix.Native.FilePermissions.S_IWGRP;
			
			var file = logDirectory.Combine (FormattedUniqueFileName (DateTime.Now));
			int fd = Mono.Unix.Native.Syscall.open (file, flags, mode);
			if (fd < 0)
				//error
				return;
			try {
				int res = Mono.Unix.Native.Syscall.dup2 (fd, STDOUT_FILENO);
				if (res < 0)
					//error
					return;
				
				res = Mono.Unix.Native.Syscall.dup2 (fd, STDERR_FILENO);
				if (res < 0)
					//error
					return;

				var genericLog = logDirectory.Combine (GenericLogFile);
				File.Delete (genericLog);
				Mono.Unix.Native.Syscall.symlink (file, genericLog);
			} finally {
				Mono.Unix.Native.Syscall.close (fd);
			}
		}
		
		internal static RemoteLogger RemoteLogger {
			get {
				if (remoteLogger == null)
					remoteLogger = new RemoteLogger ();
				return remoteLogger;
			}
		}
		
#region the core service
		
		public static bool IsLevelEnabled (LogLevel level)
		{
			EnabledLoggingLevel l = (EnabledLoggingLevel) level;
			foreach (ILogger logger in loggers)
				if ((logger.EnabledLevel & l) == l)
					return true;
			return false;
		}
		
		public static void Log (LogLevel level, string message)
		{
			EnabledLoggingLevel l = (EnabledLoggingLevel) level;
			foreach (ILogger logger in loggers)
				if ((logger.EnabledLevel & l) == l)
					logger.Log (level, message);
		}
		
#endregion
		
#region methods to access/add/remove loggers -- this service is essentially a log message broadcaster
		
		public static ILogger GetLogger (string name)
		{
			foreach (ILogger logger in loggers)
				if (logger.Name == name)
					return logger;
			return null;
		}
		
		public static void AddLogger (ILogger logger)
		{
			if (GetLogger (logger.Name) != null)
				throw new Exception ("There is already a logger with the name '" + logger.Name + "'");
			loggers.Add (logger);
		}
		
		public static void RemoveLogger (string name)
		{
			ILogger logger = GetLogger (name);
			if (logger == null)
				throw new Exception ("There is no logger registered with the name '" + name + "'");
			loggers.Remove (logger);
		}
		
#endregion
		
#region convenience methods (string message)
		
		public static void LogDebug (string message)
		{
			Log (LogLevel.Debug, message);
		}
		
		public static void LogInfo (string message)
		{
			Log (LogLevel.Info, message);
		}
		
		public static void LogWarning (string message)
		{
			Log (LogLevel.Warn, message);
		}
		
		public static void LogError (string message)
		{
			Log (LogLevel.Error, message);
		}
		
		public static void LogFatalError (string message)
		{
			Log (LogLevel.Fatal, message);
		}
		
#endregion
		
#region convenience methods (string messageFormat, params object[] args)
		
		public static void LogDebug (string messageFormat, params object[] args)
		{
			Log (LogLevel.Debug, string.Format (messageFormat, args));
		}
		
		public static void LogInfo (string messageFormat, params object[] args)
		{
			Log (LogLevel.Info, string.Format (messageFormat, args));
		}
		
		public static void LogWarning (string messageFormat, params object[] args)
		{
			Log (LogLevel.Warn, string.Format (messageFormat, args));
		}
		
		public static void LogError (string messageFormat, params object[] args)
		{
			Log (LogLevel.Error, string.Format (messageFormat, args));
		}
		
		public static void LogFatalError (string messageFormat, params object[] args)
		{
			Log (LogLevel.Fatal, string.Format (messageFormat, args));
		}
		
#endregion
		
#region convenience methods (string message, Exception ex)
		
		public static void LogDebug (string message, Exception ex)
		{
			Log (LogLevel.Debug, message + System.Environment.NewLine + (ex != null? ex.ToString () : string.Empty));
		}
		
		public static void LogInfo (string message, Exception ex)
		{
			Log (LogLevel.Info, message + System.Environment.NewLine + (ex != null? ex.ToString () : string.Empty));
		}
		
		public static void LogWarning (string message, Exception ex)
		{
			Log (LogLevel.Warn, message + System.Environment.NewLine + (ex != null? ex.ToString () : string.Empty));
		}
		
		public static void LogError (string message, Exception ex)
		{
			Log (LogLevel.Error, message + System.Environment.NewLine + (ex != null? ex.ToString () : string.Empty));
		}
		
		public static void LogFatalError (string message, Exception ex)
		{
			Log (LogLevel.Fatal, message + System.Environment.NewLine + (ex != null? ex.ToString () : string.Empty));
		}
		
#endregion
	}
}
