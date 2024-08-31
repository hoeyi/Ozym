#!/bin/bash

# Check if the MSSQL_SA_PASSWORD variable is set and not empty.
# If it's not set or is empty, print an error message and exit the script with a status of 1.
if [ -v ${MSSQL_SA_PASSWORD+x} ] || [ -z "$MSSQL_SA_PASSWORD" ]
then
      echo "Variable \$MSSQL_SA_PASSWORD is not set."
      exit 1
fi

# Repeast the same check for the OZYM_APP_PASSWORD variable.
if [ -v ${MSSQL_SA_PASSWORD}+x} ] || [ -z "$OZYM_APP_PASSWORD" ]
then
      echo "Variable \$OZYM_APP_PASSWORD is not set."
      exit 1
fi

# Get the last commit hash and pass it to the docker-compose build command
export COMMIT_TAG=$(git log -1 --format=%h)
docker compose build --build-arg COMMIT_TAG=$COMMIT_TAG