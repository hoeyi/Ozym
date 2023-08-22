REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define the test project folder
set project=%1

REM Define the guid to build from
set guid=%2

REM Run the report generator using the given parameter
reportgenerator ^
	-reports:"%project%\\TestResults\\%guid%\\coverage.cobertura.xml" ^
	-targetdir:"%project%\\TestResults\\%guid%\\coverage_report" ^
	-reporttypes:Html