-- Create the application server login.
PRINT('Initializing SQL server...')
CREATE LOGIN [OzymAppUser] 
    WITH PASSWORD=N'$(OZYM_APP_PASSWORD)', 
    CHECK_EXPIRATION=OFF, 
    CHECK_POLICY=ON
print('...created login for application user')
GO
-- Create the databases.
CREATE DATABASE [OzymWorks]
CREATE DATABASE [OzymIdentity]
DECLARE @msg nvarchar(72)
SELECT
    @msg = STRING_AGG('[' + [name] + ']', ', ')
FROM sys.databases 
WHERE [name] LIKE 'Ozym%'
PRINT(FORMATMESSAGE('...created databases: %s.', @msg))
GO
-- Create database-level users mapped from the server login. Assign both to the 
-- db_datareader and db_datawriter roles.
USE [OzymWorks]
CREATE USER [OzymAppUser] FOR LOGIN [OzymAppUser] WITH DEFAULT_SCHEMA=[dbo]
ALTER ROLE db_datareader ADD MEMBER [OzymAppUser]
ALTER ROLE db_datawriter ADD MEMBER [OzymAppUser]
PRINT(FORMATMESSAGE('...created [OzymAppUser] in [%s].', DB_NAME()))
GO
USE [OzymIdentity]
CREATE USER [OzymAppUser] FOR LOGIN [OzymAppUser] WITH DEFAULT_SCHEMA=[dbo]
ALTER ROLE db_datareader ADD MEMBER [OzymAppUser]
ALTER ROLE db_datawriter ADD MEMBER [OzymAppUser]
PRINT(FORMATMESSAGE('...created [OzymAppUser] in [%s].', DB_NAME()))
PRINT('Initialization complete.')
GO
