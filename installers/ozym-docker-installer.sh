#!/bin/bash
# Installation script for the Docker build of Ozym.
echo -e \
'Welcome to the Ozym Docker installer!\n
This script starts a Docker network composed of Blazor, REST API, and database 
containers. You will be prompted for initial passwords for both the SQL Server [sa] account, 
and the web/api database login/user [OzymAppUser]. These passwords will be 
set as environment variables in their respective containers.\n'

# Prompt the user on whether to proceed with installation.
CONTINUE_INSTALL=''

echo $CONTINUE_INSTALL

while [ "$CONTINUE_INSTALL" = '' ]
do 
    read -p 'Continue with installation? (y/N): ' USER_INPUT 
    echo
    if [ "${USER_INPUT^^}" = "Y" ] || [ "${USER_INPUT^^}" = "N" ]; then
        CONTINUE_INSTALL="${USER_INPUT^^}"
    fi
done

if [ "$CONTINUE_INSTALL" = "N" ]; then
    echo -e '\nInstallation cancelled.'
    exit
else
    echo -e "\nStarting installation...\n"
    read -p 'Enter password for SQL [sa] user: ' -s MSSQL_SA_PASSWORD
    echo
    read -p 'Enter password for Ozym web app user: ' -s OZYM_APP_PASSWORD
    echo 

    export MSSQL_SA_PASSWORD="$MSSQL_SA_PASSWORD"
    export OZYM_APP_PASSWORD="$OZYM_APP_PASSWORD"

    echo 'Starting Docker network...'
    docker compose up -d

    sleep 10

    echo 'Setting up initial database login/user configuration...'
    read -p 'Press any key to continue... '
    winpty docker exec ozym-db //opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -i init-ozym-db.sql -v OZYM_APP_PASSWORD="$OZYM_APP_PASSWORD"

    read -p 'Press any key to continue... '

    echo 'Configurating sample database and applying data migrations...'
    winpty docker exec ozym-web //app/ozymworksbundle \
        --connection "Server=ozymdb;Database=OzymWorks;User Id=sa;Password=$MSSQL_SA_PASSWORD;TrustServerCertificate=true"

    echo 'Configurating sample identity database...'
    winpty docker exec ozym-web //app/ozymidentitybundle \
        --connection "Server=ozymdb;Database=OzymIdentity;User Id=sa;Password=$MSSQL_SA_PASSWORD;TrustServerCertificate=true"

    # Clean up variables.
    unset MSSQL_SA_PASSWORD
    unset OZYM_APP_PASSWORD
    unset init_sql_script

    echo -e '\nInitialization complete!'
fi
