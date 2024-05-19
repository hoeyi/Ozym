#!/bin/bash

# Get the last commit hash and pass it to the docker-compose build command
export COMMIT_TAG=$(git log -1 --format=%h)
docker compose build --build-arg COMMIT_TAG=$COMMIT_TAG