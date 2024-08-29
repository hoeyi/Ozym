#!/bin/bash

# Prompt for the value of migration
MIGRATION=''

# Prompt the user to enter the migration id
while [ -z "$MIGRATION" ]; do
    read -p 'Enter migration id: ' MIGRATION
done

# Add the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations add "$MIGRATION" \
	--context Ozym.EntityModel.Context.FinanceDbContext \
	--startup-project ../Ozym.Web/Ozym.Web.csproj \
	--project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj \
	--output-dir FinanceApp

cd ../