cd ../
dotnet test 'Ozym.sln' --collect:'XPlat Code Coverage' --verbosity quiet

export API_TEST_GUID=$(ls -lt Ozym.API.Test/TestResults | grep ^d | head -1 | awk '{print $9}')
export DAL_TEST_GUID=$(ls -lt Ozym.DAL.Test/TestResults | grep ^d | head -1 | awk '{print $9}')

echo "API test results id: $API_TEST_GUID"
echo -e "DAL test results id: $DAL_TEST_GUID\n"

# Prompt the user to confirm before proceeding.
read -p "Press (y) to generate reports or any other key to cancel: " REPLY
if [ "$REPLY" != "y" ]; then
    echo "Report generation cancelled."
    exit 0
fi

# Generate code coverage report and save within test run folder.
reportgenerator \
    -reports:"Ozym.API.Test/TestResults/$API_TEST_GUID/coverage.cobertura.xml" \
    -targetdir:"../../ozym-test-results/coverage-report-api-$API_TEST_GUID" \
    -reporttypes:Html \
    -assemblyFilters:-Ozym.DAL\;-Ozym.EntityModel \
    -filefilters:-*.Designer.cs

reportgenerator \
    -reports:"Ozym.DAL.Test/TestResults/$DAL_TEST_GUID/coverage.cobertura.xml" \
    -targetdir:"../../ozym-test-results/coverage-report-dal-$DAL_TEST_GUID" \
    -reporttypes:Html \
    -assemblyFilters:-Ozym.EntityModel \
    -filefilters:-*.Designer.cs