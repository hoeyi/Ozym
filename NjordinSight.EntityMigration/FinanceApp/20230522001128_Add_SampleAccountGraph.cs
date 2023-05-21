using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleAccountGraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountCustodian",
                columns: new[] { "AccountCustodianID", "CustodianCode", "DisplayName" },
                values: new object[,]
                {
                    { -2, "TCB", "Tres Comas Brokerage" },
                    { -1, "NSCU", "Northern Savings Credit Union" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountObject",
                columns: new[] { "AccountObjectID", "AccountObjectCode", "CloseDate", "ObjectDescription", "ObjectDisplayName", "ObjectType", "StartDate" },
                values: new object[,]
                {
                    { -14, "ALL", null, "Aggregates all accounts.", "All accounts", "c", new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -13, "BROKERAGE", null, "Aggregates all brokerage accounts.", "Brokerage accounts", "c", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -12, "CRYPTO", null, null, "Cryptocurrency Wallets", "a", new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, "INVEST", null, null, "Investing account", "a", new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -10, "DEBIT1", null, "Handles bill-paying and deposits.", "Checking Account", "a", new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Account",
                columns: new[] { "AccountID", "AccountCustodianID", "AccountNumber", "BooksClosedDate", "HasBankTransaction", "HasBrokerTransaction", "HasWallet", "IsComplianceTradable" },
                values: new object[,]
                {
                    { -12, null, "553BF08", null, false, true, true, false },
                    { -11, -2, "4-8-15-16-23-42", null, false, true, false, false },
                    { -10, -1, "8675309", null, true, false, false, false }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "EffectiveDate", "Weight" },
                values: new object[,]
                {
                    { -10, -907, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -13, -905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -12, -905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountComposite",
                column: "AccountCompositeID",
                values: new object[]
                {
                    -14,
                    -13
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                columns: new[] { "AccountCompositeID", "AccountID", "EntryDate", "Comment", "DisplayOrder", "ExitDate" },
                values: new object[,]
                {
                    { -14, -12, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add crypto wallets", 0, null },
                    { -14, -11, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add retirement account", 0, null },
                    { -14, -10, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add checking account", 0, null },
                    { -13, -12, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add crypto wallets", 0, null },
                    { -13, -11, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add retirement account", 0, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "AccountWallet",
                columns: new[] { "AccountWalletID", "AccountID", "AddressCode", "AddressTag", "DenominationSecurityID" },
                values: new object[] { -1, -12, "169 3799 590B DBDB", null, -758 });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransaction",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Comment", "TransactionCodeID", "TransactionDate" },
                values: new object[,]
                {
                    { -7703, -10, -6.16m, null, -23, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7702, -10, -2.08m, null, -23, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7701, -10, -11.61m, null, -23, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7700, -10, -12.63m, null, -23, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7699, -10, -3.2m, null, -23, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7698, -10, -0.88m, null, -23, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7697, -10, -0.75m, null, -23, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7696, -10, -57.76m, null, -23, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7695, -10, -19.59m, null, -23, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7694, -10, -2.22m, null, -23, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7693, -10, -5.62m, null, -23, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7692, -10, -2.42m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7691, -10, -25.01m, null, -23, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7690, -10, -2.63m, null, -23, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7689, -10, -1.68m, null, -23, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7688, -10, -41.41m, null, -23, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7687, -10, -10.3m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7686, -10, -2.12m, null, -23, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7685, -10, -2.27m, null, -23, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7684, -10, -17.56m, null, -23, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7683, -10, -9.26m, null, -23, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7682, -10, -2.25m, null, -23, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7681, -10, -2.44m, null, -23, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7680, -10, -6.17m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7679, -10, -9.92m, null, -23, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7678, -10, -1.05m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7677, -10, -4.32m, null, -23, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7676, -10, -12.68m, null, -23, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7675, -10, -10.02m, null, -23, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7674, -10, -2.55m, null, -23, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7673, -10, -0.74m, null, -23, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7672, -10, -1.18m, null, -23, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7671, -10, -5.52m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7670, -10, -2.01m, null, -23, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7669, -10, -2.01m, null, -23, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7668, -10, -6.5m, null, -23, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransaction",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Comment", "TransactionCodeID", "TransactionDate" },
                values: new object[,]
                {
                    { -7667, -10, -22.47m, null, -23, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7666, -10, -16.76m, null, -23, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7665, -10, -4.05m, null, -23, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7664, -10, -6.87m, null, -23, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7663, -10, -4.29m, null, -23, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7662, -10, -65.46m, null, -23, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7661, -10, -4.38m, null, -23, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7660, -10, -2.69m, null, -23, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7659, -10, -3.38m, null, -23, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7658, -10, -11.04m, null, -23, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7657, -10, -0.49m, null, -23, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7656, -10, -4.54m, null, -23, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7655, -10, -2.27m, null, -23, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7654, -10, -3.43m, null, -23, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7653, -10, -2.73m, null, -23, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7652, -10, -4.54m, null, -23, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7651, -10, -63.51m, null, -23, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7650, -10, -0.51m, null, -23, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7649, -10, -13.32m, null, -23, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7648, -10, -5.1m, null, -23, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7647, -10, -3.84m, null, -23, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7646, -10, -33.54m, null, -23, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7645, -10, -3.48m, null, -23, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7644, -10, -4.46m, null, -23, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7643, -10, -9.65m, null, -23, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7642, -10, -0.65m, null, -23, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7641, -10, -0.23m, null, -23, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7640, -10, -6.96m, null, -23, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7639, -10, -15.59m, null, -23, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7638, -10, -1.72m, null, -23, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7637, -10, -4.58m, null, -23, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7636, -10, -1.94m, null, -23, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7635, -10, -12.89m, null, -23, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7634, -10, -12.31m, null, -23, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7633, -10, -0.73m, null, -23, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7632, -10, -10.52m, null, -23, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7631, -10, -2.17m, null, -23, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7630, -10, -23.44m, null, -23, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7629, -10, -2.76m, null, -23, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7628, -10, -5.89m, null, -23, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7627, -10, -7.48m, null, -23, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7626, -10, -9.91m, null, -23, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransaction",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Comment", "TransactionCodeID", "TransactionDate" },
                values: new object[,]
                {
                    { -7625, -10, -4.1m, null, -23, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7624, -10, -3.38m, null, -23, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7623, -10, -34.76m, null, -23, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7622, -10, -8.91m, null, -23, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7621, -10, -1.63m, null, -23, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7620, -10, -7.48m, null, -23, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7619, -10, -9.07m, null, -23, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7618, -10, -8.14m, null, -23, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7617, -10, -3.55m, null, -23, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7616, -10, -24.41m, null, -23, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7615, -10, -12.24m, null, -23, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7614, -10, -1.4m, null, -23, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7613, -10, -22.95m, null, -23, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7612, -10, -3.19m, null, -23, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7611, -10, -1.11m, null, -23, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7610, -10, -2.09m, null, -23, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7609, -10, -29.52m, null, -23, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7608, -10, -1.79m, null, -23, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7607, -10, -1.34m, null, -23, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7606, -10, -12.78m, null, -23, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7605, -10, -0.82m, null, -23, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7604, -10, -2.79m, null, -23, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7603, -10, -5.94m, null, -23, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7602, -10, -4.02m, null, -23, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7601, -10, -26.98m, null, -23, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7600, -10, -1.09m, null, -23, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7599, -10, -1.29m, null, -23, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7598, -10, -4.44m, null, -23, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7597, -10, -1.82m, null, -23, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7596, -10, -9.13m, null, -23, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7595, -10, -4.76m, null, -23, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7594, -10, -12.71m, null, -23, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7593, -10, -9.57m, null, -23, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7592, -10, -3.09m, null, -23, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7591, -10, -3.2m, null, -23, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7590, -10, -0.39m, null, -23, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7589, -10, -6.54m, null, -23, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7588, -10, -1.69m, null, -23, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7587, -10, -16.57m, null, -23, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7586, -10, -21.99m, null, -23, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7585, -10, -6.53m, null, -23, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7584, -10, -8.53m, null, -23, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransaction",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Comment", "TransactionCodeID", "TransactionDate" },
                values: new object[,]
                {
                    { -7583, -10, -0.55m, null, -23, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7582, -10, -3.98m, null, -23, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7581, -10, -1.86m, null, -23, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7580, -10, -12.97m, null, -23, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7579, -10, -7.99m, null, -23, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7578, -10, -4.87m, null, -23, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7577, -10, -1.81m, null, -23, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7576, -10, -1.94m, null, -23, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7575, -10, -1.67m, null, -23, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7574, -10, -4.69m, null, -23, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7573, -10, -2.36m, null, -23, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7572, -10, -5.47m, null, -23, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7571, -10, -1.5m, null, -23, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7570, -10, -16.22m, null, -23, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7569, -10, -59.73m, null, -16, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7568, -10, -86.65m, null, -16, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7567, -10, -41.53m, null, -16, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7534, -10, -68m, null, -9, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7533, -10, -20.9m, null, -9, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7532, -10, -14.07m, null, -9, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7531, -10, -9.42m, null, -7, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7530, -10, -23.64m, null, -7, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7529, -10, -4.88m, null, -7, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7528, -10, -4.44m, null, -7, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7527, -10, -23.34m, null, -7, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7526, -10, -26.73m, null, -7, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7525, -10, -9.83m, null, -7, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7524, -10, -1.79m, null, -7, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7523, -10, -2.81m, null, -7, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7522, -10, -12.95m, null, -7, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7521, -10, -24.43m, null, -7, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7520, -10, -3.9m, null, -7, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7519, -10, -5.58m, null, -7, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7518, -10, -0.31m, null, -7, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7517, -10, -5.95m, null, -7, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7516, -10, 1884.41m, null, -42, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7514, -10, 65.97m, null, -42, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7513, -10, 1992.22m, null, -42, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7512, -10, 433.66m, null, -42, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7511, -10, 24.9m, null, -42, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7510, -10, 242.02m, null, -42, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7509, -10, 1138.74m, null, -42, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BankTransaction",
                columns: new[] { "TransactionID", "AccountID", "Amount", "Comment", "TransactionCodeID", "TransactionDate" },
                values: new object[,]
                {
                    { -7503, -10, 283.54m, null, -42, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7482, -10, -134.23m, null, -5, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7477, -10, -77.56m, null, -5, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7476, -10, -184.59m, null, -5, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7472, -10, -1468.25m, null, -21, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7471, -10, -967.62m, null, -21, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7470, -10, -547.58m, null, -21, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7458, -10, -113.14m, null, -12, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7457, -10, -281.36m, null, -12, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                columns: new[] { "TransactionID", "AccountID", "AcquisitionDate", "Amount", "DepSecurityID", "Fee", "Quantity", "SecurityID", "SettleDate", "TaxLotID", "TradeDate", "TransactionCodeID", "Withholding" },
                values: new object[,]
                {
                    { -5812, -11, null, 1925.16m, -101, null, null, -761, null, null, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5811, -11, null, 1658.07m, -101, null, null, -761, null, null, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5810, -11, null, 1816.89m, -101, null, null, -760, null, null, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5809, -11, null, 35.55m, -101, null, null, -759, null, null, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5808, -11, null, 1113.66m, -101, null, null, -759, null, null, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5807, -11, null, 4657.71m, -101, null, null, -759, null, null, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5806, -11, null, 4.59m, -101, null, null, -747, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5805, -11, null, 1136.28m, -101, null, null, -745, null, null, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5804, -11, null, 7045.02m, -101, null, null, -745, null, null, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5803, -11, null, 0.9m, -416, null, null, -745, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5802, -11, null, 24.27m, -416, null, null, -745, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5801, -11, null, 6.81m, -416, null, null, -745, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5800, -11, null, 28.92m, -416, null, null, -745, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5799, -11, null, 1661.76m, -101, null, null, -745, null, null, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5798, -11, null, 237.6m, -101, null, null, -578, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5797, -11, null, 81.24m, -101, null, null, -578, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5796, -11, null, 76.05m, -101, null, null, -578, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5795, -11, null, 92.94m, -101, null, null, -578, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5794, -11, null, 31.92m, -416, null, null, -578, null, null, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5793, -11, null, 5.94m, -416, null, null, -578, null, null, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5792, -11, null, 13.27m, -101, null, null, -578, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5791, -11, null, 96.15m, -101, null, null, -578, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5790, -11, null, 519.3m, -101, null, null, -578, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5789, -11, null, 281.58m, -101, null, null, -578, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5788, -11, null, 191.64m, -101, null, null, -577, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5787, -11, null, 273m, -101, null, null, -577, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5786, -11, null, 292.35m, -101, null, null, -577, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5785, -11, null, 116.07m, -101, null, null, -577, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5784, -11, null, 452.16m, -101, null, null, -578, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5783, -11, null, 225.51m, -101, null, null, -577, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5782, -11, null, 220.14m, -101, null, null, -577, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5781, -11, null, 17.25m, -101, null, null, -577, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5780, -11, null, 1082.25m, -101, null, null, -576, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                columns: new[] { "TransactionID", "AccountID", "AcquisitionDate", "Amount", "DepSecurityID", "Fee", "Quantity", "SecurityID", "SettleDate", "TaxLotID", "TradeDate", "TransactionCodeID", "Withholding" },
                values: new object[,]
                {
                    { -5779, -11, null, 309.36m, -101, null, null, -576, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5778, -11, null, 286.32m, -101, null, null, -576, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5777, -11, null, 39.54m, -101, null, null, -576, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5776, -11, null, 4.29m, -101, null, null, -576, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, null },
                    { -5775, -11, null, 654.87m, -101, null, null, -576, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5774, -11, null, 224.25m, -101, null, null, -576, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5773, -11, null, 30.27m, -101, null, null, -576, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5772, -11, null, 90.09m, -101, null, null, -575, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5771, -11, null, 288.81m, -416, null, null, -575, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5770, -11, null, 223.71m, -416, null, null, -575, null, null, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5769, -11, null, 30.81m, -101, null, null, -575, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5768, -11, null, 64.32m, -101, null, null, -575, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5767, -11, null, 196.83m, -101, null, null, -575, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5766, -11, null, 1.11m, -101, null, null, -575, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, null },
                    { -5765, -11, null, 251.34m, -101, null, null, -575, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5764, -11, null, 150.18m, -101, null, null, -575, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5763, -11, null, 288.27m, -101, null, null, -575, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5762, -11, null, 395.07m, -101, null, null, -574, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5761, -11, null, 153.12m, -101, null, null, -574, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5760, -11, null, 258.66m, -101, null, null, -574, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5759, -11, null, 708.96m, -101, null, null, -574, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5758, -11, null, 1.02m, -101, null, null, -574, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, null },
                    { -5757, -11, null, 1052.76m, -101, null, null, -574, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5756, -11, null, 504.69m, -101, null, null, -574, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5755, -11, null, 752.37m, -101, null, null, -574, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5754, -11, null, 1.62m, -101, null, null, -523, null, null, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5753, -11, null, 0.09m, -416, null, null, -514, null, null, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5752, -11, null, 6.81m, -416, null, null, -514, null, null, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5751, -11, null, 11.49m, -416, null, null, -514, null, null, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5750, -11, null, 61.89m, -416, null, null, -514, null, null, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5749, -11, null, 737.58m, -101, null, null, -514, null, null, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5748, -11, null, 54.72m, -101, null, null, -493, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, 7.37m },
                    { -5747, -11, null, 770.67m, -101, null, null, -493, null, null, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5746, -11, null, 21.63m, -101, null, null, -482, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5745, -11, null, 160.86m, -101, null, null, -442, null, null, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5744, -11, null, 0.3m, -416, null, null, -442, null, null, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5743, -11, null, 14.55m, -416, null, null, -442, null, null, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5742, -11, null, 158.07m, -101, null, null, -442, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5741, -11, null, 171.69m, -101, null, null, -442, null, null, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5740, -11, null, 13.47m, -101, null, null, -442, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5739, -11, null, 1.5m, -101, null, null, -442, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, null },
                    { -5738, -11, null, 296.04m, -101, null, null, -442, null, null, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                columns: new[] { "TransactionID", "AccountID", "AcquisitionDate", "Amount", "DepSecurityID", "Fee", "Quantity", "SecurityID", "SettleDate", "TaxLotID", "TradeDate", "TransactionCodeID", "Withholding" },
                values: new object[,]
                {
                    { -5737, -11, null, 28.83m, -101, null, null, -442, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5736, -11, null, 23.85m, -101, null, null, -442, null, null, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5735, -11, null, 12.03m, -416, null, null, -432, null, null, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5734, -11, null, 7.05m, -416, null, null, -432, null, null, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5733, -11, null, 1.53m, -416, null, null, -432, null, null, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5732, -11, null, 22.77m, -416, null, null, -432, null, null, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5731, -11, null, 67.2m, -416, null, null, -432, null, null, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5730, -11, null, 13.53m, -416, null, null, -432, null, null, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5729, -11, null, 1.8m, -101, null, null, -432, null, null, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5728, -11, null, 18.96m, -416, null, null, -432, null, null, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5727, -11, null, 6233.49m, -101, null, null, -432, null, null, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -20, null },
                    { -5726, -11, null, 2.88m, -416, null, null, -432, null, null, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5725, -11, null, 20.88m, -416, null, null, -432, null, null, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5724, -11, null, 35.28m, -416, null, null, -432, null, null, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5723, -11, null, 1.65m, -101, null, null, -416, null, null, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5722, -11, null, 4.38m, -101, null, null, -416, null, null, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5721, -11, null, 7737.42m, -101, null, null, -416, null, null, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5720, -11, null, 3839.25m, -101, null, null, -416, null, null, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5719, -11, null, 0.6m, -101, null, null, -416, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5718, -11, null, 0.9m, -101, null, null, -416, null, null, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5717, -11, null, 1.86m, -101, null, null, -416, null, null, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5716, -11, null, 1430.67m, -101, null, null, -416, null, null, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5715, -11, null, 0.18m, -101, null, null, -416, null, null, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5714, -11, null, 0.36m, -101, null, null, -416, null, null, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5713, -11, null, 7318.41m, -101, null, null, -416, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5712, -11, null, 4700.76m, -101, null, null, -416, null, null, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5711, -11, null, 14575.71m, -101, null, null, -416, null, null, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5710, -11, null, 2982.24m, -101, null, null, -416, null, null, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null },
                    { -5709, -11, null, 0.3m, -101, null, null, -416, null, null, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), -16, null },
                    { -5708, -11, null, 52.83m, -416, null, null, -411, null, null, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5707, -11, null, 0.57m, -416, null, null, -411, null, null, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5706, -11, null, 1.11m, -416, null, null, -406, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5705, -11, null, 145.08m, -416, null, null, -406, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5704, -11, null, 30.66m, -416, null, null, -406, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5703, -11, null, 209.22m, -416, null, null, -406, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5702, -11, null, 566.43m, -101, null, null, -406, null, null, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5701, -11, null, 3496.05m, -101, null, null, -406, null, null, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5700, -11, null, 75.54m, -416, null, null, -403, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5699, -11, null, 16.77m, -416, null, null, -403, null, null, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5698, -11, null, 92.19m, -416, null, null, -403, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5697, -11, null, 71.49m, -416, null, null, -403, null, null, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5696, -11, null, 99.21m, -416, null, null, -400, null, null, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                columns: new[] { "TransactionID", "AccountID", "AcquisitionDate", "Amount", "DepSecurityID", "Fee", "Quantity", "SecurityID", "SettleDate", "TaxLotID", "TradeDate", "TransactionCodeID", "Withholding" },
                values: new object[,]
                {
                    { -5695, -11, null, 7.32m, -416, null, null, -400, null, null, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5694, -11, null, 151.8m, -416, null, null, -392, null, null, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5693, -11, null, 357.9m, -416, null, null, -392, null, null, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5692, -11, null, 27.24m, -101, null, null, -325, null, null, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), -13, null },
                    { -5691, -11, null, 808.17m, -101, null, null, -315, null, null, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), -11, null },
                    { -5690, -11, null, 25000m, -101, null, null, -101, null, null, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -12, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "EffectiveDate" },
                keyValues: new object[] { -10, -907, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "EffectiveDate" },
                keyValues: new object[] { -13, -905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "EffectiveDate" },
                keyValues: new object[] { -12, -905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                keyColumns: new[] { "AccountCompositeID", "AccountID", "EntryDate" },
                keyValues: new object[] { -14, -12, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                keyColumns: new[] { "AccountCompositeID", "AccountID", "EntryDate" },
                keyValues: new object[] { -14, -11, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                keyColumns: new[] { "AccountCompositeID", "AccountID", "EntryDate" },
                keyValues: new object[] { -14, -10, new DateTime(2015, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                keyColumns: new[] { "AccountCompositeID", "AccountID", "EntryDate" },
                keyValues: new object[] { -13, -12, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCompositeMember",
                keyColumns: new[] { "AccountCompositeID", "AccountID", "EntryDate" },
                keyValues: new object[] { -13, -11, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountWallet",
                keyColumn: "AccountWalletID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7703);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7702);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7701);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7700);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7699);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7698);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7697);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7696);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7695);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7694);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7693);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7692);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7691);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7690);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7689);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7688);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7687);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7686);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7685);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7684);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7683);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7682);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7681);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7680);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7679);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7678);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7677);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7676);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7675);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7674);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7673);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7672);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7671);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7670);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7669);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7668);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7667);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7666);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7665);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7664);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7663);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7662);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7661);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7660);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7659);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7658);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7657);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7656);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7655);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7654);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7653);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7652);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7651);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7650);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7649);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7648);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7647);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7646);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7645);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7644);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7643);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7642);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7641);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7640);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7639);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7638);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7637);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7636);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7635);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7634);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7633);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7632);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7631);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7630);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7629);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7628);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7627);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7626);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7625);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7624);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7623);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7622);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7621);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7620);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7619);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7618);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7617);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7616);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7615);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7614);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7613);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7612);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7611);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7610);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7609);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7608);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7607);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7606);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7605);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7604);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7603);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7602);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7601);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7600);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7599);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7598);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7597);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7596);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7595);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7594);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7593);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7592);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7591);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7590);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7589);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7588);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7587);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7586);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7585);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7584);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7583);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7582);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7581);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7580);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7579);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7578);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7577);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7576);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7575);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7574);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7573);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7572);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7571);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7570);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7569);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7568);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7567);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7534);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7533);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7532);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7531);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7530);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7529);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7528);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7527);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7526);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7525);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7524);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7523);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7522);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7521);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7520);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7519);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7518);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7517);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7516);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7514);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7513);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7512);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7511);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7510);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7509);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7503);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7482);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7477);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7476);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7472);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7471);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7470);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7458);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BankTransaction",
                keyColumn: "TransactionID",
                keyValue: -7457);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5812);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5811);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5810);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5809);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5808);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5807);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5806);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5805);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5804);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5803);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5802);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5801);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5800);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5799);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5798);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5797);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5796);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5795);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5794);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5793);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5792);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5791);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5790);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5789);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5788);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5787);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5786);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5785);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5784);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5783);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5782);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5781);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5780);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5779);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5778);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5777);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5776);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5775);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5774);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5773);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5772);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5771);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5770);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5769);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5768);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5767);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5766);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5765);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5764);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5763);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5762);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5761);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5760);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5759);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5758);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5757);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5756);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5755);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5754);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5753);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5752);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5751);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5750);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5749);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5748);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5747);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5746);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5745);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5744);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5743);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5742);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5741);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5740);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5739);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5738);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5737);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5736);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5735);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5734);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5733);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5732);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5731);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5730);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5729);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5728);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5727);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5726);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5725);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5724);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5723);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5722);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5721);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5720);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5719);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5718);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5717);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5716);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5715);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5714);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5713);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5712);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5711);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5710);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5709);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5708);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5707);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5706);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5705);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5704);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5703);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5702);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5701);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5700);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5699);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5698);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5697);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5696);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5695);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5694);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5693);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5692);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5691);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "BrokerTransaction",
                keyColumn: "TransactionID",
                keyValue: -5690);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Account",
                keyColumn: "AccountID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Account",
                keyColumn: "AccountID",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Account",
                keyColumn: "AccountID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountComposite",
                keyColumn: "AccountCompositeID",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountComposite",
                keyColumn: "AccountCompositeID",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCustodian",
                keyColumn: "AccountCustodianID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountCustodian",
                keyColumn: "AccountCustodianID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountObject",
                keyColumn: "AccountObjectID",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountObject",
                keyColumn: "AccountObjectID",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountObject",
                keyColumn: "AccountObjectID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountObject",
                keyColumn: "AccountObjectID",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "AccountObject",
                keyColumn: "AccountObjectID",
                keyValue: -10);
        }
    }
}
