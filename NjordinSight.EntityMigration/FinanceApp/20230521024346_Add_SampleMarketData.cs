using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleMarketData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentStrategy",
                columns: new[] { "InvestmentStrategyID", "DisplayName", "Notes" },
                values: new object[,]
                {
                    { -2, "YOLOS", "Risky Bets Strategy" },
                    { -1, "Retirement", "Retirement Strategy" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndex",
                columns: new[] { "IndexID", "IndexCode", "IndexDescription" },
                values: new object[,]
                {
                    { -4, "NASDAQ", "NASDAQ Composite" },
                    { -3, "DJIA", "Dow Jones Industrial Average" },
                    { -2, "SPX", "S&P 500" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                columns: new[] { "AttributeID", "DisplayName" },
                values: new object[] { -950, "Economy" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[] { -849, -60, "MSC", (short)249 });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Country",
                columns: new[] { "CountryID", "DisplayName", "IsoCode3" },
                values: new object[] { -849, "Miscellaneous", "MSC" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID", "Weight" },
                values: new object[,]
                {
                    { -103, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 0.4m },
                    { -102, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 0.6m },
                    { -101, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, 0.2m },
                    { -100, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, 0.8m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "IndexPriceID", "MarketIndexID", "Price", "PriceCode", "PriceDate" },
                values: new object[,]
                {
                    { -186, -2, 0m, "p", new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -185, -4, 0m, "p", new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -184, -3, 0m, "p", new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -183, -2, 0m, "p", new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -182, -4, 0m, "p", new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -181, -3, 0m, "p", new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -180, -2, 0m, "p", new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -179, -4, 0m, "p", new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -178, -3, 0m, "p", new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -177, -2, 0m, "p", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -176, -4, 0m, "p", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -175, -3, 0m, "p", new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -174, -2, 0m, "p", new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -173, -4, 0m, "p", new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -172, -3, 0m, "p", new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -171, -2, 0m, "p", new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -170, -4, 0m, "p", new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -169, -3, 0m, "p", new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -168, -2, 0m, "p", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -167, -4, 0m, "p", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -166, -3, 0m, "p", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -165, -2, 0m, "p", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -164, -4, 0m, "p", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -163, -3, 0m, "p", new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -162, -2, 0m, "p", new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -161, -4, 0m, "p", new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -160, -3, 0m, "p", new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -159, -2, 0m, "p", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -158, -4, 0m, "p", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -157, -3, 0m, "p", new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -156, -2, 0m, "p", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -155, -4, 0m, "p", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -154, -3, 0m, "p", new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -153, -2, 0m, "p", new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -152, -4, 0m, "p", new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -151, -3, 0m, "p", new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -150, -2, 0m, "p", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "IndexPriceID", "MarketIndexID", "Price", "PriceCode", "PriceDate" },
                values: new object[,]
                {
                    { -149, -4, 0m, "p", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -148, -3, 0m, "p", new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -147, -2, 0m, "p", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -146, -4, 0m, "p", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -145, -3, 0m, "p", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -144, -2, 0m, "p", new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -143, -4, 0m, "p", new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -142, -3, 0m, "p", new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -141, -2, 0m, "p", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -140, -4, 0m, "p", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -139, -3, 0m, "p", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -138, -2, 0m, "p", new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -137, -4, 0m, "p", new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -136, -3, 0m, "p", new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -135, -2, 0m, "p", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -134, -4, 0m, "p", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -133, -3, 0m, "p", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -132, -2, 0m, "p", new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -131, -4, 0m, "p", new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -130, -3, 0m, "p", new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -129, -2, 0m, "p", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -128, -4, 0m, "p", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -127, -3, 0m, "p", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -126, -2, 0m, "p", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -125, -4, 0m, "p", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -124, -3, 0m, "p", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -123, -2, 0m, "p", new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -122, -4, 0m, "p", new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -121, -3, 0m, "p", new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -120, -2, 0m, "p", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -119, -4, 0m, "p", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -118, -3, 0m, "p", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -117, -2, 0m, "p", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -116, -4, 0m, "p", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -115, -3, 0m, "p", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -114, -2, 0m, "p", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -113, -4, 0m, "p", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -112, -3, 0m, "p", new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -111, -2, 0m, "p", new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -110, -4, 0m, "p", new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -109, -3, 0m, "p", new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -108, -2, 0m, "p", new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "IndexPriceID", "MarketIndexID", "Price", "PriceCode", "PriceDate" },
                values: new object[,]
                {
                    { -107, -4, 0m, "p", new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -106, -3, 0m, "p", new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -105, -2, 0m, "p", new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -104, -4, 0m, "p", new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -103, -3, 0m, "p", new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -102, -2, 0m, "p", new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -101, -4, 0m, "p", new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -100, -3, 0m, "p", new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -99, -2, 0m, "p", new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -98, -4, 0m, "p", new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -97, -3, 0m, "p", new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -96, -2, 0m, "p", new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -95, -4, 0m, "p", new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -94, -3, 0m, "p", new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -93, -2, 0m, "p", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -92, -4, 0m, "p", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -91, -3, 0m, "p", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -90, -2, 0m, "p", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -89, -4, 0m, "p", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -88, -3, 0m, "p", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -87, -2, 0m, "p", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -86, -4, 0m, "p", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -85, -3, 0m, "p", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -84, -2, 0m, "p", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -83, -4, 0m, "p", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -82, -3, 0m, "p", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -81, -2, 0m, "p", new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -80, -4, 0m, "p", new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -79, -3, 0m, "p", new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -78, -2, 0m, "p", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -77, -4, 0m, "p", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -76, -3, 0m, "p", new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -75, -2, 0m, "p", new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -74, -4, 0m, "p", new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -73, -3, 0m, "p", new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -72, -2, 0m, "p", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -71, -4, 0m, "p", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -70, -3, 0m, "p", new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -69, -2, 0m, "p", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -68, -4, 0m, "p", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -67, -3, 0m, "p", new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -66, -2, 0m, "p", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "IndexPriceID", "MarketIndexID", "Price", "PriceCode", "PriceDate" },
                values: new object[,]
                {
                    { -65, -4, 0m, "p", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -64, -3, 0m, "p", new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -63, -2, 0m, "p", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -62, -4, 0m, "p", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -61, -3, 0m, "p", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -60, -2, 0m, "p", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -59, -4, 0m, "p", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -58, -3, 0m, "p", new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -57, -2, 0m, "p", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -56, -4, 0m, "p", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -55, -3, 0m, "p", new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -54, -2, 0m, "p", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -53, -4, 0m, "p", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -52, -3, 0m, "p", new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -51, -2, 0m, "p", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -50, -4, 0m, "p", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -49, -3, 0m, "p", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -48, -2, 0m, "p", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -47, -4, 0m, "p", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -46, -3, 0m, "p", new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -45, -2, 0m, "p", new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -44, -4, 0m, "p", new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -43, -3, 0m, "p", new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -42, -2, 0m, "p", new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -41, -4, 0m, "p", new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -40, -3, 0m, "p", new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -39, -2, 0m, "p", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -38, -4, 0m, "p", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -37, -3, 0m, "p", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -36, -2, 0m, "p", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -35, -4, 0m, "p", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -34, -3, 0m, "p", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -33, -2, 0m, "p", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -32, -4, 0m, "p", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -31, -3, 0m, "p", new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -30, -2, 0m, "p", new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -29, -4, 0m, "p", new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -28, -3, 0m, "p", new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -27, -2, 0m, "p", new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -26, -4, 0m, "p", new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -25, -3, 0m, "p", new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -24, -2, 0m, "p", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                columns: new[] { "IndexPriceID", "MarketIndexID", "Price", "PriceCode", "PriceDate" },
                values: new object[,]
                {
                    { -23, -4, 0m, "p", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -22, -3, 0m, "p", new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -21, -2, 0m, "p", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -20, -4, 0m, "p", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -19, -3, 0m, "p", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -18, -2, 0m, "p", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -17, -4, 0m, "p", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -16, -3, 0m, "p", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -15, -2, 0m, "p", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -14, -4, 0m, "p", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -13, -3, 0m, "p", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -12, -2, 0m, "p", new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -4, 0m, "p", new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -10, -3, 0m, "p", new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -9, -2, 0m, "p", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -8, -4, 0m, "p", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -7, -3, 0m, "p", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -6, -2, 0m, "p", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -5, -4, 0m, "p", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -4, -3, 0m, "p", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -3, -2, 0m, "p", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -2, -4, 0m, "p", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -1, -3, 0m, "p", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -953, -950, "Frontier", (short)2 },
                    { -952, -950, "Emerging", (short)1 },
                    { -951, -950, "Developed", (short)0 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                columns: new[] { "AttributeID", "ScopeCode" },
                values: new object[] { -950, "cou" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate", "Weight" },
                values: new object[,]
                {
                    { -953, -840, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -825, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -809, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -802, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -796, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -780, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -766, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -761, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -741, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -728, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -723, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -719, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -715, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -714, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -713, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -668, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -653, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -617, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -953, -616, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -832, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -826, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -819, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -805, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -794, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -781, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -779, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -776, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -774, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -773, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -767, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -685, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -664, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -647, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate", "Weight" },
                values: new object[,]
                {
                    { -952, -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -952, -609, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -777, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -765, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -758, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -620, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -613, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m },
                    { -951, -612, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID", "Weight" },
                values: new object[,]
                {
                    { -953, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 0.65m },
                    { -952, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2, 0.35m },
                    { -952, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, 0.15m },
                    { -951, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, 0.85m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Country",
                keyColumn: "CountryID",
                keyValue: -849);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -840, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -825, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -809, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -802, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -796, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -780, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -766, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -761, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -741, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -728, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -723, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -719, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -715, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -714, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -713, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -668, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -653, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -617, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -953, -616, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -832, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -826, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -819, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -805, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -794, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -781, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -779, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -776, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -774, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -773, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -767, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -685, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -664, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -647, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -952, -609, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -777, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -765, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -758, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -620, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -613, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "CountryAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "CountryID", "EffectiveDate" },
                keyValues: new object[] { -951, -612, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -953, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -952, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -103, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -102, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -2 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -952, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -951, new DateTime(2015, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -101, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategyTarget",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "InvestmentStrategyID" },
                keyValues: new object[] { -100, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), -1 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -186);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -185);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -184);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -183);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -182);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -181);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -180);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -179);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -178);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -177);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -176);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -175);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -174);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -173);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -172);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -171);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -170);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -169);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -168);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -167);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -166);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -165);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -164);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -163);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -162);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -161);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -160);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -159);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -158);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -157);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -156);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -155);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -154);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -153);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -152);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -151);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -150);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -149);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -148);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -147);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -146);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -145);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -144);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -143);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -142);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -141);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -140);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -139);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -138);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -137);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -136);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -135);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -134);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -133);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -132);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -131);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -130);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -129);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -128);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -127);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -126);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -125);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -124);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -123);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -122);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -121);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -120);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -119);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -118);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -117);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -116);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -115);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -114);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -113);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -112);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -111);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -110);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -109);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -108);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -107);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -106);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -105);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -104);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -103);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -102);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -101);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -100);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -99);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -98);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -97);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -96);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -95);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -94);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -93);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -92);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -91);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -90);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -89);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -88);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -87);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -86);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -85);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -84);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -83);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -82);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -81);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -80);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -79);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -78);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -77);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -76);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -75);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -74);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -73);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -72);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -71);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -70);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -69);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -68);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -67);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -66);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -65);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -64);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -63);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -62);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -61);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -60);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -59);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -58);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -57);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -56);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -55);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -54);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -53);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -52);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -51);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -50);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -49);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -48);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -47);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -46);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -45);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -44);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -43);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -42);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -41);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -40);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -39);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -38);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -37);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -36);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -35);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -34);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -33);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -32);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -31);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -30);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -29);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -28);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -27);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -26);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -25);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -24);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -22);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -21);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -20);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -19);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -18);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -17);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -16);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -15);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndexPrice",
                keyColumn: "IndexPriceID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                keyColumns: new[] { "AttributeID", "ScopeCode" },
                keyValues: new object[] { -950, "cou" });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategy",
                keyColumn: "InvestmentStrategyID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentStrategy",
                keyColumn: "InvestmentStrategyID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndex",
                keyColumn: "IndexID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndex",
                keyColumn: "IndexID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "MarketIndex",
                keyColumn: "IndexID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -953);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -952);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -951);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -849);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                keyColumn: "AttributeID",
                keyValue: -950);
        }
    }
}
