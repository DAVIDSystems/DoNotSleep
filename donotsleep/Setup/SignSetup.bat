C:
cd C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\
signtool.exe sign /f G:\Daten\Projects\Setup\CodeSigning\DavidSystemsCodeSigning.pfx /p DaViD2016_SignMe! /t http://timestamp.verisign.com/scripts/timstamp.dll %1
