ASSEMBLY_DIR=$(top_builddir)/build/AddIns/MonoDevelop.Debugger.Soft
ASSEMBLY=$(ASSEMBLY_DIR)/Mono.Debugger.Soft.dll

REFS =  \
	-r:System \
	-r:System.Core

DEPS = ../../build/bin/Mono.Cecil.dll

SIGNING_KEY=$(srcdir)/mono.snk

FILES =  \
	Locale.cs \
	Mono.Debugger.Soft/AbsentInformationException.cs \
	Mono.Debugger.Soft/AppDomainCreateEvent.cs \
	Mono.Debugger.Soft/AppDomainMirror.cs \
	Mono.Debugger.Soft/AppDomainUnloadEvent.cs \
	Mono.Debugger.Soft/ArrayMirror.cs \
	Mono.Debugger.Soft/AssemblyLoadEvent.cs \
	Mono.Debugger.Soft/AssemblyLoadEventRequest.cs \
	Mono.Debugger.Soft/AssemblyMirror.cs \
	Mono.Debugger.Soft/AssemblyUnloadEvent.cs \
	Mono.Debugger.Soft/BreakpointEvent.cs \
	Mono.Debugger.Soft/BreakpointEventRequest.cs \
	Mono.Debugger.Soft/Connection.cs \
	Mono.Debugger.Soft/CustomAttributeDataMirror.cs \
	Mono.Debugger.Soft/CustomAttributeNamedArgumentMirror.cs \
	Mono.Debugger.Soft/CustomAttributeTypedArgumentMirror.cs \
	Mono.Debugger.Soft/DataConverter.cs \
	Mono.Debugger.Soft/EnumMirror.cs \
	Mono.Debugger.Soft/Event.cs \
	Mono.Debugger.Soft/EventQueueImpl.cs \
	Mono.Debugger.Soft/EventRequest.cs \
	Mono.Debugger.Soft/EventSet.cs \
	Mono.Debugger.Soft/EventType.cs \
	Mono.Debugger.Soft/ExceptionEvent.cs \
	Mono.Debugger.Soft/ExceptionEventRequest.cs \
	Mono.Debugger.Soft/FieldInfoMirror.cs \
	Mono.Debugger.Soft/IInvokeAsyncResult.cs \
	Mono.Debugger.Soft/ILInstruction.cs \
	Mono.Debugger.Soft/IMirror.cs \
	Mono.Debugger.Soft/InterfaceMappingMirror.cs \
	Mono.Debugger.Soft/InvalidStackFrameException.cs \
	Mono.Debugger.Soft/InvocationException.cs \
	Mono.Debugger.Soft/InvokeOptions.cs \
	Mono.Debugger.Soft/ITargetProcess.cs \
	Mono.Debugger.Soft/LocalVariable.cs \
	Mono.Debugger.Soft/Location.cs \
	Mono.Debugger.Soft/MethodBodyMirror.cs \
	Mono.Debugger.Soft/MethodEntryEvent.cs \
	Mono.Debugger.Soft/MethodEntryEventRequest.cs \
	Mono.Debugger.Soft/MethodExitEvent.cs \
	Mono.Debugger.Soft/MethodExitEventRequest.cs \
	Mono.Debugger.Soft/MethodMirror.cs \
	Mono.Debugger.Soft/Mirror.cs \
	Mono.Debugger.Soft/ModuleMirror.cs \
	Mono.Debugger.Soft/ObjectCollectedException.cs \
	Mono.Debugger.Soft/ObjectMirror.cs \
	Mono.Debugger.Soft/ParameterInfoMirror.cs \
	Mono.Debugger.Soft/PrimitiveValue.cs \
	Mono.Debugger.Soft/PropertyInfoMirror.cs \
	Mono.Debugger.Soft/StackFrame.cs \
	Mono.Debugger.Soft/StepEvent.cs \
	Mono.Debugger.Soft/StepEventRequest.cs \
	Mono.Debugger.Soft/StringMirror.cs \
	Mono.Debugger.Soft/StructMirror.cs \
	Mono.Debugger.Soft/SuspendPolicy.cs \
	Mono.Debugger.Soft/ThreadDeathEvent.cs \
	Mono.Debugger.Soft/ThreadMirror.cs \
	Mono.Debugger.Soft/ThreadStartEvent.cs \
	Mono.Debugger.Soft/TypeLoadEvent.cs \
	Mono.Debugger.Soft/TypeLoadEventRequest.cs \
	Mono.Debugger.Soft/TypeMirror.cs \
	Mono.Debugger.Soft/UserBreakEvent.cs \
	Mono.Debugger.Soft/UserLogEvent.cs \
	Mono.Debugger.Soft/Value.cs \
	Mono.Debugger.Soft/VirtualMachine.cs \
	Mono.Debugger.Soft/VirtualMachineManager.cs \
	Mono.Debugger.Soft/VMDeathEvent.cs \
	Mono.Debugger.Soft/VMDisconnectedException.cs \
	Mono.Debugger.Soft/VMDisconnectEvent.cs \
	Mono.Debugger.Soft/VMMismatchException.cs \
	Mono.Debugger.Soft/VMStartEvent.cs

all: $(ASSEMBLY) $(ASSEMBLY).mdb

$(ASSEMBLY): $(build_sources) $(DEPS)
	mkdir -p "$(ASSEMBLY_DIR)"
	$(CSC) $(CSC_FLAGS) /keyfile:"$(SIGNING_KEY)" /define:MONO_DATACONVERTER_STATIC_METHODS /debug /unsafe /out:$@ /target:library $(REFS) $(build_deps) $(build_sources)

$(ASSEMBLY).mdb: $(ASSEMBLY)

assemblydir = $(MD_ADDIN_DIR)/MonoDevelop.Debugger.Soft
assembly_DATA = $(ASSEMBLY) $(ASSEMBLY).mdb

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb

EXTRA_DIST = $(FILES) $(SIGNING_KEY) mono-git-revision

include $(top_srcdir)/Makefile.include
