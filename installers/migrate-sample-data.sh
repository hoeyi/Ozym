#!/bin/bash
read -p 'Enter sa password: ' -s MSSQL_SA_PASSWORD
echo -e "Applying migrations to OzymWorks database...\n"
/app/ozymworksbundle --connection "Server=ozymdb;Database=OzymWorks;User Id=sa;Password=$MSSQL_SA_PASSWORD;TrustServerCertificate=true"

echo -e "Applying migrations to OzymIdentity database...\n"
/app/ozymidentitybundle --connection "Server=ozymdb;Database=OzymIdentity;User Id=sa;Password=$MSSQL_SA_PASSWORD;TrustServerCertificate=true"

unset MSSQL_SA_PASSWORD