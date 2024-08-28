#!/bin/bash

# Change working directory to the project directory where FinanceDbContext resides.
cd ../Ozym.EntityModel

# Bundle the migration. Reference the FinanceDbContext with fully-qualified namespace.
dotnet ef migrations bundle \
	--context Ozym.EntityModel.Context.FinanceDbContext \
	--startup-project ../Ozym.Web/Ozym.Web.csproj \
	--project ../Ozym.EntityMigration/Ozym.EntityMigration.csproj \
	--output bin/Ozymefbundle \
	-r linux-x64 \
	--self-contained \
	--no-build \
	--force

cd ..\
