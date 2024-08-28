#!/bin/bash

# Change working directory to the project directory where IdentityDbContext resides.
cd ../Ozym.Web

# Prompt for the value of migration
MIGRATION=''

# Prompt the user to enter the migration id
while [ -z "$MIGRATION" ]; do
    read -p 'Enter migration id: ' MIGRATION
done

# Add the migration. Reference the IdentityDbContext with fully-qualified namespace.
dotnet ef migrations add "$MIGRATION" \
	--startup-project Ozym.Web.csproj \
	--context Ozym.Web.Identity.Data.IdentityDbContext \
	--project Ozym.Web.csproj \
	--output-dir Identity/Migrations

cd ../
