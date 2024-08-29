#!/bin/bash

# Prompt for a migration to use, but skip if empty.
read -p 'Enter migration id or press enter to skip: ' MIGRATION

# Check if a migration was entered. If not, default to latest.
if [ -z "$MIGRATION" ]; then
    dotnet ef database update \
		--context Ozym.EntityModel.Context.FinanceDbContext \
		--startup-project ../Ozym.Web/Ozym.Web.csproj \
		--project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj
else
    dotnet ef database update "$MIGRATION" \
		--context Ozym.EntityModel.Context.FinanceDbContext \
		--startup-project ../Ozym.Web/Ozym.Web.csproj \
		--project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj
fi

cd ../
