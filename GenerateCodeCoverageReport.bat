REM Check for expected positional parameter and redirect as needed.
if "%1"=="" goto missingparameter

REM Define the guid to build from
set guid=%1

REM Run the report generator using the given parameter
reportgenerator ^
	-reports:"NjordinSight.DAL.Test\\TestResults\\%guid%\\coverage.cobertura.xml" ^
	-targetdir:"NjordinSight.DAL.Test\\TestResults\\%guid%\\coverage_report" ^
	-reporttypes:Html