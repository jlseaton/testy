REM Makes a backup of all source code, ignoring output directories, multiple databases, log files, and test results

"c:\program Files\winrar\winrar.exe" a -r -u -x*\bin -x*\bin\* -x*\obj -x*\obj\* -x*\CVS\* -x*\CVS -x*\packages -x*\packages\* -x*\testresults -x*\testresults\* -x*\App_Data\* -x*\Publish -x*\Publish\* -x*\Logs\*.log Testy2Src.zip *.*
