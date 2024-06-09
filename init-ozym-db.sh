#!/bin/bash

# Script for creating sql server login and mapping it to database users.
# Environment variables $MSSQL_SA_PASSWORD and $OZYM_APP_PASSWORD must be defined.
init_sql_script="
/**
	Create the application server login.
**/
CREATE LOGIN [OzymAppUser] WITH PASSWORD=N'$OZYM_APP_PASSWORD', CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
/**
	Create the databases.
**/
print('Creating databases: [OzymWorks], [OzymIdentity]...')
CREATE DATABASE [OzymWorks]
CREATE DATABASE [OzymIdentity]
GO
print('...complete.')
/**
	Create the database-level users mapped to the server login. Assign to 
	to the db_datareader and db_datawriter roles.
**/
USE [OzymWorks]
CREATE USER [OzymAppUser] FOR LOGIN [OzymAppUser] WITH DEFAULT_SCHEMA=[dbo]
ALTER ROLE db_datareader ADD MEMBER [OzymAppUser];
ALTER ROLE db_datawriter ADD MEMBER [OzymAppUser];
print('Created [OzymAppUser] in [OzymWorks]')
GO
USE [OzymIdentity]
CREATE USER [OzymAppUser] FOR LOGIN [OzymAppUser] WITH DEFAULT_SCHEMA=[dbo]
ALTER ROLE db_datareader ADD MEMBER [OzymAppUser];
ALTER ROLE db_datareader ADD MEMBER [OzymAppUser];
print('Created [OzymAppUser] in [OzymIdentity]')
GO
print('Initialization complete.')
"

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q "$init_sql_script" || exit 1
