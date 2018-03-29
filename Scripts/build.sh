#! /bin/sh

project="Super Mario Clone"

echo "Attempting to build $project for Windows"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath "$(pwd)/${UNITYCI_PROJECT_NAME}" \
  -buildWindowsPlayer "$(pwd)/Build/windows/${UNITYCI_PROJECT_NAME}.exe" \
  -quit

echo "Attempting to build $project for OS X"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath "$(pwd)/${UNITYCI_PROJECT_NAME}" \
  -buildOSXUniversalPlayer "$(pwd)/Build/osx/${UNITYCI_PROJECT_NAME}.app" \
  -quit

echo "Attempting to build $project for Linux"
/Applications/Unity/Unity.app/Contents/MacOS/Unity \
  -batchmode \
  -nographics \
  -silent-crashes \
  -logFile $(pwd)/unity.log \
  -projectPath "$(pwd)/${UNITYCI_PROJECT_NAME}" \
  -buildLinuxUniversalPlayer "$(pwd)/Build/linux/${UNITYCI_PROJECT_NAME}.exe" \
  -quit

echo 'Logs from build'
cat $(pwd)/unity.log


echo 'Attempting to zip builds'
zip -r $(pwd)/Build/linux.zip $(pwd)/Build/linux/
zip -r $(pwd)/Build/mac.zip $(pwd)/Build/osx/
zip -r $(pwd)/Build/windows.zip $(pwd)/Build/windows/