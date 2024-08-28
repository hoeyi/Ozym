#!/bin/bash

# Change working directory to the project direct where IdentityDbContext resides.
cd ../Ozym.Web

# Prompt for a migration to use, but skip if empty.
read -p 'Enter migration id or press enter to skip: ' MIGRATION

# Check if a migration was entered. If not, default to latest.
if [ -z "$MIGRATION" ]; then
    dotnet ef database update \
        --context Ozym.Web.Identity.Data.IdentityDbContext \
        --startup-project Ozym.Web.csproj \
        --project Ozym.Web.csproj
else
    dotnet ef database update "$MIGRATION" \
        --context Ozym.Web.Identity.Data.IdentityDbContext \
        --startup-project Ozym.Web.csproj \
        --project Ozym.Web.csproj
fi

cd ../
