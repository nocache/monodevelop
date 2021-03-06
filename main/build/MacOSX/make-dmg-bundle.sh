#!/bin/bash

# Shamelessly lifted from Banshee's build process
 	
pushd $(dirname $0) &>/dev/null

DMG_APP=MonoDevelop.app

if test ! -e "$DMG_APP" ; then
	echo "Missing MonoDevelop.app"
	exit 1
fi

NAME=`grep -A1 CFBundleName "$DMG_APP/Contents/Info.plist"  | grep string | sed -e 's/.*<string>//' -e 's,</string>,,'`
VERSION=`grep -A1 CFBundleVersion "$DMG_APP/Contents/Info.plist"  | grep string | sed -e 's/.*<string>//' -e 's,</string>,,'`

#if we use the version in the volume name, Finder can't find the background image
#because the DS_Store depends on the volume name, and we aren't currently able
#to alter it programmatically
VOLUME_NAME="$NAME"

echo "Building bundle for $NAME $VERSION..."

DMG_FILE="$NAME-$VERSION.dmg"
MOUNT_POINT="$VOLUME_NAME.mounted"

rm -f "$DMG_FILE"
rm -f "$DMG_FILE.master"
 	
# Compute an approximated image size in MB, and bloat by 1MB
image_size=$(du -ck "$DMG_APP" | tail -n1 | cut -f1)
image_size=$((($image_size + 2000) / 1000))

echo "Creating disk image (${image_size}MB)..."
hdiutil create "$DMG_FILE" -megabytes $image_size -volname "$VOLUME_NAME" -fs HFS+ -quiet || exit $?

echo "Attaching to disk image..."
hdiutil attach "$DMG_FILE" -readwrite -noautoopen -mountpoint "$MOUNT_POINT" -quiet || exit $?

echo "Populating image..."

mv "$DMG_APP" "$MOUNT_POINT"

# This won't result in any deletions 
#find "$MOUNT_POINT" -type d -iregex '.*\.svn$' &>/dev/null | xargs rm -rf

pushd "$MOUNT_POINT" &>/dev/null
ln -s /Applications Applications
popd &>/dev/null

mkdir -p "$MOUNT_POINT/.background"
mono render.exe "$NAME $VERSION"
mv dmg-bg-with-version.png "$MOUNT_POINT/.background/dmg-bg.png"
cp DS_Store "$MOUNT_POINT/.DS_Store"
cp VolumeIcon.icns "$MOUNT_POINT/.VolumeIcon.icns"
SetFile -c icnC "$MOUNT_POINT/.VolumeIcon.icns"
SetFile -a C "$MOUNT_POINT"

echo "Detaching from disk image..."
hdiutil detach "$MOUNT_POINT" -quiet || exit $?

mv "$DMG_FILE" "$DMG_FILE.master"

echo "Creating distributable image..."
hdiutil convert -quiet -format UDBZ -o "$DMG_FILE" "$DMG_FILE.master" || exit $?

echo "Built disk image $DMG_FILE"

if [ ! "x$1" = "x-m" ]; then
rm "$DMG_FILE.master"
fi

rm -rf "$MOUNT_POINT"

echo "Done."

popd &>/dev/null 
