using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration
{
    public partial class FinanceDbContext_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "TransactionVersion",
                schema: "FinanceApp",
                table: "BankTransaction",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SymbolCode",
                schema: "FinanceApp",
                table: "SecuritySymbol",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                computedColumnSql: "(case when [SymbolTypeID]=(-10) then [Cusip] when [SymbolTypeID]=(-20) then [CustomSymbol] when [SymbolTypeID]=(-30) then [OptionTicker] when [SymbolTypeID]=(-40) then [Ticker]  end)",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrefixedObjectCode",
                schema: "FinanceApp",
                table: "AccountObject",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                computedColumnSql: "(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SymbolCode",
                schema: "FinanceApp",
                table: "SecuritySymbol",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true,
                oldComputedColumnSql: "(case when [SymbolTypeID]=(-10) then [Cusip] when [SymbolTypeID]=(-20) then [CustomSymbol] when [SymbolTypeID]=(-30) then [OptionTicker] when [SymbolTypeID]=(-40) then [Ticker]  end)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "TransactionVersion",
                schema: "FinanceApp",
                table: "BankTransaction",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "rowversion",
                oldRowVersion: true);

            migrationBuilder.AlterColumn<string>(
                name: "PrefixedObjectCode",
                schema: "FinanceApp",
                table: "AccountObject",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldComputedColumnSql: "(case when [ObjectType]='c' then concat('+',[AccountObjectCode]) else [AccountObjectCode] end)");
        }
    }
}
