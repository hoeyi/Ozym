#!/bin/bash

# Prompt the user for values to assign to $MSSQL_SA_PASSWORD and $OZYM_APP_PASSWORD variables.
read -s -p "Enter the password for the 'sa' SQL server user: " MSSQL_SA_PASSWORD
echo
read -s -p "Enter the password for the 'OzymAppUser' SQL server user: " OZYM_APP_PASSWORD

# Get the last commit hash and pass it to the docker-compose build command
export COMMIT_TAG=$(git log -1 --format=%h)
docker compose build --build-arg COMMIT_TAG=$COMMIT_TAG