using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleBankReferenceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                columns: new[] { "TransactionCodeID", "DisplayName", "TransactionCode" },
                values: new object[,]
                {
                    { -42, "Salary/Wages", "salary" },
                    { -23, "Restaurants/Dining", "dineout" },
                    { -21, "Mortgage/Rent", "mortgage" },
                    { -16, "Internet Service", "internet" },
                    { -15, "Insurance", "insurance" },
                    { -12, "Healthcare/Medical", "medical" },
                    { -9, "Gasoline/Fuel", "gas" },
                    { -7, "Entertainment", "media" },
                    { -5, "Electricity Service", "electricity" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID", "Weight" },
                values: new object[,]
                {
                    { -933, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -42, 1m },
                    { -932, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23, 1m },
                    { -932, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -7, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, 1m },
                    { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -5, 1m },
                    { -926, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -42, 1m },
                    { -925, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23, 1m },
                    { -924, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21, 1m },
                    { -924, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15, 1m },
                    { -923, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, 1m },
                    { -922, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -7, 1m },
                    { -921, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, 1m },
                    { -921, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -5, 1m },
                    { -920, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -9, 1m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -933, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -42 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -932, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -932, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -7 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -9 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -5 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -926, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -42 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -925, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -924, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -21 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -924, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -15 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -923, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -12 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -922, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -7 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -921, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -16 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -921, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -5 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCodeAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "TransactionCodeID" },
                keyValues: new object[] { -920, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -9 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -42);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -21);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -16);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -15);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransactionCode",
                keyColumn: "TransactionCodeID",
                keyValue: -5);
        }
    }
}
