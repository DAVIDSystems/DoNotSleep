Name "DoNotSleep"
OutFile "SetupDoNotSleep.exe"
SetCompressor lzma
InstallDir "C:\Program Files (x86)\DoNotSleep"
LoadLanguageFile "${NSISDIR}\Contrib\Language files\German.nlf"
LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
!ifndef VERSION
  !define VERSION "1.0.1910.1"
!endif
 
VIProductVersion "${VERSION}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductName" "DoNotSleep"
VIAddVersionKey /LANG=${LANG_ENGLISH} "Comments" "DoNot Sleep for Windows - Utility to prevent computer to sleep"
VIAddVersionKey /LANG=${LANG_ENGLISH} "CompanyName" "DAVID Systems GmbH"
VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalTrademarks" "DigaSystem DoNotSleep-Setup"
VIAddVersionKey /LANG=${LANG_ENGLISH} "LegalCopyright" "© DAVID Systems GmbH"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileDescription" "DigaSystem DoNotSleep-Setup"
VIAddVersionKey /LANG=${LANG_ENGLISH} "FileVersion" "${VERSION}"
VIAddVersionKey /LANG=${LANG_ENGLISH} "ProductVersion" "${VERSION}"
 
!include Library.nsh
Page directory
Page instfiles
UninstPage uninstConfirm
UninstPage instfiles
 
ShowInstDetails show
 
Section "Install"
  SetOutPath $INSTDIR
  File /r "G:\Daten\Projects\Git\c#\Donotsleep\donotsleep\Setup\Release\*.*"
  CreateShortCut "$DESKTOP\DoNotSleep.lnk" "$OUTDIR\DoNotSleep.exe"
  writeUninstaller $INSTDIR\uninstaller.exe
SectionEnd
 
Section "Uninstall"
  delete $INSTDIR\uninstaller.exe
  RMDir /r /REBOOTOK $INSTDIR
SectionEnd