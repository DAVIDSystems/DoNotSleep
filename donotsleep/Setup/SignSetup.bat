C:
cd C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\
signtool.exe sign /f G:\Data\Projects\git\CodeSigning\DavidSystemsCodeSigning.pfx /p DaViD2016_SignMe! /t http://timestamp.verisign.com/scripts/timstamp.dll %1
timeout /T 10