#!/bin/bash

# Check that the CONFIGURATION variable is set, else exit.
if [ -v ${CONFIGURATION}+x} ] || [ -z "CONFIGURATION" ]
then
      echo "Variable \$CONFIGURATION is not set."
      exit 1
fi

# Get the last commit hash and pass it to the docker-compose build command
export COMMIT_TAG=$(git log -1 --format=%h)
docker compose --profile release build --build-arg COMMIT_TAG=$COMMIT_TAG --no-cache