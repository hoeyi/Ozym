﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleSecurityGraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "Security",
                columns: new[] { "SecurityID", "HasPerpetualMarket", "HasPerpetualPrice", "Issuer", "SecurityDescription", "SecurityExchangeID", "SecurityTypeID" },
                values: new object[,]
                {
                    { -761, false, false, "Alexander Sachs Group", "Alexander Saches Growth Equity Fund", -8, -302 },
                    { -760, false, false, "Spectrum Financial Services", "Spectrum Financial Services", -2, -300 },
                    { -759, false, false, "Cygnus Systems Corporation", "Cygnus Systems Corporation", -5, -300 },
                    { -758, true, true, "Unicorn Network", "LunaticornCoin", null, -312 },
                    { -748, false, false, "Luminous Investments", "LMN 1/19/2024 15.00 Call", null, -310 },
                    { -747, false, false, "Luminous Investments", "StellarCom Communication Technology ETF", -8, -302 },
                    { -745, false, false, "Luminous Investments", "Celestial Bond ETF", -8, -302 },
                    { -728, false, false, "Nebula Laboratories", "Nebula Laboratories", -5, -300 },
                    { -727, false, false, "Unity Funds", "Unity Funds", -5, -300 },
                    { -578, false, false, "Alexander Sachs Group", "Harmonia Investment Bond ETF", null, -303 },
                    { -577, false, false, "E. Logan Asset Management", "E. Logan Global Equity Fund", null, -303 },
                    { -576, false, false, "Stellar Wealth Management", "FutureEnergy Clean Energy Stock", null, -303 },
                    { -575, false, false, "Stellar Wealth Management", "Forestbrook Renewable Energy Fund", null, -303 },
                    { -574, false, false, "Alexander Sachs Group", "Sachs Industrial Fund", null, -303 },
                    { -523, false, false, "Pinnacle Ventures", "Pinnacle Ventures", -2, -300 },
                    { -514, false, false, "Oceanic Finance Solutions", "Oceanic Finance Bond Fund", -8, -302 },
                    { -493, false, false, "Stellar Wealth Management", "Stellar Wealth Management", -2, -300 },
                    { -482, false, false, "MindShares", "MindShares", -5, -300 },
                    { -442, false, false, "Alexander Sachs Group", "Alexander Sachs Balanced Fund", null, -303 },
                    { -432, false, true, "Stellar Wealth Management", "Government Money Fund", null, -317 },
                    { -416, false, true, "Spectrum Financial Group", "Spectrum Bank Deposit", null, -319 },
                    { -411, false, false, "E. Logan Asset Management", "Cygnus Sustainable Growth Fund", -9, -302 },
                    { -406, false, false, "Stellar Wealth Management", "Visionary Global Equity Fund", -8, -302 },
                    { -403, false, false, "Stellar Wealth Management", "Luminous Energy ETF", -8, -302 },
                    { -400, false, false, "Nebula Holdings", "NebulaTech Technology ETF", -8, -302 },
                    { -397, false, false, "Oceanic Finance Solutions", "StellarInvest Large-Cap Value Fund", -8, -302 },
                    { -392, false, false, "Mercury Capital Group", "Mercury Capital Small-Cap Growth Fund", -8, -302 },
                    { -325, false, false, "QuantumSoft Inc.", "QuantumSoft Inc.", -5, -300 },
                    { -315, false, false, "AlphaTech Corporation", "AlphaTech Corporation", -5, -300 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID", "Weight" },
                values: new object[,]
                {
                    { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0926m },
                    { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -493, 1m },
                    { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0841m },
                    { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.1161m },
                    { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.0626m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -761, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -760, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -748, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747, 0.9685m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -745, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -728, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -727, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0927m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 0.9664m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576, 0.9495m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 0.9888m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.9615m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -523, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514, 0.9931m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -482, 1m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411, 0.9909m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.2066m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403, 0.9896m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.9886m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392, 0.9937m },
                    { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -325, 1m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747, 0.0071m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.1217m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 0.0058m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.008m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514, 0.0031m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0634m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403, 0.0059m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.0052m },
                    { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.234m },
                    { -819, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0316m },
                    { -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.003m },
                    { -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.1609m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747, 0.0244m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.1375m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 0.0038m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.0042m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID", "Weight" },
                values: new object[,]
                {
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411, 0.0091m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0896m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403, 0.0031m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.0009m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.1567m },
                    { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392, 0.0063m },
                    { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0623m },
                    { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 0.0077m },
                    { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.0017m },
                    { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.0581m },
                    { -808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.0385m },
                    { -805, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0396m },
                    { -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 0.0003m },
                    { -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.0068m },
                    { -794, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0439m },
                    { -778, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.0014m },
                    { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0693m },
                    { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 0.0013m },
                    { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.01m },
                    { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403, 0.0014m },
                    { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.0706m },
                    { -743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0264m },
                    { -734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0202m },
                    { -718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0174m },
                    { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.1102m },
                    { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 0.0006m },
                    { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.1412m },
                    { -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0228m },
                    { -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.035m },
                    { -708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 0.0062m },
                    { -706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 0.0191m },
                    { -703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0215m },
                    { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514, 0.0038m },
                    { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.1745m },
                    { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 0.0022m },
                    { -699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0843m },
                    { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0779m },
                    { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0274m },
                    { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.1204m },
                    { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.1915m },
                    { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0266m },
                    { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.1603m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                columns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID", "Weight" },
                values: new object[,]
                {
                    { -674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.0178m },
                    { -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 0.0215m },
                    { -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 0.046m },
                    { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.0033m },
                    { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.3368m },
                    { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.0292m },
                    { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576, 0.0505m },
                    { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 0.0032m },
                    { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 0.1982m },
                    { -630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 0.0605m },
                    { -104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -432, 1m },
                    { -104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -416, 1m },
                    { -103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -758, 1m },
                    { -102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -748, 1m },
                    { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -745, 1m },
                    { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578, 1m },
                    { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -761, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -760, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -759, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -728, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -727, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -523, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -493, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -482, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -325, 1m },
                    { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -315, 1m }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1711, 63.56m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.8m, 56.75m, 58.79m, -761, null },
                    { -1710, 49.92m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.44m, 49.59m, 48.2m, -760, null },
                    { -1709, 64.08m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.27m, 53.4m, 59.32m, -760, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1708, 63.41m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.86m, 53.92m, 56.32m, -760, null },
                    { -1707, 47.09m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.79m, 52.5m, 47.96m, -760, null },
                    { -1706, 55.58m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.31m, 51.8m, 45.39m, -760, null },
                    { -1705, 51.72m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.74m, 45.95m, 47.03m, -760, null },
                    { -1704, 49.45m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.01m, 55.69m, 50.12m, -760, null },
                    { -1703, 54.61m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.33m, 56.48m, 56.12m, -760, null },
                    { -1702, 52.21m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.15m, 50.29m, 51.58m, -760, null },
                    { -1701, 49.97m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.47m, 48.76m, 48.42m, -760, null },
                    { -1700, 49.7m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.22m, 53.74m, 56.3m, -760, null },
                    { -1699, 49.9m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.36m, 42.46m, 53.78m, -760, null },
                    { -1698, 52.92m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.37m, 50.57m, 55.09m, -760, null },
                    { -1697, 48.19m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.37m, 49.47m, 51.54m, -760, null },
                    { -1696, 53.34m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.35m, 54.87m, 52.73m, -760, null },
                    { -1695, 54.98m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.67m, 54.97m, 49.37m, -760, null },
                    { -1694, 57.19m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.88m, 56.2m, 59.75m, -760, null },
                    { -1693, 56.69m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.59m, 57.53m, 60.39m, -760, null },
                    { -1692, 47.69m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.1m, 53.86m, 56.5m, -760, null },
                    { -1691, 51.33m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.92m, 51.93m, 54.99m, -760, null },
                    { -1690, 57.36m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.46m, 49.81m, 52.68m, -760, null },
                    { -1689, 53.38m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.4m, 56.07m, 55.16m, -760, null },
                    { -1688, 60.18m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.85m, 51.25m, 62.02m, -760, null },
                    { -1687, 55.86m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.48m, 56.88m, 56.96m, -760, null },
                    { -1686, 55.75m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.37m, 55.66m, 57.9m, -760, null },
                    { -1685, 51.06m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.73m, 53.62m, 56.18m, -760, null },
                    { -1684, 59.53m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.88m, 52.01m, 59.73m, -760, null },
                    { -1683, 55.03m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.74m, 57.67m, 51.22m, -760, null },
                    { -1682, 60.68m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.87m, 57.69m, 51.17m, -759, null },
                    { -1681, 63.02m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.29m, 56.2m, 67.13m, -759, null },
                    { -1680, 72.98m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.53m, 57.3m, 65.06m, -759, null },
                    { -1679, 56.25m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.46m, 55.82m, 65.22m, -759, null },
                    { -1678, 59.8m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.05m, 66.87m, 59.11m, -759, null },
                    { -1677, 57.11m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.21m, 67.18m, 66.65m, -759, null },
                    { -1676, 60.74m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.93m, 53.35m, 68.68m, -759, null },
                    { -1675, 54.57m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.08m, 59.95m, 64.05m, -759, null },
                    { -1674, 57.21m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.16m, 61.65m, 63.76m, -759, null },
                    { -1673, 69m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.47m, 56.2m, 44.79m, -759, null },
                    { -1672, 70.51m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.51m, 61.56m, 62.33m, -759, null },
                    { -1671, 61.28m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.17m, 64.6m, 59.33m, -759, null },
                    { -1670, 57.36m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.21m, 55.81m, 60.13m, -759, null },
                    { -1669, 60.18m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.29m, 55.52m, 58.36m, -759, null },
                    { -1668, 72.14m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.97m, 60.22m, 66.44m, -759, null },
                    { -1667, 63.55m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.21m, 60.4m, 56.49m, -759, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1666, 69.04m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.44m, 57.7m, 59.39m, -759, null },
                    { -1665, 61.26m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.26m, 56.17m, 65.16m, -759, null },
                    { -1664, 57.08m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.11m, 62.5m, 61.09m, -759, null },
                    { -1663, 55.92m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.27m, 48.39m, 54.94m, -759, null },
                    { -1662, 57.55m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.17m, 61.28m, 58.34m, -759, null },
                    { -1661, 64.79m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.46m, 57.92m, 55.18m, -759, null },
                    { -1660, 56.87m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.06m, 63.35m, 52.66m, -759, null },
                    { -1659, 64.38m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.7m, 55.96m, 53.44m, -759, null },
                    { -1658, 61.7m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.5m, 59.83m, 58.36m, -759, null },
                    { -1657, 63.17m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.01m, 58.52m, 55.91m, -759, null },
                    { -1656, 51.83m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.99m, 53.6m, 51.78m, -759, null },
                    { -1655, 62.39m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.86m, 63.02m, 54.76m, -759, null },
                    { -1654, 55.3m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.08m, 62.95m, 61.23m, -759, null },
                    { -1653, 63.39m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.2m, 53.55m, 62.89m, -759, null },
                    { -1652, 59.03m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.54m, 64.43m, 62.16m, -759, null },
                    { -1651, 62.64m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.64m, 56.32m, 61.83m, -759, null },
                    { -1650, 59.62m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.46m, 63.76m, 68.79m, -759, null },
                    { -1649, 63.24m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.07m, 65.42m, 65.48m, -759, null },
                    { -1648, 66.44m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.87m, 48.88m, 66.23m, -759, null },
                    { -1647, 62.54m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.01m, 66.77m, 62.69m, -759, null },
                    { -1646, 76.98m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.5m, 49.37m, 71.19m, -759, null },
                    { -1645, 62.1m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.1m, 69.24m, 67.12m, -759, null },
                    { -1644, 61.49m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.54m, 59.19m, 63.9m, -759, null },
                    { -1643, 62.9m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.91m, 64.8m, 67.94m, -759, null },
                    { -1642, 76.85m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.17m, 70.96m, 67.41m, -759, null },
                    { -1641, 61.28m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.49m, 68.82m, 69.57m, -759, null },
                    { -1640, 64.57m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.53m, 62.44m, 63.35m, -759, null },
                    { -1639, 58.29m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.41m, 62m, 63.48m, -759, null },
                    { -1638, 67.54m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.15m, 64.02m, 65.84m, -759, null },
                    { -1637, 64.76m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.67m, 73.66m, 68.5m, -759, null },
                    { -1636, 70.05m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.68m, 68.37m, 69.06m, -759, null },
                    { -1635, 66.77m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.96m, 66.79m, 62.84m, -759, null },
                    { -1634, 75.31m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.97m, 62.64m, 70.15m, -759, null },
                    { -1633, 62.81m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.89m, 69.41m, 72.97m, -759, null },
                    { -1632, 71.05m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.24m, 65.47m, 67.03m, -759, null },
                    { -1631, 71.3m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.2m, 69.51m, 70.73m, -759, null },
                    { -1630, 66.25m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.19m, 61.62m, 63.2m, -759, null },
                    { -1629, 67.65m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.03m, 63.75m, 70.83m, -759, null },
                    { -1628, 62.2m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.25m, 81.02m, 70.01m, -759, null },
                    { -1627, 64.25m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.15m, 69.84m, 64.72m, -759, null },
                    { -1626, 67.87m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.66m, 60.96m, 53.76m, -759, null },
                    { -1625, 69.99m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.38m, 70.11m, 74.1m, -759, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1624, 63.5m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.98m, 57.82m, 61.06m, -759, null },
                    { -1623, 70.92m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.77m, 55.51m, 69.57m, -759, null },
                    { -1622, 72.55m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.32m, 71.01m, 69.3m, -759, null },
                    { -1621, 60.65m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.19m, 62.08m, 62.56m, -759, null },
                    { -1620, 64.34m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.97m, 54.19m, 57.92m, -759, null },
                    { -1619, 68.14m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.96m, 61.5m, 61.85m, -759, null },
                    { -1618, 0.1m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1m, 0.09m, 0.1m, -748, null },
                    { -1617, 0.1m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.09m, 0.09m, 0.09m, -748, null },
                    { -1616, 0.13m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.11m, 0.12m, 0.12m, -748, null },
                    { -1615, 0.13m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.11m, 0.13m, 0.13m, -748, null },
                    { -1614, 0.08m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, -748, null },
                    { -1613, 0.05m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.05m, 0.04m, 0.05m, -748, null },
                    { -1612, 0.2m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.21m, 0.1m, 0.09m, -748, null },
                    { -1611, 0.11m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.12m, 0.09m, 0.1m, -748, null },
                    { -1610, 0.17m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.19m, 0.19m, 0.18m, -748, null },
                    { -1609, 0.13m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.16m, 0.15m, 0.15m, -748, null },
                    { -1608, 0.14m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.15m, 0.1m, 0.14m, -748, null },
                    { -1607, 0.11m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.11m, 0.11m, 0.11m, -748, null },
                    { -1606, 0.19m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 0.21m, 0.2m, -748, null },
                    { -1605, 0.15m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.15m, 0.15m, 0.14m, -748, null },
                    { -1604, 0.14m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.13m, 0.15m, 0.15m, -748, null },
                    { -1603, 0.18m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 0.21m, 0.19m, -748, null },
                    { -1602, 0.15m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.14m, 0.15m, 0.16m, -748, null },
                    { -1601, 0.2m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.21m, 0.18m, 0.19m, -748, null },
                    { -1600, 0.22m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.22m, 0.18m, 0.18m, -748, null },
                    { -1599, 0.32m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.28m, 0.32m, 0.3m, -748, null },
                    { -1598, 0.28m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.22m, 0.25m, 0.26m, -748, null },
                    { -1597, 0.33m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.34m, 0.28m, 0.42m, -748, null },
                    { -1596, 0.35m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.31m, 0.3m, 0.34m, -748, null },
                    { -1595, 0.18m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2m, 0.21m, 0.2m, -748, null },
                    { -1594, 0.31m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.29m, 0.31m, 0.34m, -748, null },
                    { -1593, 0.24m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.24m, 0.21m, 0.22m, -748, null },
                    { -1592, 0.29m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.33m, 0.3m, 0.32m, -748, null },
                    { -1591, 0.28m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.26m, 0.24m, 0.27m, -748, null },
                    { -1590, 0.23m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.33m, 0.26m, 0.3m, -748, null },
                    { -1589, 0.21m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.31m, 0.23m, 0.37m, -748, null },
                    { -1588, 0.15m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.14m, 0.16m, 0.16m, -748, null },
                    { -1587, 0.15m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.16m, 0.15m, 0.14m, -748, null },
                    { -1586, 0.57m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.47m, 0.35m, 0.31m, -748, null },
                    { -1585, 0.41m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.43m, 0.31m, 0.36m, -748, null },
                    { -1584, 0.26m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.32m, 0.23m, 0.31m, -748, null },
                    { -1583, 0.26m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.28m, 0.21m, 0.22m, -748, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1582, 0.32m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.26m, 0.29m, 0.29m, -748, null },
                    { -1581, 0.26m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.28m, 0.24m, 0.27m, -748, null },
                    { -1580, 0.29m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.29m, 0.13m, 0.14m, -748, null },
                    { -1579, 0.33m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.3m, 0.31m, 0.29m, -748, null },
                    { -1578, 0.41m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.31m, 0.21m, 0.23m, -748, null },
                    { -1577, 37.73m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.65m, 30.34m, 33.48m, -747, null },
                    { -1576, 36.55m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.06m, 30.89m, 30.9m, -747, null },
                    { -1575, 32.29m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.44m, 29.38m, 35.84m, -747, null },
                    { -1574, 33.31m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.78m, 30.16m, 36.91m, -747, null },
                    { -1573, 32.68m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.25m, 32.52m, 28.01m, -747, null },
                    { -1572, 30.54m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.04m, 33.29m, 30.37m, -747, null },
                    { -1571, 31.28m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.64m, 31.56m, 30.04m, -747, null },
                    { -1570, 29.4m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.14m, 35.44m, 31.94m, -747, null },
                    { -1569, 36.53m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.59m, 33.89m, 34.24m, -747, null },
                    { -1568, 33.78m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.84m, 34.45m, 35.17m, -747, null },
                    { -1567, 29.68m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.49m, 30.23m, 31.1m, -747, null },
                    { -1566, 32.24m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.57m, 28.74m, 39.29m, -747, null },
                    { -1565, 32.76m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.17m, 34.65m, 29.21m, -747, null },
                    { -1564, 31.78m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.48m, 30.71m, 33.34m, -747, null },
                    { -1563, 32.35m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.06m, 34.95m, 29.08m, -747, null },
                    { -1562, 30.65m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.83m, 30.05m, 27.22m, -747, null },
                    { -1561, 29.53m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.4m, 33.21m, 27.14m, -747, null },
                    { -1560, 30.5m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.54m, 26.44m, 28.97m, -747, null },
                    { -1559, 30.48m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.08m, 32.34m, 35.28m, -747, null },
                    { -1558, 27.13m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.1m, 29.84m, 30.24m, -747, null },
                    { -1557, 30.37m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.77m, 27.23m, 27.57m, -747, null },
                    { -1556, 29.75m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.97m, 32.32m, 33.52m, -747, null },
                    { -1555, 34.46m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.6m, 32.57m, 32.85m, -747, null },
                    { -1554, 29.02m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.2m, 30.71m, 30.33m, -747, null },
                    { -1553, 30.68m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.13m, 29.18m, 32.41m, -747, null },
                    { -1552, 31.99m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.21m, 30.81m, 29.73m, -747, null },
                    { -1551, 31.89m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.12m, 30.45m, 31.95m, -747, null },
                    { -1550, 29.07m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.11m, 35.57m, 29.45m, -747, null },
                    { -1549, 33.69m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.72m, 33.42m, 29.05m, -747, null },
                    { -1548, 29.82m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.94m, 31.51m, 32.36m, -747, null },
                    { -1547, 38.78m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.04m, 32.17m, 36.49m, -747, null },
                    { -1546, 32.57m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.89m, 30.97m, 36.3m, -747, null },
                    { -1545, 32.18m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.84m, 37.53m, 34.97m, -747, null },
                    { -1544, 34.37m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.64m, 37.88m, 34.65m, -747, null },
                    { -1543, 38.25m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.66m, 30.73m, 35.82m, -747, null },
                    { -1542, 33.83m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.81m, 33.48m, 38.59m, -747, null },
                    { -1541, 40.78m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.34m, 34.79m, 37.9m, -747, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1540, 38.98m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.13m, 34.63m, 35.83m, -747, null },
                    { -1539, 41.52m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.38m, 35.29m, 33.68m, -747, null },
                    { -1538, 36.33m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.55m, 29.98m, 36.33m, -747, null },
                    { -1537, 35.88m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.31m, 33.44m, 38.49m, -747, null },
                    { -1536, 34.07m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.37m, 36.89m, 38.3m, -747, null },
                    { -1535, 30.27m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.54m, 34.71m, 40.27m, -747, null },
                    { -1534, 35m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.81m, 35.95m, 41.09m, -747, null },
                    { -1533, 40.75m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.68m, 34.97m, 34.43m, -747, null },
                    { -1532, 36.51m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.89m, 37.19m, 38.74m, -747, null },
                    { -1531, 36.06m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.79m, 35.28m, 35.48m, -747, null },
                    { -1530, 33.88m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.36m, 37m, 37.1m, -747, null },
                    { -1529, 41.97m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 35m, 35.06m, 38.72m, -747, null },
                    { -1528, 31.03m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.38m, 36.17m, 37.38m, -747, null },
                    { -1527, 36.92m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.9m, 39.46m, 39.47m, -747, null },
                    { -1526, 40.03m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.03m, 33.65m, 36.96m, -747, null },
                    { -1525, 35.96m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.82m, 39.99m, 34.52m, -747, null },
                    { -1524, 37.72m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.16m, 36.61m, 37.28m, -747, null },
                    { -1523, 39.63m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.49m, 34.02m, 38.3m, -747, null },
                    { -1522, 36.73m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.98m, 36.11m, 36.35m, -747, null },
                    { -1521, 34.99m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.69m, 35.17m, 33.36m, -747, null },
                    { -1520, 35.76m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.17m, 35.82m, 36.83m, -747, null },
                    { -1519, 30.75m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.67m, 37.41m, 37.42m, -747, null },
                    { -1518, 38.14m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.44m, 37.4m, 34.92m, -747, null },
                    { -1517, 37.93m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.1m, 40.25m, 36.04m, -747, null },
                    { -1516, 32.58m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.21m, 39.35m, 37.62m, -747, null },
                    { -1515, 36.73m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.07m, 35.24m, 34.31m, -747, null },
                    { -1514, 37.7m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.55m, 36.77m, 36.91m, -747, null },
                    { -1513, 30.89m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.34m, 39.47m, 32.96m, -747, null },
                    { -1512, 32.7m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.85m, 30.68m, 36.99m, -747, null },
                    { -1511, 36.73m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.72m, 34.97m, 33.13m, -747, null },
                    { -1510, 39.03m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.77m, 36.71m, 38.3m, -747, null },
                    { -1509, 39.28m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.24m, 35.37m, 37.08m, -747, null },
                    { -1508, 39.28m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.5m, 32.73m, 36.84m, -747, null },
                    { -1507, 33.67m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.95m, 36.8m, 37.44m, -747, null },
                    { -1506, 37.04m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.36m, 37.77m, 37.6m, -747, null },
                    { -1505, 38.52m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.27m, 38.83m, 35.68m, -747, null },
                    { -1504, 32.87m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.88m, 37.73m, 34.58m, -747, null },
                    { -1503, 33.44m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.35m, 31.88m, 35.51m, -747, null },
                    { -1502, 40.45m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.54m, 33.19m, 30.58m, -747, null },
                    { -1501, 143.57m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 129.35m, 128.48m, 128.41m, -745, null },
                    { -1500, 118.14m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 132.37m, 127.82m, 134.31m, -745, null },
                    { -1499, 119.77m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 139.96m, 123.35m, 128.04m, -745, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1498, 144.18m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.62m, 124.87m, 131.21m, -745, null },
                    { -1497, 123.38m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.06m, 134.18m, 148.02m, -745, null },
                    { -1496, 126.85m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 147.53m, 138.55m, 147.04m, -745, null },
                    { -1495, 153.54m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 148.97m, 138.24m, 114.56m, -745, null },
                    { -1494, 126.64m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.46m, 123.32m, 132.42m, -745, null },
                    { -1493, 118.62m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.67m, 120.23m, 131.23m, -745, null },
                    { -1492, 130.89m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.56m, 125.44m, 143.95m, -745, null },
                    { -1491, 126.8m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.67m, 146.89m, 128.88m, -745, null },
                    { -1490, 131.63m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 126.19m, 117.12m, 122.89m, -745, null },
                    { -1489, 135.16m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.75m, 148.81m, 134.73m, -745, null },
                    { -1488, 121.21m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.4m, 113.81m, 131.1m, -745, null },
                    { -1487, 133.67m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.83m, 149.37m, 131.86m, -745, null },
                    { -1486, 142.17m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.81m, 130.53m, 120.65m, -745, null },
                    { -1485, 124.67m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.13m, 125.02m, 125.94m, -745, null },
                    { -1484, 115.92m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 127.65m, 140.52m, 106.96m, -745, null },
                    { -1483, 132.71m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 132.44m, 115.32m, 120.66m, -745, null },
                    { -1482, 131.27m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 126.28m, 113.85m, 133.03m, -745, null },
                    { -1481, 109.05m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 133.74m, 131.99m, 129.9m, -745, null },
                    { -1480, 139.66m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.99m, 123.29m, 127.02m, -745, null },
                    { -1479, 109m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.96m, 120.35m, 130.42m, -745, null },
                    { -1478, 117.23m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.35m, 128.16m, 127.55m, -745, null },
                    { -1477, 117.88m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.85m, 118.72m, 137.82m, -745, null },
                    { -1476, 133.98m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 118.63m, 124.5m, 142.72m, -745, null },
                    { -1475, 131.56m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.56m, 116.32m, 114.69m, -745, null },
                    { -1474, 141.16m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 109.92m, 138.62m, 123.24m, -745, null },
                    { -1473, 128.39m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.36m, 135.57m, 121.01m, -745, null },
                    { -1472, 132.35m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.1m, 127.09m, 123.74m, -745, null },
                    { -1471, 112.97m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 109.59m, 112.01m, 127.83m, -745, null },
                    { -1470, 127.29m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 136.13m, 117.18m, 136.36m, -745, null },
                    { -1469, 130.67m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.48m, 123.84m, 137.72m, -745, null },
                    { -1468, 118.2m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.64m, 131.57m, 136.05m, -745, null },
                    { -1467, 111.84m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.85m, 117.83m, 138.28m, -745, null },
                    { -1466, 122.52m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.45m, 141.02m, 146.32m, -745, null },
                    { -1465, 131.68m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.6m, 123.65m, 112.55m, -745, null },
                    { -1464, 130.56m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.33m, 128.01m, 123.68m, -745, null },
                    { -1463, 132.53m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.81m, 141.19m, 129.64m, -745, null },
                    { -1462, 123.24m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.18m, 123.24m, 114.27m, -745, null },
                    { -1461, 120.23m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.59m, 132.92m, 132.25m, -745, null },
                    { -1460, 119.69m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.3m, 135.62m, 130.65m, -745, null },
                    { -1459, 127.03m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.55m, 120.53m, 134.43m, -745, null },
                    { -1458, 143.95m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 118.88m, 134.66m, 124.44m, -745, null },
                    { -1457, 126.15m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.37m, 121.86m, 136.79m, -745, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1456, 132.56m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 136.92m, 109.76m, 143.61m, -745, null },
                    { -1455, 121.91m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 140.25m, 151.59m, 104.09m, -745, null },
                    { -1454, 144.79m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.67m, 139.78m, 116.8m, -745, null },
                    { -1453, 133.6m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.54m, 131.97m, 131.21m, -745, null },
                    { -1452, 124.31m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.84m, 128.94m, 121.65m, -745, null },
                    { -1451, 129.91m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.66m, 134.68m, 129.98m, -745, null },
                    { -1450, 139.27m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.02m, 118.63m, 116.54m, -745, null },
                    { -1449, 141.41m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.13m, 128m, 129.7m, -745, null },
                    { -1448, 128.85m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.26m, 121.23m, 139.63m, -745, null },
                    { -1447, 142.07m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.38m, 127.54m, 131.16m, -745, null },
                    { -1446, 147.21m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 139.12m, 135.04m, 124.13m, -745, null },
                    { -1445, 124.26m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 140.11m, 140.03m, 123.17m, -745, null },
                    { -1444, 140.29m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.36m, 124.13m, 130.24m, -745, null },
                    { -1443, 113.14m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 128.6m, 137.35m, 139.69m, -745, null },
                    { -1442, 141.46m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.06m, 121.01m, 130.51m, -745, null },
                    { -1441, 141.12m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 147.23m, 122.36m, 134.6m, -745, null },
                    { -1440, 136.52m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 138.77m, 140.61m, 135.09m, -745, null },
                    { -1439, 153.54m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.63m, 135.14m, 139.75m, -745, null },
                    { -1438, 146.13m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 147.46m, 127.74m, 141.37m, -745, null },
                    { -1437, 146.14m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.83m, 127.38m, 150.76m, -745, null },
                    { -1436, 123.18m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 155.14m, 126.63m, 139.24m, -745, null },
                    { -1435, 134.33m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 148.34m, 137.27m, 134.17m, -745, null },
                    { -1434, 138.22m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.09m, 135.23m, 142.59m, -745, null },
                    { -1433, 141.91m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 129.84m, 120.92m, 141.68m, -745, null },
                    { -1432, 153.69m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.24m, 114.72m, 146.54m, -745, null },
                    { -1431, 135.63m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.07m, 136.79m, 139.12m, -745, null },
                    { -1430, 121.26m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.87m, 134.27m, 129.54m, -745, null },
                    { -1429, 147.16m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 160.04m, 143.77m, 139.71m, -745, null },
                    { -1428, 112.25m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.66m, 132.87m, 134.05m, -745, null },
                    { -1427, 139.13m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 133.82m, 117.13m, 150.95m, -745, null },
                    { -1426, 137.07m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.97m, 139.46m, 162.76m, -745, null },
                    { -1425, 4.27m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.51m, 4.27m, 4.71m, -728, null },
                    { -1424, 4.94m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.61m, 4.51m, 4.33m, -728, null },
                    { -1423, 4.52m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.5m, 4.01m, 4.54m, -728, null },
                    { -1422, 4.51m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.41m, 4.13m, 4.67m, -728, null },
                    { -1421, 4.14m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.14m, 4.2m, 3.79m, -728, null },
                    { -1420, 4.28m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.12m, 3.48m, 4m, -728, null },
                    { -1419, 3.95m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.66m, 4.55m, 4.39m, -728, null },
                    { -1418, 5m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.3m, 4.01m, 4.22m, -728, null },
                    { -1417, 4.51m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.39m, 4.83m, 4.74m, -728, null },
                    { -1416, 4.46m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.13m, 4.57m, 3.9m, -728, null },
                    { -1415, 4.17m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.76m, 3.79m, 4.27m, -728, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1414, 4.58m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.51m, 4.49m, 5.37m, -728, null },
                    { -1413, 4.48m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.48m, 3.83m, 4.6m, -728, null },
                    { -1412, 4.54m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.38m, 4.66m, 5m, -728, null },
                    { -1411, 4.98m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.63m, 5.49m, 4.97m, -728, null },
                    { -1410, 6.84m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.4m, 5.86m, 6.9m, -728, null },
                    { -1409, 6.9m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.45m, 6.17m, 5.34m, -728, null },
                    { -1408, 5.81m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.76m, 5.15m, 5.97m, -728, null },
                    { -1407, 5.73m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.62m, 6.21m, 5.55m, -728, null },
                    { -1406, 6.25m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.48m, 6.1m, 5.76m, -728, null },
                    { -1405, 6.3m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.34m, 6.41m, 5.48m, -728, null },
                    { -1404, 5.79m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.55m, 5.55m, 6.38m, -728, null },
                    { -1403, 5.52m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.25m, 6.62m, 6.32m, -728, null },
                    { -1402, 6.25m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.27m, 5.27m, 5.77m, -728, null },
                    { -1401, 6.55m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.27m, 6.06m, 6.5m, -728, null },
                    { -1400, 6.89m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.21m, 6.42m, 6.2m, -728, null },
                    { -1399, 6.42m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.46m, 5.59m, 6.11m, -728, null },
                    { -1398, 6.38m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.91m, 5.16m, 5.56m, -728, null },
                    { -1397, 5.57m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.23m, 5.07m, 5.38m, -728, null },
                    { -1396, 6.72m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.77m, 5.86m, 6.54m, -728, null },
                    { -1395, 6.46m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.72m, 6.33m, 7.86m, -728, null },
                    { -1394, 6.65m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.51m, 6.45m, 7.09m, -728, null },
                    { -1393, 6.24m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.36m, 6.74m, 6.48m, -728, null },
                    { -1392, 7.49m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.06m, 6.49m, 6.74m, -728, null },
                    { -1391, 5.76m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.56m, 6.03m, 5.6m, -728, null },
                    { -1390, 6.08m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.42m, 5.58m, 6.83m, -728, null },
                    { -1389, 5.82m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.95m, 6.45m, 6.57m, -728, null },
                    { -1388, 6.07m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.83m, 7.03m, 6.03m, -728, null },
                    { -1387, 6.55m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.55m, 6.07m, 5.83m, -728, null },
                    { -1386, 5.9m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.99m, 5.73m, 5.59m, -728, null },
                    { -1385, 6.07m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.72m, 5.49m, 5.43m, -728, null },
                    { -1384, 6.49m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.96m, 5.8m, 5.99m, -728, null },
                    { -1383, 5.33m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.4m, 6.58m, 6.11m, -728, null },
                    { -1382, 6.83m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.45m, 5.68m, 6.73m, -728, null },
                    { -1381, 6.24m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.12m, 6.82m, 6.49m, -728, null },
                    { -1380, 7.21m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.33m, 6.07m, 5.44m, -728, null },
                    { -1379, 6.11m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.3m, 5.77m, 6.26m, -728, null },
                    { -1378, 5.78m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.78m, 6.18m, 6.15m, -728, null },
                    { -1377, 6.39m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.66m, 5.18m, 6.37m, -728, null },
                    { -1376, 5.27m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.94m, 5.59m, 5.45m, -728, null },
                    { -1375, 6.06m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.11m, 5.41m, 6.21m, -728, null },
                    { -1374, 5.65m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.19m, 6.49m, 6.52m, -728, null },
                    { -1373, 5.95m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.76m, 5.33m, 6.88m, -728, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1372, 5.71m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.97m, 5.32m, 6.12m, -728, null },
                    { -1371, 6.26m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.34m, 5.99m, 5.44m, -728, null },
                    { -1370, 5.98m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.01m, 5.08m, 5.68m, -728, null },
                    { -1369, 5.48m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.2m, 5.55m, 5.06m, -728, null },
                    { -1368, 5.36m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.59m, 5.05m, 5.43m, -728, null },
                    { -1367, 5.24m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.9m, 5.27m, 5.22m, -728, null },
                    { -1366, 4.95m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5m, 5.36m, 5.38m, -728, null },
                    { -1365, 5.43m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.03m, 4.6m, 4.91m, -728, null },
                    { -1364, 5.05m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m, 5.1m, 5.07m, -728, null },
                    { -1363, 4.55m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.48m, 5.45m, 5.63m, -728, null },
                    { -1362, 5.32m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.65m, 4.04m, 4.72m, -728, null },
                    { -1361, 4.66m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.12m, 4.44m, 4.8m, -728, null },
                    { -1360, 4.61m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.75m, 4.59m, 5.5m, -728, null },
                    { -1359, 5.5m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.07m, 4.81m, 5.77m, -728, null },
                    { -1358, 5.79m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.72m, 4.68m, 5.16m, -728, null },
                    { -1357, 5.18m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.19m, 5.08m, 5.45m, -728, null },
                    { -1356, 4.7m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.67m, 4.86m, 5.36m, -728, null },
                    { -1355, 4.7m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.8m, 4.74m, 5.11m, -728, null },
                    { -1354, 5.3m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.22m, 4.52m, 4.62m, -728, null },
                    { -1353, 4.77m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.14m, 4.22m, 4.63m, -728, null },
                    { -1352, 4.59m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.55m, 4.11m, 4.95m, -728, null },
                    { -1351, 4.04m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.68m, 4.04m, 4.5m, -728, null },
                    { -1350, 4.58m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.93m, 4.43m, 5.32m, -728, null },
                    { -1349, 3.72m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.15m, 3.94m, 4.29m, -727, null },
                    { -1348, 3.91m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.11m, 3.66m, 4m, -727, null },
                    { -1347, 4.14m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.15m, 4.21m, 3.9m, -727, null },
                    { -1346, 4.19m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.95m, 3.65m, 3.94m, -727, null },
                    { -1345, 4.38m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.84m, 4.33m, 3.74m, -727, null },
                    { -1344, 4m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.16m, 3.56m, 4.48m, -727, null },
                    { -1343, 3.69m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.76m, 3.45m, 3.87m, -727, null },
                    { -1342, 3.79m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.6m, 3.78m, 4.09m, -727, null },
                    { -1341, 4.21m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.51m, 3.98m, 4.17m, -727, null },
                    { -1340, 4.05m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.9m, 3.33m, 3.61m, -727, null },
                    { -1339, 3.68m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 3.52m, 3.53m, -727, null },
                    { -1338, 3.72m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.97m, 3.64m, 4.02m, -727, null },
                    { -1337, 3.61m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.41m, 3.78m, 4.07m, -727, null },
                    { -1336, 3.97m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 3.93m, 3.93m, -727, null },
                    { -1335, 3.12m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.22m, 4.26m, 4.2m, -727, null },
                    { -1334, 3.7m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.02m, 3.82m, 3.95m, -727, null },
                    { -1333, 3.98m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.35m, 3.68m, 3.98m, -727, null },
                    { -1332, 4.28m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.78m, 3.63m, 3.96m, -727, null },
                    { -1331, 3.3m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.46m, 3.81m, 3.83m, -727, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1330, 4.06m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.21m, 3.62m, 3.9m, -727, null },
                    { -1329, 3.44m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.85m, 3.59m, 3.8m, -727, null },
                    { -1328, 3.9m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.96m, 4.15m, 4.01m, -727, null },
                    { -1327, 4.76m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.21m, 4.12m, 4.17m, -727, null },
                    { -1326, 3.83m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.02m, 4.02m, 4.15m, -727, null },
                    { -1325, 3.7m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.34m, 4.09m, 3.7m, -727, null },
                    { -1324, 4.11m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, 3.53m, 3.8m, -727, null },
                    { -1323, 3.68m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.45m, 3.72m, 3.94m, -727, null },
                    { -1322, 3.93m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.8m, 3.86m, 4.47m, -727, null },
                    { -1321, 4.29m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.43m, 3.34m, 3.64m, -727, null },
                    { -1320, 3.99m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.34m, 4.01m, 4.02m, -727, null },
                    { -1319, 4.35m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.18m, 3.83m, 4.04m, -727, null },
                    { -1318, 4.52m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.06m, 4.37m, 3.83m, -727, null },
                    { -1317, 4.4m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.85m, 4.21m, 4.32m, -727, null },
                    { -1316, 4.16m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.71m, 4.64m, 4.38m, -727, null },
                    { -1315, 4.69m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.97m, 3.95m, 3.82m, -727, null },
                    { -1314, 4.38m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.96m, 3.43m, 4.62m, -727, null },
                    { -1313, 4.27m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.98m, 4.15m, 3.97m, -727, null },
                    { -1312, 4.21m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.37m, 5.25m, 4.83m, -727, null },
                    { -1311, 4.89m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.55m, 3.51m, 4.76m, -727, null },
                    { -1310, 4.67m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.21m, 4.26m, 4.29m, -727, null },
                    { -1309, 3.98m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.15m, 4.39m, 4.95m, -727, null },
                    { -1308, 4.8m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.79m, 4.68m, 4.83m, -727, null },
                    { -1307, 5.03m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.68m, 4.84m, 4.9m, -727, null },
                    { -1306, 5.59m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.38m, 4.39m, 5.48m, -727, null },
                    { -1305, 5.1m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.65m, 4.69m, 5.34m, -727, null },
                    { -1304, 5.63m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.2m, 4.73m, 5.2m, -727, null },
                    { -1303, 4.86m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.01m, 4.24m, 4.02m, -727, null },
                    { -1302, 5.09m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.9m, 4.99m, 5.12m, -727, null },
                    { -1301, 5.4m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.04m, 4.08m, 4.23m, -727, null },
                    { -1300, 4.47m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.69m, 4.75m, 4.28m, -727, null },
                    { -1299, 5.32m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.48m, 4.73m, 4.26m, -727, null },
                    { -1298, 5.34m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.86m, 4.62m, 5.1m, -727, null },
                    { -1297, 5.53m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.83m, 4.92m, 5.82m, -727, null },
                    { -1296, 5.08m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.13m, 4.83m, 4.69m, -727, null },
                    { -1295, 5.2m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.39m, 4.86m, 5.18m, -727, null },
                    { -1294, 5.42m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.86m, 4.87m, 4.7m, -727, null },
                    { -1293, 4.45m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.4m, 4.59m, 5.01m, -727, null },
                    { -1292, 4.8m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.44m, 4.32m, 5.15m, -727, null },
                    { -1291, 5.1m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.37m, 5.28m, 4.88m, -727, null },
                    { -1290, 4.66m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.82m, 4.29m, 5.05m, -727, null },
                    { -1289, 4.76m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.68m, 4.3m, 5.32m, -727, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1288, 4.8m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.84m, 4.5m, 5.11m, -727, null },
                    { -1287, 4.67m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.59m, 4.46m, 5.1m, -727, null },
                    { -1286, 4.72m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.84m, 4.91m, 5.38m, -727, null },
                    { -1285, 4.89m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.78m, 4.44m, 4.39m, -727, null },
                    { -1284, 5.22m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.31m, 5.7m, 5.82m, -727, null },
                    { -1283, 5.91m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.36m, 5.39m, 4.92m, -727, null },
                    { -1282, 5.7m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.49m, 4.96m, 4.61m, -727, null },
                    { -1281, 5.06m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.85m, 4.64m, 4.75m, -727, null },
                    { -1280, 3.86m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.84m, 4.42m, 4.47m, -727, null },
                    { -1279, 4.69m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.45m, 4.22m, 4.26m, -727, null },
                    { -1278, 4.32m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.51m, 3.9m, 4.45m, -727, null },
                    { -1277, 3.67m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.35m, 3.88m, 4m, -727, null },
                    { -1276, 4.35m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.36m, 4.09m, 4.17m, -727, null },
                    { -1275, 4.04m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.71m, 3.75m, 4.13m, -727, null },
                    { -1274, 4.2m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.65m, 4.02m, 3.17m, -727, null },
                    { -1273, 54.71m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.13m, 43.97m, 50.45m, -578, null },
                    { -1272, 48.49m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.06m, 51.09m, 52.39m, -578, null },
                    { -1271, 50.22m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.31m, 46.47m, 48.72m, -578, null },
                    { -1270, 51.75m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.69m, 50.8m, 51.57m, -578, null },
                    { -1269, 53.14m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.11m, 49.6m, 51.59m, -578, null },
                    { -1268, 56.08m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.17m, 51.66m, 61.82m, -578, null },
                    { -1267, 49.81m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.53m, 48.42m, 45.98m, -578, null },
                    { -1266, 56.78m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.71m, 47.91m, 48.04m, -578, null },
                    { -1265, 53.23m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.11m, 55.4m, 46m, -578, null },
                    { -1264, 55.38m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.74m, 55.18m, 53.78m, -578, null },
                    { -1263, 59.23m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.28m, 58.96m, 56.14m, -578, null },
                    { -1262, 47.21m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.34m, 60.25m, 53.77m, -578, null },
                    { -1261, 55.63m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.11m, 53.25m, 56.39m, -578, null },
                    { -1260, 54.72m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.94m, 52.07m, 53.05m, -578, null },
                    { -1259, 50.01m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.26m, 55.14m, 53.76m, -578, null },
                    { -1258, 52.79m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.16m, 53.6m, 52.43m, -578, null },
                    { -1257, 47.51m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.51m, 65.15m, 48.84m, -578, null },
                    { -1256, 56.75m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.89m, 58.34m, 54.03m, -578, null },
                    { -1255, 55.39m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.88m, 61.37m, 55.63m, -578, null },
                    { -1254, 52.93m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.61m, 45.98m, 53.61m, -578, null },
                    { -1253, 55.81m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.86m, 56.79m, 59.64m, -578, null },
                    { -1252, 54.23m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.47m, 59.89m, 56.36m, -578, null },
                    { -1251, 62.76m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.64m, 61.98m, 57.73m, -578, null },
                    { -1250, 60.75m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.48m, 53.99m, 59.02m, -578, null },
                    { -1249, 55.25m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.26m, 50.37m, 53.2m, -578, null },
                    { -1248, 61.14m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.55m, 56.96m, 56.22m, -578, null },
                    { -1247, 52.23m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.47m, 51.12m, 55.31m, -578, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1246, 48.44m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.91m, 49.6m, 51.41m, -578, null },
                    { -1245, 50.08m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.29m, 57.04m, 52.94m, -578, null },
                    { -1244, 49.06m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.23m, 58.64m, 53.24m, -578, null },
                    { -1243, 49.53m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.14m, 59.83m, 58.86m, -578, null },
                    { -1242, 57.15m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.89m, 56.68m, 55.01m, -578, null },
                    { -1241, 53.85m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.13m, 53.59m, 50.57m, -578, null },
                    { -1240, 50.32m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.89m, 53.28m, 45.45m, -578, null },
                    { -1239, 49.53m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.48m, 52.04m, 54.36m, -578, null },
                    { -1238, 51.81m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.86m, 57.89m, 56.75m, -578, null },
                    { -1237, 56.04m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 58m, 52.78m, 50.84m, -578, null },
                    { -1236, 63.95m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.19m, 53.51m, 50.47m, -578, null },
                    { -1235, 51.98m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.24m, 46.08m, 51.4m, -578, null },
                    { -1234, 48.69m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.4m, 56.05m, 58.19m, -578, null },
                    { -1233, 52.87m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.01m, 64.78m, 61.21m, -578, null },
                    { -1232, 59.99m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.51m, 61.26m, 47.82m, -578, null },
                    { -1231, 50.58m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.81m, 55.79m, 58.68m, -578, null },
                    { -1230, 54.77m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.82m, 58.01m, 49.19m, -578, null },
                    { -1229, 51.74m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.64m, 53.51m, 58.09m, -578, null },
                    { -1228, 49.37m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.02m, 47.4m, 52.04m, -578, null },
                    { -1227, 59.04m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.88m, 58.4m, 54.71m, -578, null },
                    { -1226, 51.96m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.14m, 47.56m, 45.86m, -578, null },
                    { -1225, 48.8m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.67m, 57.94m, 50m, -578, null },
                    { -1224, 44.3m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.46m, 47.03m, 56.12m, -578, null },
                    { -1223, 49.22m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.8m, 47.42m, 51.67m, -578, null },
                    { -1222, 54.96m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.53m, 45.08m, 53.21m, -578, null },
                    { -1221, 64.17m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.84m, 47.42m, 50.02m, -578, null },
                    { -1220, 53.11m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.92m, 52.52m, 54.52m, -578, null },
                    { -1219, 51.46m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.96m, 48.56m, 57.09m, -578, null },
                    { -1218, 48.53m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.3m, 49.21m, 56.36m, -578, null },
                    { -1217, 48.89m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.72m, 53.76m, 57.68m, -578, null },
                    { -1216, 57.3m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.24m, 51.75m, 57.71m, -578, null },
                    { -1215, 55.37m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.71m, 55.54m, 47m, -578, null },
                    { -1214, 58.84m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.08m, 48.56m, 66.82m, -578, null },
                    { -1213, 51.98m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.37m, 59.04m, 48.68m, -578, null },
                    { -1212, 57.35m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.72m, 48.33m, 53.72m, -578, null },
                    { -1211, 39.29m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.68m, 39.75m, 37.07m, -577, null },
                    { -1210, 37.28m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.73m, 42.58m, 39.35m, -577, null },
                    { -1209, 33.29m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.2m, 39.9m, 40.55m, -577, null },
                    { -1208, 37.83m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.26m, 37.93m, 36.43m, -577, null },
                    { -1207, 38.11m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.69m, 39.25m, 37.53m, -577, null },
                    { -1206, 36.66m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.09m, 41.14m, 35.5m, -577, null },
                    { -1205, 42.12m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.61m, 39.93m, 39.58m, -577, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1204, 38.46m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.93m, 42.44m, 36.83m, -577, null },
                    { -1203, 39.78m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.43m, 31.82m, 39.8m, -577, null },
                    { -1202, 38.78m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.83m, 40.52m, 40.68m, -577, null },
                    { -1201, 40.65m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.83m, 41.53m, 41.24m, -577, null },
                    { -1200, 42.32m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.12m, 39.8m, 35.04m, -577, null },
                    { -1199, 38.91m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.03m, 43.47m, 43.14m, -577, null },
                    { -1198, 39.96m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.55m, 43.32m, 39.37m, -577, null },
                    { -1197, 44.04m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.41m, 42.12m, 47.09m, -577, null },
                    { -1196, 43.7m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.78m, 39.9m, 44.51m, -577, null },
                    { -1195, 40.68m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.2m, 38.95m, 38.32m, -577, null },
                    { -1194, 47.33m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.89m, 43.55m, 42.56m, -577, null },
                    { -1193, 35.04m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.74m, 41.86m, 34.82m, -577, null },
                    { -1192, 40.82m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.9m, 44.76m, 38.97m, -577, null },
                    { -1191, 41.27m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.84m, 40.8m, 39.91m, -577, null },
                    { -1190, 45.39m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.4m, 47.45m, 44.96m, -577, null },
                    { -1189, 42.73m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.78m, 44.29m, 44.4m, -577, null },
                    { -1188, 43.28m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.97m, 39.67m, 44.82m, -577, null },
                    { -1187, 38.46m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.43m, 40.41m, 45.27m, -577, null },
                    { -1186, 45.2m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.02m, 41.73m, 40.73m, -577, null },
                    { -1185, 37.24m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.3m, 43.25m, 39.24m, -577, null },
                    { -1184, 41.39m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.83m, 36.93m, 36.99m, -577, null },
                    { -1183, 43.04m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 42.32m, 39.82m, 43.02m, -577, null },
                    { -1182, 39.48m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.57m, 41.91m, 40.62m, -577, null },
                    { -1181, 39.43m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.11m, 44.4m, 42.72m, -577, null },
                    { -1180, 36.75m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.65m, 39.87m, 40.76m, -577, null },
                    { -1179, 33.58m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.92m, 35.57m, 41.1m, -577, null },
                    { -1178, 39.65m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.9m, 42.13m, 40.36m, -577, null },
                    { -1177, 37.02m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.81m, 41.75m, 36.83m, -577, null },
                    { -1176, 38.56m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.62m, 38.85m, 37.44m, -577, null },
                    { -1175, 32.8m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.24m, 42.12m, 44.16m, -577, null },
                    { -1174, 44.71m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.53m, 43.91m, 36.7m, -577, null },
                    { -1173, 39.49m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 39m, 42.4m, 40.86m, -577, null },
                    { -1172, 40.07m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.04m, 35.55m, 44.07m, -577, null },
                    { -1171, 41.94m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.85m, 37.58m, 43.01m, -577, null },
                    { -1170, 39.85m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.75m, 42.13m, 42.47m, -577, null },
                    { -1169, 36.82m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.68m, 37.18m, 41.45m, -577, null },
                    { -1168, 39.22m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.54m, 41.75m, 41.88m, -577, null },
                    { -1167, 37.23m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.19m, 42.63m, 39.66m, -577, null },
                    { -1166, 40.14m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.03m, 39.25m, 38.49m, -577, null },
                    { -1165, 43.94m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.27m, 36.51m, 39.71m, -577, null },
                    { -1164, 41.95m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.39m, 35.44m, 37.6m, -577, null },
                    { -1163, 41.22m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.99m, 38.75m, 35.45m, -577, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1162, 42.38m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.26m, 34.27m, 40.62m, -577, null },
                    { -1161, 36.91m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.71m, 38.68m, 33.62m, -577, null },
                    { -1160, 36.9m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.73m, 41.54m, 36.8m, -577, null },
                    { -1159, 36.84m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.23m, 34.81m, 39.76m, -577, null },
                    { -1158, 36.73m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.05m, 43.53m, 41.92m, -577, null },
                    { -1157, 40.45m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.28m, 34.74m, 40.8m, -577, null },
                    { -1156, 36.21m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.95m, 34.53m, 37.76m, -577, null },
                    { -1155, 37.85m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.18m, 36.9m, 36.76m, -577, null },
                    { -1154, 41.53m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.72m, 38.34m, 37.94m, -577, null },
                    { -1153, 33.32m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.82m, 38.36m, 36.87m, -577, null },
                    { -1152, 32.3m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.35m, 38.33m, 37.95m, -577, null },
                    { -1151, 39.2m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.22m, 40.09m, 44.88m, -577, null },
                    { -1150, 42.93m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.54m, 41.17m, 38.72m, -577, null },
                    { -1149, 73.48m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.34m, 61.3m, 67.25m, -576, null },
                    { -1148, 75.03m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.72m, 79.48m, 61.95m, -576, null },
                    { -1147, 80.73m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.81m, 69.48m, 74.34m, -576, null },
                    { -1146, 71.47m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.08m, 78.26m, 70.41m, -576, null },
                    { -1145, 81.03m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.36m, 79.52m, 76.74m, -576, null },
                    { -1144, 80.4m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.83m, 70.33m, 69.34m, -576, null },
                    { -1143, 85.02m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.61m, 70.69m, 75.63m, -576, null },
                    { -1142, 77.53m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.85m, 74.66m, 80.35m, -576, null },
                    { -1141, 69.47m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.18m, 72.61m, 71.64m, -576, null },
                    { -1140, 70.3m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.94m, 71.49m, 76.93m, -576, null },
                    { -1139, 78.97m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.5m, 80.58m, 82.82m, -576, null },
                    { -1138, 76.93m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.59m, 71.36m, 72.36m, -576, null },
                    { -1137, 74.9m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.4m, 66.77m, 66.38m, -576, null },
                    { -1136, 77.5m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.39m, 67.34m, 77.06m, -576, null },
                    { -1135, 72.9m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.15m, 73.86m, 84.29m, -576, null },
                    { -1134, 60.96m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.24m, 70.86m, 81.12m, -576, null },
                    { -1133, 75.86m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.69m, 82.51m, 77.04m, -576, null },
                    { -1132, 75.95m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.59m, 80.29m, 77.68m, -576, null },
                    { -1131, 81.78m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.9m, 83.04m, 77.38m, -576, null },
                    { -1130, 79.09m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.69m, 70.47m, 72.13m, -576, null },
                    { -1129, 86.24m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.43m, 72.1m, 80.07m, -576, null },
                    { -1128, 82.02m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.57m, 85.29m, 78.44m, -576, null },
                    { -1127, 79.55m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.42m, 78.7m, 73.14m, -576, null },
                    { -1126, 79.57m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.39m, 78.74m, 90.73m, -576, null },
                    { -1125, 88.54m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.86m, 77.65m, 75.58m, -576, null },
                    { -1124, 76.46m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.6m, 79.05m, 82.66m, -576, null },
                    { -1123, 78.7m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.02m, 82.17m, 90.04m, -576, null },
                    { -1122, 70.16m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 93.82m, 77.35m, 69.15m, -576, null },
                    { -1121, 80.03m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.27m, 74.41m, 86.84m, -576, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1120, 81.79m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.72m, 81.76m, 86.67m, -576, null },
                    { -1119, 83.79m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.03m, 77.92m, 74.24m, -576, null },
                    { -1118, 72.95m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.96m, 73.63m, 82.58m, -576, null },
                    { -1117, 70.52m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.11m, 74.59m, 81.21m, -576, null },
                    { -1116, 73.11m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.07m, 72.71m, 72.58m, -576, null },
                    { -1115, 88.37m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.56m, 81m, 73.83m, -576, null },
                    { -1114, 78.49m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.37m, 68.71m, 84.08m, -576, null },
                    { -1113, 76.36m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.08m, 82.4m, 82.83m, -576, null },
                    { -1112, 83.98m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.29m, 71.07m, 67.53m, -576, null },
                    { -1111, 77.71m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 83.85m, 75.43m, 80.39m, -576, null },
                    { -1110, 68.56m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.27m, 77.83m, 73.88m, -576, null },
                    { -1109, 79.49m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.76m, 77.2m, 74.52m, -576, null },
                    { -1108, 78.81m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.16m, 87.4m, 82.89m, -576, null },
                    { -1107, 71.01m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.69m, 75.67m, 74.45m, -576, null },
                    { -1106, 83.94m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.46m, 78.07m, 75.38m, -576, null },
                    { -1105, 78.79m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.26m, 73.1m, 82.62m, -576, null },
                    { -1104, 77.57m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.98m, 81.53m, 82.59m, -576, null },
                    { -1103, 78.75m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.79m, 78.15m, 72.46m, -576, null },
                    { -1102, 76.67m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.08m, 75.52m, 70.38m, -576, null },
                    { -1101, 67.68m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.88m, 76.52m, 73.19m, -576, null },
                    { -1100, 78.55m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.64m, 72.52m, 74.9m, -576, null },
                    { -1099, 73.95m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.43m, 68.74m, 79.38m, -576, null },
                    { -1098, 88.97m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.37m, 76.66m, 73.35m, -576, null },
                    { -1097, 78.4m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.77m, 74.94m, 73.12m, -576, null },
                    { -1096, 72.9m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.51m, 80.11m, 77.76m, -576, null },
                    { -1095, 72.49m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.68m, 74.89m, 71.92m, -576, null },
                    { -1094, 75.55m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.68m, 81.77m, 75.01m, -576, null },
                    { -1093, 71.15m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.1m, 80.5m, 70.7m, -576, null },
                    { -1092, 74.42m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.52m, 85.3m, 70.41m, -576, null },
                    { -1091, 61.65m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.49m, 78.71m, 76.32m, -576, null },
                    { -1090, 66.95m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.25m, 80.02m, 75.62m, -576, null },
                    { -1089, 82.61m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.85m, 77.81m, 80.09m, -576, null },
                    { -1088, 68.84m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.43m, 71.67m, 79.78m, -576, null },
                    { -1087, 367.25m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 357.65m, 331.02m, 357.6m, -575, null },
                    { -1086, 341.88m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 322.91m, 386.46m, 390.63m, -575, null },
                    { -1085, 348.64m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 378.6m, 299.41m, 359.03m, -575, null },
                    { -1084, 400.05m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 315.32m, 333.34m, 333.08m, -575, null },
                    { -1083, 355.65m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 314.06m, 406.94m, 343.44m, -575, null },
                    { -1082, 369.64m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 360.03m, 375.36m, 349.64m, -575, null },
                    { -1081, 369.62m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 391.35m, 336.36m, 368.03m, -575, null },
                    { -1080, 354.95m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 375.93m, 358.94m, 355.55m, -575, null },
                    { -1079, 363.8m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 342.06m, 411.76m, 385.02m, -575, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1078, 381.25m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 374.9m, 362.52m, 375.49m, -575, null },
                    { -1077, 378.45m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 358.34m, 325.88m, 339.54m, -575, null },
                    { -1076, 362.03m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 331.83m, 307.38m, 363.47m, -575, null },
                    { -1075, 366.77m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 396.59m, 317.61m, 350.13m, -575, null },
                    { -1074, 332.13m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 371.55m, 343.72m, 362.88m, -575, null },
                    { -1073, 384.38m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 365.84m, 389.75m, 378.9m, -575, null },
                    { -1072, 447.27m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 378.53m, 327.59m, 376.79m, -575, null },
                    { -1071, 375.16m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 319.46m, 390.79m, 343m, -575, null },
                    { -1070, 340.8m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 429.73m, 405.07m, 389.51m, -575, null },
                    { -1069, 313.1m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 334.98m, 305.69m, 335.59m, -575, null },
                    { -1068, 404.49m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 381.42m, 360.09m, 380.11m, -575, null },
                    { -1067, 415.14m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 394.15m, 408.17m, 437.74m, -575, null },
                    { -1066, 411.79m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 359.72m, 280.26m, 370.69m, -575, null },
                    { -1065, 395.74m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 364.6m, 361.32m, 352.38m, -575, null },
                    { -1064, 412.02m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 357.14m, 354.77m, 420.28m, -575, null },
                    { -1063, 388.04m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 354.48m, 390.9m, 371.04m, -575, null },
                    { -1062, 359.03m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 370.21m, 390.61m, 339.14m, -575, null },
                    { -1061, 388.57m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 367.73m, 341.91m, 369.61m, -575, null },
                    { -1060, 380.7m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 388.42m, 373.05m, 330.24m, -575, null },
                    { -1059, 390.64m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 371.08m, 367.2m, 398.81m, -575, null },
                    { -1058, 382.27m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 385.67m, 432.26m, 344.73m, -575, null },
                    { -1057, 392.86m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 358.01m, 404.59m, 375.88m, -575, null },
                    { -1056, 370.7m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 378.29m, 369.43m, 341.4m, -575, null },
                    { -1055, 433.18m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 359m, 357.8m, 394.91m, -575, null },
                    { -1054, 360.87m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 332.21m, 360.96m, 377.01m, -575, null },
                    { -1053, 395.97m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 369.89m, 380.12m, 391.39m, -575, null },
                    { -1052, 349.34m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 347.65m, 371.17m, 367.84m, -575, null },
                    { -1051, 345.11m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 404.3m, 365.51m, 383.71m, -575, null },
                    { -1050, 351.08m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 402.69m, 299.45m, 366.01m, -575, null },
                    { -1049, 371.83m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 363.13m, 339.81m, 334.43m, -575, null },
                    { -1048, 383.98m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 343.25m, 370.4m, 361.18m, -575, null },
                    { -1047, 307.86m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 382.42m, 367.35m, 370.78m, -575, null },
                    { -1046, 336.37m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 376.02m, 405.51m, 379.84m, -575, null },
                    { -1045, 377.91m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 417.63m, 389.49m, 348.87m, -575, null },
                    { -1044, 358.48m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 385m, 350.87m, 356.97m, -575, null },
                    { -1043, 334.18m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 437.3m, 373.83m, 358.05m, -575, null },
                    { -1042, 343.87m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 318.73m, 343.24m, 302.4m, -575, null },
                    { -1041, 328.23m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 383.85m, 282.7m, 418.69m, -575, null },
                    { -1040, 331.92m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 339.96m, 390.5m, 356.95m, -575, null },
                    { -1039, 380.6m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 382.04m, 342.34m, 337.26m, -575, null },
                    { -1038, 410.15m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 392.34m, 422.64m, 334.1m, -575, null },
                    { -1037, 357.57m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 324.35m, 412.97m, 403.07m, -575, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -1036, 383.93m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 377.13m, 365.74m, 417.56m, -575, null },
                    { -1035, 317.38m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 416.86m, 382.83m, 366.3m, -575, null },
                    { -1034, 358.84m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 395.94m, 370.04m, 384.13m, -575, null },
                    { -1033, 359.83m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 391.83m, 362.92m, 387.16m, -575, null },
                    { -1032, 352.33m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 353.82m, 375.51m, 347.88m, -575, null },
                    { -1031, 394.25m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 377.6m, 373.67m, 375.13m, -575, null },
                    { -1030, 370.42m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 367.84m, 376.78m, 373.24m, -575, null },
                    { -1029, 342.45m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 405.76m, 394.29m, 373.47m, -575, null },
                    { -1028, 413.48m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 375.39m, 377.69m, 402.52m, -575, null },
                    { -1027, 408m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 383.33m, 413.33m, 370.21m, -575, null },
                    { -1026, 406.52m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 381.3m, 375.82m, 374.68m, -575, null },
                    { -1025, 95.02m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.92m, 91.32m, 103.93m, -574, null },
                    { -1024, 107.19m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.39m, 99.03m, 112.88m, -574, null },
                    { -1023, 101.29m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.82m, 94.69m, 92.54m, -574, null },
                    { -1022, 90.58m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 98.21m, 102.34m, 103.12m, -574, null },
                    { -1021, 103.73m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 99.73m, 102.8m, 108.6m, -574, null },
                    { -1020, 108.28m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 105.11m, 102.76m, 100.93m, -574, null },
                    { -1019, 120.09m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.92m, 111.61m, 118.75m, -574, null },
                    { -1018, 100.54m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.65m, 109.6m, 110.85m, -574, null },
                    { -1017, 112.7m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 106.72m, 103.98m, 113.08m, -574, null },
                    { -1016, 96.42m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.25m, 110.43m, 111.54m, -574, null },
                    { -1015, 105.49m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 99.02m, 104.15m, 114.43m, -574, null },
                    { -1014, 105.05m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 108.52m, 97.58m, 110.85m, -574, null },
                    { -1013, 105.73m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.83m, 105.19m, 112.36m, -574, null },
                    { -1012, 100.31m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.99m, 103.58m, 112.79m, -574, null },
                    { -1011, 102.76m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.74m, 101.16m, 117.53m, -574, null },
                    { -1010, 98.93m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.6m, 116.68m, 115.32m, -574, null },
                    { -1009, 113.47m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.47m, 114.82m, 102.23m, -574, null },
                    { -1008, 114.06m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 115.71m, 110.6m, 107.98m, -574, null },
                    { -1007, 114.72m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.89m, 122.99m, 112.86m, -574, null },
                    { -1006, 127.71m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.79m, 101.7m, 110.74m, -574, null },
                    { -1005, 120.69m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.9m, 113.96m, 109.91m, -574, null },
                    { -1004, 115.26m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.41m, 113.68m, 125.84m, -574, null },
                    { -1003, 116.77m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 114.89m, 117.01m, 126.19m, -574, null },
                    { -1002, 101.99m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.04m, 106.8m, 118.36m, -574, null },
                    { -1001, 111.33m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 127.9m, 113.38m, 110.87m, -574, null },
                    { -1000, 123.54m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.83m, 111.51m, 124.2m, -574, null },
                    { -999, 101.9m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 109.18m, 119.35m, 117.85m, -574, null },
                    { -998, 120.2m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.79m, 122.02m, 114.54m, -574, null },
                    { -997, 129.32m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.18m, 123.58m, 113.23m, -574, null },
                    { -996, 105.73m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.13m, 103.3m, 115.4m, -574, null },
                    { -995, 131.01m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.17m, 118.86m, 116.45m, -574, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -994, 120.92m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.48m, 108.47m, 112.54m, -574, null },
                    { -993, 102.53m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 108.77m, 118.19m, 114.05m, -574, null },
                    { -992, 116.13m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.63m, 109.72m, 113.52m, -574, null },
                    { -991, 109.14m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.69m, 116.51m, 115.67m, -574, null },
                    { -990, 117.09m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.04m, 103.53m, 118.04m, -574, null },
                    { -989, 110.84m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.05m, 113.1m, 94.56m, -574, null },
                    { -988, 110.63m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.54m, 128.1m, 101.07m, -574, null },
                    { -987, 102.43m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.8m, 102.39m, 113.85m, -574, null },
                    { -986, 112.87m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.63m, 111.18m, 121.12m, -574, null },
                    { -985, 105.11m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 101.88m, 119.35m, 118.61m, -574, null },
                    { -984, 118.76m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.98m, 106.91m, 120.85m, -574, null },
                    { -983, 103.14m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.36m, 120.36m, 107.78m, -574, null },
                    { -982, 107.52m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 118.96m, 92.67m, 100.51m, -574, null },
                    { -981, 104.94m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.19m, 123.9m, 110.99m, -574, null },
                    { -980, 112.11m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 109.45m, 108.12m, 102.95m, -574, null },
                    { -979, 119.02m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.49m, 115.18m, 102.73m, -574, null },
                    { -978, 115.48m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.36m, 105.49m, 119.27m, -574, null },
                    { -977, 110.67m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.52m, 120.81m, 101.59m, -574, null },
                    { -976, 112.45m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.17m, 118.01m, 124.43m, -574, null },
                    { -975, 106.32m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 101.18m, 107.59m, 127.33m, -574, null },
                    { -974, 136.01m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.8m, 105.58m, 115.69m, -574, null },
                    { -973, 103.66m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.89m, 101.6m, 122.87m, -574, null },
                    { -972, 111.75m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.38m, 119.92m, 111.06m, -574, null },
                    { -971, 104.14m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.01m, 113.39m, 105.18m, -574, null },
                    { -970, 100.32m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.93m, 130.89m, 118.48m, -574, null },
                    { -969, 134.35m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.55m, 120.58m, 114.51m, -574, null },
                    { -968, 113.24m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.25m, 110.78m, 112.63m, -574, null },
                    { -967, 123.13m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.19m, 121.16m, 103.59m, -574, null },
                    { -966, 125.59m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 132.84m, 111.81m, 115.67m, -574, null },
                    { -965, 119.5m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.74m, 134.59m, 112.14m, -574, null },
                    { -964, 115.41m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.77m, 118.98m, 102.85m, -574, null },
                    { -963, 76.28m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.29m, 73.66m, 75.85m, -523, null },
                    { -962, 72.39m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.53m, 79.65m, 79.47m, -523, null },
                    { -961, 82.86m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.69m, 96.68m, 80.22m, -523, null },
                    { -960, 80.4m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.61m, 85.51m, 61.02m, -523, null },
                    { -959, 75.14m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 82m, 70.95m, 82m, -523, null },
                    { -958, 75.56m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.27m, 82.96m, 83.97m, -523, null },
                    { -957, 75.01m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.67m, 77.71m, 82m, -523, null },
                    { -956, 83.24m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.72m, 84.04m, 78.65m, -523, null },
                    { -955, 76.31m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.88m, 75.36m, 73.96m, -523, null },
                    { -954, 73.28m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 86.57m, 78.99m, 73.11m, -523, null },
                    { -953, 78.8m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.43m, 80.22m, 71.02m, -523, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -952, 76.96m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.77m, 91.65m, 80.86m, -523, null },
                    { -951, 84.18m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.22m, 76.32m, 79.57m, -523, null },
                    { -950, 74.37m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.8m, 77.57m, 81.68m, -523, null },
                    { -949, 75.2m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.72m, 86.85m, 70.68m, -523, null },
                    { -948, 81.21m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.55m, 71.52m, 74.72m, -523, null },
                    { -947, 73.92m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.82m, 78.33m, 81.57m, -523, null },
                    { -946, 77.04m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.93m, 80.73m, 71.99m, -523, null },
                    { -945, 70.86m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.84m, 70.4m, 67.96m, -523, null },
                    { -944, 70.23m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.6m, 63.52m, 71.05m, -523, null },
                    { -943, 70.77m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.35m, 74.46m, 65.42m, -523, null },
                    { -942, 75.44m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 86.64m, 75.74m, 79.14m, -523, null },
                    { -941, 76.08m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.78m, 77.9m, 95.78m, -523, null },
                    { -940, 63.59m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.9m, 78.27m, 63.43m, -523, null },
                    { -939, 72.79m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.99m, 69.41m, 77.35m, -523, null },
                    { -938, 76.25m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.42m, 80.05m, 76.41m, -523, null },
                    { -937, 80.78m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.35m, 80.26m, 73.38m, -523, null },
                    { -936, 81.69m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.55m, 72.34m, 68.77m, -523, null },
                    { -935, 75.48m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.37m, 74.58m, 74.42m, -523, null },
                    { -934, 71.78m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.98m, 68.58m, 65.59m, -523, null },
                    { -933, 70.64m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.05m, 69.59m, 72.07m, -523, null },
                    { -932, 79.27m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.28m, 61.63m, 76.19m, -523, null },
                    { -931, 75.63m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.07m, 82.54m, 69.38m, -523, null },
                    { -930, 89.15m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.94m, 67.71m, 77.26m, -523, null },
                    { -929, 69.98m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.33m, 68.74m, 70.43m, -523, null },
                    { -928, 76.3m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.93m, 70.13m, 70.18m, -523, null },
                    { -927, 71.73m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.19m, 71.3m, 64.97m, -523, null },
                    { -926, 78.19m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.3m, 65.3m, 75.56m, -523, null },
                    { -925, 67.37m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.46m, 74.26m, 75.91m, -523, null },
                    { -924, 90.12m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.97m, 67.18m, 72.57m, -523, null },
                    { -923, 66.73m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.01m, 65.59m, 74.56m, -523, null },
                    { -922, 73.86m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.92m, 73.09m, 75.57m, -523, null },
                    { -921, 79.93m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.65m, 74.63m, 72.44m, -523, null },
                    { -920, 65.06m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.47m, 76.37m, 74.61m, -523, null },
                    { -919, 71.47m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.24m, 65.95m, 83.68m, -523, null },
                    { -918, 67.77m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.13m, 67.63m, 73.42m, -523, null },
                    { -917, 64.55m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.7m, 73.32m, 72.36m, -523, null },
                    { -916, 67.95m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.96m, 83.46m, 69.4m, -523, null },
                    { -915, 71.81m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.71m, 79.82m, 60.05m, -523, null },
                    { -914, 71.05m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.55m, 70.96m, 77.18m, -523, null },
                    { -913, 83.02m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.19m, 73.52m, 81.3m, -523, null },
                    { -912, 79.94m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.65m, 91.4m, 75.45m, -523, null },
                    { -911, 68.32m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.27m, 76.45m, 73.08m, -523, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -910, 70.65m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.64m, 74.43m, 69.7m, -523, null },
                    { -909, 77.1m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.69m, 75.29m, 79.2m, -523, null },
                    { -908, 67.9m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.71m, 69.11m, 72.41m, -523, null },
                    { -907, 80.75m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.33m, 69.84m, 66.83m, -523, null },
                    { -906, 66.98m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.62m, 80.13m, 75.7m, -523, null },
                    { -905, 81.3m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.6m, 78.42m, 85.87m, -523, null },
                    { -904, 79.69m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.01m, 75.31m, 75.77m, -523, null },
                    { -903, 81.66m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.88m, 86.52m, 78.63m, -523, null },
                    { -902, 86.61m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.21m, 79.16m, 89.02m, -523, null },
                    { -901, 87.78m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.78m, 88.31m, 83.91m, -523, null },
                    { -900, 92.13m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 94.44m, 79.33m, 76.19m, -523, null },
                    { -899, 85.24m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 91.21m, 78.38m, 80.94m, -523, null },
                    { -898, 74.11m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.05m, 90.84m, 94.18m, -523, null },
                    { -897, 89.18m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.88m, 73.28m, 83.64m, -523, null },
                    { -896, 93.69m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 83.43m, 79.63m, 84.88m, -523, null },
                    { -895, 85.16m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 97.53m, 83.54m, 92.34m, -523, null },
                    { -894, 73.15m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.54m, 94.61m, 76.44m, -523, null },
                    { -893, 93.59m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.79m, 77.8m, 75.36m, -523, null },
                    { -892, 81.15m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.42m, 81.14m, 87.13m, -523, null },
                    { -891, 93.49m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.41m, 67.91m, 99.88m, -523, null },
                    { -890, 77.75m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.82m, 89m, 76.64m, -523, null },
                    { -889, 84.38m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.12m, 85.06m, 83.41m, -523, null },
                    { -888, 84.72m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 93.2m, 82.98m, 75.89m, -523, null },
                    { -887, 267.45m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 253.17m, 265.35m, 248.21m, -514, null },
                    { -886, 266.88m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.42m, 232.84m, 257.82m, -514, null },
                    { -885, 230.83m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 237.39m, 238.69m, 225.82m, -514, null },
                    { -884, 278.68m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 231.43m, 263.94m, 246.89m, -514, null },
                    { -883, 256.39m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 234.23m, 214.58m, 238.63m, -514, null },
                    { -882, 242.93m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 253.24m, 232.59m, 288.99m, -514, null },
                    { -881, 273.82m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 267.01m, 259.38m, 288.17m, -514, null },
                    { -880, 303.14m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 229.63m, 292.5m, 275.01m, -514, null },
                    { -879, 251.81m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 297.08m, 261.26m, 245m, -514, null },
                    { -878, 254.78m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 248.16m, 226.34m, 228.97m, -514, null },
                    { -877, 270.21m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 257.15m, 236.02m, 269.13m, -514, null },
                    { -876, 256.2m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 216.15m, 240.92m, 226.83m, -514, null },
                    { -875, 238.27m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 281.9m, 277.91m, 221.85m, -514, null },
                    { -874, 226.39m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 268.23m, 245.74m, 256.7m, -514, null },
                    { -873, 244.51m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 231.26m, 263.86m, 262.94m, -514, null },
                    { -872, 234.42m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.23m, 269.43m, 256.05m, -514, null },
                    { -871, 262.34m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 225.62m, 253.12m, 250.23m, -514, null },
                    { -870, 263.33m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 239.11m, 248.3m, 259.19m, -514, null },
                    { -869, 225.96m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.7m, 226.2m, 222.21m, -514, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -868, 233.86m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 241.04m, 215.82m, 221.79m, -514, null },
                    { -867, 241.28m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 239.36m, 236.28m, 220.47m, -514, null },
                    { -866, 233.99m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 242.83m, 220.58m, 256.93m, -514, null },
                    { -865, 259.18m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 237.06m, 249.58m, 197.76m, -514, null },
                    { -864, 258.96m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 228.36m, 245.04m, 271.17m, -514, null },
                    { -863, 197.91m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 242.09m, 290.83m, 254.88m, -514, null },
                    { -862, 272.41m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 265.54m, 241.59m, 245.65m, -514, null },
                    { -861, 255.65m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 235.94m, 234.09m, 227.96m, -514, null },
                    { -860, 233.69m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 261.08m, 198.99m, 277.35m, -514, null },
                    { -859, 238.65m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 247.46m, 233.18m, 229.81m, -514, null },
                    { -858, 250.64m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 300.68m, 254.09m, 236.54m, -514, null },
                    { -857, 207.75m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 259.39m, 273.3m, 236.81m, -514, null },
                    { -856, 227.85m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 253.76m, 237.02m, 298.3m, -514, null },
                    { -855, 275.32m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 268.97m, 249.91m, 288.11m, -514, null },
                    { -854, 283.05m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 266.69m, 250.28m, 271.69m, -514, null },
                    { -853, 271.09m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 312.39m, 263.77m, 245.9m, -514, null },
                    { -852, 241.4m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.8m, 235.91m, 258.02m, -514, null },
                    { -851, 293.24m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 296.04m, 282.82m, 280.02m, -514, null },
                    { -850, 254.65m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 271.58m, 248.7m, 247.92m, -514, null },
                    { -849, 255.21m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.96m, 259.74m, 255.94m, -514, null },
                    { -848, 274.81m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 279.42m, 244.6m, 197.33m, -514, null },
                    { -847, 237.98m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 286.23m, 258.01m, 296.68m, -514, null },
                    { -846, 264.03m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 269.03m, 238.44m, 273.55m, -514, null },
                    { -845, 274.63m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 268.96m, 269.04m, 241.79m, -514, null },
                    { -844, 254.95m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 248.45m, 269.73m, 272.91m, -514, null },
                    { -843, 200.88m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 258.98m, 249.25m, 266.06m, -514, null },
                    { -842, 310.07m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 261.78m, 258.79m, 272.63m, -514, null },
                    { -841, 290.11m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 275.64m, 256.65m, 271.4m, -514, null },
                    { -840, 274.7m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 267.65m, 266.61m, 314.31m, -514, null },
                    { -839, 249.71m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 274.19m, 277.07m, 278.83m, -514, null },
                    { -838, 267.46m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 241.95m, 276.95m, 264.17m, -514, null },
                    { -837, 328.28m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 317.26m, 247.27m, 252.63m, -514, null },
                    { -836, 273.84m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 288.07m, 279.13m, 273.92m, -514, null },
                    { -835, 274.13m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 253.28m, 251.73m, 284.58m, -514, null },
                    { -834, 237.95m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 248.38m, 299.79m, 256.09m, -514, null },
                    { -833, 279.25m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 272.04m, 298.98m, 310.98m, -514, null },
                    { -832, 271.57m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 267.01m, 270.2m, 249.15m, -514, null },
                    { -831, 288.77m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 275.07m, 249.44m, 241.05m, -514, null },
                    { -830, 250.59m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 228.01m, 271.5m, 268.25m, -514, null },
                    { -829, 245.42m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 282.17m, 250.14m, 286.17m, -514, null },
                    { -828, 260.52m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 260.34m, 251.22m, 269.33m, -514, null },
                    { -827, 257.58m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 261.62m, 282.53m, 262.05m, -514, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -826, 239.95m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 251.44m, 255.22m, 279.78m, -514, null },
                    { -825, 337.96m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 234.64m, 254.36m, 254.1m, -514, null },
                    { -824, 261.33m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 279.72m, 273.82m, 250.19m, -514, null },
                    { -823, 243.6m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 276.62m, 245.35m, 262.06m, -514, null },
                    { -822, 213.07m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 278.05m, 255.74m, 263.37m, -514, null },
                    { -821, 238.09m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 238.39m, 254.84m, 242.02m, -514, null },
                    { -820, 232.91m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 260.12m, 248.62m, 291.68m, -514, null },
                    { -819, 251.56m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 226.09m, 257.32m, 235.86m, -514, null },
                    { -818, 267.8m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 247.03m, 235.88m, 264.47m, -514, null },
                    { -817, 241.05m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 237.91m, 254.86m, 253.26m, -514, null },
                    { -816, 237.82m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 241.03m, 278.25m, 256.16m, -514, null },
                    { -815, 225.3m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 267.36m, 254.26m, 239.9m, -514, null },
                    { -814, 259.43m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 225.48m, 204.43m, 247.75m, -514, null },
                    { -813, 236.46m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 265.8m, 264.18m, 249.69m, -514, null },
                    { -812, 251.07m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 236.49m, 258.11m, 214.71m, -514, null },
                    { -811, 30.53m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.77m, 33.34m, 31.3m, -493, null },
                    { -810, 31.33m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.47m, 31.91m, 33.71m, -493, null },
                    { -809, 30.08m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.03m, 31.15m, 31.48m, -493, null },
                    { -808, 29.89m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.16m, 33.54m, 30.19m, -493, null },
                    { -807, 31.79m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.64m, 35.14m, 31.25m, -493, null },
                    { -806, 34.45m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.65m, 31.04m, 31.59m, -493, null },
                    { -805, 32.64m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.74m, 31.68m, 33.31m, -493, null },
                    { -804, 29.83m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.37m, 27.25m, 33.79m, -493, null },
                    { -803, 28.21m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.45m, 26.51m, 31.43m, -493, null },
                    { -802, 27.46m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.58m, 30.02m, 29.22m, -493, null },
                    { -801, 32.9m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.95m, 31.76m, 29.51m, -493, null },
                    { -800, 29.55m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.25m, 30.74m, 29.31m, -493, null },
                    { -799, 30.41m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.27m, 32.46m, 26.64m, -493, null },
                    { -798, 30.05m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.43m, 29.69m, 31.35m, -493, null },
                    { -797, 28.3m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.56m, 32.88m, 30.1m, -493, null },
                    { -796, 30.82m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.55m, 29.46m, 32.66m, -493, null },
                    { -795, 31.92m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.71m, 28.78m, 32.22m, -493, null },
                    { -794, 25.97m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.03m, 29.51m, 32.28m, -493, null },
                    { -793, 27.57m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.56m, 27.78m, 31.39m, -493, null },
                    { -792, 27.35m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.91m, 26.33m, 25.37m, -493, null },
                    { -791, 28.41m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.22m, 27.46m, 28.14m, -493, null },
                    { -790, 26.43m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.62m, 26.66m, 29.33m, -493, null },
                    { -789, 26.77m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.07m, 29.02m, 29.85m, -493, null },
                    { -788, 25.61m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.46m, 23.15m, 28.09m, -493, null },
                    { -787, 31.1m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.73m, 28.41m, 27.98m, -493, null },
                    { -786, 29.8m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.53m, 27.31m, 23.88m, -493, null },
                    { -785, 31.8m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.02m, 27.64m, 32.47m, -493, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -784, 29.01m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.7m, 26.6m, 29.87m, -493, null },
                    { -783, 30.32m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.22m, 28.91m, 27.76m, -493, null },
                    { -782, 27.83m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.29m, 28.59m, 27.63m, -493, null },
                    { -781, 28.49m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.6m, 27.89m, 25.62m, -493, null },
                    { -780, 28.76m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.96m, 26.94m, 27.27m, -493, null },
                    { -779, 28.43m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.85m, 29.17m, 27.56m, -493, null },
                    { -778, 24.64m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.56m, 28.62m, 27.83m, -493, null },
                    { -777, 27.6m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.87m, 26.5m, 25.25m, -493, null },
                    { -776, 27.37m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.94m, 25.23m, 25.53m, -493, null },
                    { -775, 25.91m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.73m, 23.85m, 23.99m, -493, null },
                    { -774, 21.39m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.27m, 23.88m, 28.11m, -493, null },
                    { -773, 27.69m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.72m, 23.71m, 26.35m, -493, null },
                    { -772, 23.38m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.98m, 27.2m, 22.1m, -493, null },
                    { -771, 28.87m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.52m, 29.48m, 28.94m, -493, null },
                    { -770, 25.91m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.05m, 25.57m, 29.09m, -493, null },
                    { -769, 27.89m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.77m, 26.66m, 27.93m, -493, null },
                    { -768, 26.37m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.08m, 24.2m, 27.21m, -493, null },
                    { -767, 29.93m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.01m, 29.36m, 24.89m, -493, null },
                    { -766, 25.15m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.65m, 27.83m, 28.51m, -493, null },
                    { -765, 28.44m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.95m, 29.09m, 23.87m, -493, null },
                    { -764, 26.27m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.2m, 26.83m, 30.05m, -493, null },
                    { -763, 24.91m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.52m, 23.88m, 28.08m, -493, null },
                    { -762, 29.11m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.39m, 29.19m, 27.61m, -493, null },
                    { -761, 30.99m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.9m, 28.18m, 26.13m, -493, null },
                    { -760, 25.74m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.42m, 28.67m, 26.68m, -493, null },
                    { -759, 24.74m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 24.79m, 24.54m, 29.7m, -493, null },
                    { -758, 26.31m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.2m, 28.2m, 29.64m, -493, null },
                    { -757, 27.59m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.68m, 28.37m, 25.53m, -493, null },
                    { -756, 25.71m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.28m, 28.79m, 26.8m, -493, null },
                    { -755, 28.27m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.24m, 28.83m, 29.29m, -493, null },
                    { -754, 26.48m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.3m, 28.61m, 28.61m, -493, null },
                    { -753, 26.66m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.55m, 27.72m, 30.45m, -493, null },
                    { -752, 29.92m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.58m, 26.71m, 28.04m, -493, null },
                    { -751, 34.02m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.32m, 32.96m, 34.64m, -493, null },
                    { -750, 34.05m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.12m, 33.27m, 34.38m, -493, null },
                    { -749, 28.01m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.51m, 27.32m, 29.89m, -493, null },
                    { -748, 29.27m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.13m, 32.11m, 31.56m, -493, null },
                    { -747, 25.67m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.11m, 27.75m, 27.29m, -493, null },
                    { -746, 30.05m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.19m, 25.71m, 26.14m, -493, null },
                    { -745, 30.51m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.52m, 27.18m, 32.61m, -493, null },
                    { -744, 30.81m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.9m, 27.29m, 30.19m, -493, null },
                    { -743, 28.09m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.31m, 28.36m, 23.55m, -493, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -742, 22.25m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.55m, 26.62m, 25.75m, -493, null },
                    { -741, 26.82m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.58m, 24.43m, 28.61m, -493, null },
                    { -740, 25.35m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.32m, 26.51m, 23.99m, -493, null },
                    { -739, 29.89m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.62m, 25.73m, 20.54m, -493, null },
                    { -738, 25.75m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.76m, 26.74m, 23.58m, -493, null },
                    { -737, 25.66m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 26.4m, 26.42m, 29.33m, -493, null },
                    { -736, 25.96m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 23.71m, 25.65m, 25.39m, -493, null },
                    { -735, 113.2m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.8m, 110.6m, 112.89m, -482, null },
                    { -734, 130.39m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.57m, 102.99m, 98.51m, -482, null },
                    { -733, 105.06m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 98.91m, 118.74m, 102.26m, -482, null },
                    { -732, 110.6m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.06m, 111.25m, 116.9m, -482, null },
                    { -731, 122.2m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.65m, 104.56m, 103.18m, -482, null },
                    { -730, 125.08m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.55m, 116.32m, 97.04m, -482, null },
                    { -729, 107.83m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 111.73m, 127.8m, 102.74m, -482, null },
                    { -728, 119.16m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.76m, 129.18m, 122.56m, -482, null },
                    { -727, 110.82m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 106.85m, 118.64m, 104.47m, -482, null },
                    { -726, 101.84m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 127.12m, 106.35m, 118.6m, -482, null },
                    { -725, 131.53m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 127.24m, 108.25m, 110.22m, -482, null },
                    { -724, 116.06m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.81m, 121.33m, 116.31m, -482, null },
                    { -723, 123.35m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.02m, 113.85m, 128.65m, -482, null },
                    { -722, 129.77m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.6m, 120.71m, 127.35m, -482, null },
                    { -721, 122.15m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 126.5m, 119m, 131.78m, -482, null },
                    { -720, 117.69m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.37m, 126.77m, 123.16m, -482, null },
                    { -719, 122.47m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.23m, 101.38m, 124.98m, -482, null },
                    { -718, 139.72m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.4m, 95.74m, 128.6m, -482, null },
                    { -717, 137.97m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 126.83m, 116.88m, 113.91m, -482, null },
                    { -716, 113.78m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.01m, 132.34m, 120.56m, -482, null },
                    { -715, 127.86m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.84m, 128.65m, 116.89m, -482, null },
                    { -714, 113.9m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.76m, 125.4m, 113.76m, -482, null },
                    { -713, 119.69m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.88m, 126.8m, 120.93m, -482, null },
                    { -712, 119.96m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.68m, 113.03m, 114.4m, -482, null },
                    { -711, 135.84m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.83m, 115.98m, 126.05m, -482, null },
                    { -710, 126.12m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.06m, 120.87m, 114.49m, -482, null },
                    { -709, 123.23m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.3m, 122.3m, 109.53m, -482, null },
                    { -708, 125.79m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 114.76m, 111.21m, 117.98m, -482, null },
                    { -707, 105.38m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 124.38m, 115.11m, 108.66m, -482, null },
                    { -706, 128.91m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.15m, 115.85m, 106.82m, -482, null },
                    { -705, 122.67m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.52m, 128.07m, 118.37m, -482, null },
                    { -704, 118.5m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 129.46m, 103.21m, 111.63m, -482, null },
                    { -703, 101.52m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.14m, 120.36m, 94.97m, -482, null },
                    { -702, 103.14m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.14m, 134.72m, 114.18m, -482, null },
                    { -701, 129.24m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.78m, 98.55m, 98.91m, -482, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -700, 115.38m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.5m, 116.05m, 119.75m, -482, null },
                    { -699, 121.69m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.61m, 138.09m, 122.59m, -482, null },
                    { -698, 120.7m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.43m, 114.71m, 128.02m, -482, null },
                    { -697, 107.74m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.2m, 119.3m, 121.02m, -482, null },
                    { -696, 113.47m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.26m, 99.88m, 117.17m, -482, null },
                    { -695, 106.22m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 105.38m, 107.36m, 112.18m, -482, null },
                    { -694, 119.71m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 116.97m, 116.32m, 107.73m, -482, null },
                    { -693, 107.96m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.92m, 105.89m, 114.83m, -482, null },
                    { -692, 115.25m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 126.67m, 111.4m, 129.37m, -482, null },
                    { -691, 122.41m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.41m, 127.85m, 135.78m, -482, null },
                    { -690, 120.02m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.07m, 115.28m, 125.19m, -482, null },
                    { -689, 126.31m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.88m, 117.93m, 117.32m, -482, null },
                    { -688, 125.7m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 120.35m, 109.89m, 118.17m, -482, null },
                    { -687, 123.89m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.78m, 118.09m, 114.23m, -482, null },
                    { -686, 105.35m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.41m, 134.13m, 134.26m, -482, null },
                    { -685, 112.2m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 109.11m, 127.76m, 119.83m, -482, null },
                    { -684, 121.49m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.83m, 119.29m, 116.4m, -482, null },
                    { -683, 130.4m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.69m, 127.1m, 112.14m, -482, null },
                    { -682, 121.38m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.11m, 129.25m, 141.95m, -482, null },
                    { -681, 121.16m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.86m, 127.5m, 119.57m, -482, null },
                    { -680, 117.55m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.87m, 99.56m, 114.73m, -482, null },
                    { -679, 112.53m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 108.97m, 96.76m, 104.55m, -482, null },
                    { -678, 105.02m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.06m, 106.8m, 116.94m, -482, null },
                    { -677, 98.46m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 105.16m, 127.95m, 112.87m, -482, null },
                    { -676, 127.28m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.8m, 106.4m, 109.86m, -482, null },
                    { -675, 104.05m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.59m, 108.95m, 118.87m, -482, null },
                    { -674, 106.98m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.01m, 125.25m, 118.54m, -482, null },
                    { -673, 123.4m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 110.96m, 111.15m, 102.25m, -482, null },
                    { -672, 118.22m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 106.25m, 119.89m, 104.4m, -482, null },
                    { -671, 95.76m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 118m, 108.34m, 100.91m, -482, null },
                    { -670, 108.47m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 112.69m, 123.08m, 97.37m, -482, null },
                    { -669, 115.46m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.6m, 114.28m, 101.69m, -482, null },
                    { -668, 103.64m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 113.14m, 103.94m, 112.69m, -482, null },
                    { -667, 125.06m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 97.73m, 95.62m, 121.57m, -482, null },
                    { -666, 112.12m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 115.05m, 90.07m, 104.27m, -482, null },
                    { -665, 110.31m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.67m, 108.96m, 104.72m, -482, null },
                    { -664, 109.29m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.04m, 95.91m, 98.64m, -482, null },
                    { -663, 86.77m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.95m, 89.1m, 100.08m, -482, null },
                    { -662, 83.89m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 108.7m, 102.11m, 94.1m, -482, null },
                    { -661, 103.86m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.14m, 87.33m, 98.26m, -482, null },
                    { -660, 100.94m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.42m, 88.72m, 93.98m, -482, null },
                    { -659, 38.58m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.16m, 30.78m, 33.5m, -442, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -658, 27.89m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.55m, 29.88m, 35.87m, -442, null },
                    { -657, 32.58m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.5m, 36.32m, 34.44m, -442, null },
                    { -656, 35.66m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.54m, 32.53m, 30.87m, -442, null },
                    { -655, 34.09m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.28m, 31.44m, 36.24m, -442, null },
                    { -654, 32.41m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.13m, 36.28m, 35.82m, -442, null },
                    { -653, 33.67m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 27.68m, 36.02m, 31.03m, -442, null },
                    { -652, 31.67m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.13m, 32.36m, 35.1m, -442, null },
                    { -651, 28.41m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.13m, 35.29m, 36.75m, -442, null },
                    { -650, 36.11m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.31m, 33.76m, 36.82m, -442, null },
                    { -649, 33.68m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.43m, 32.59m, 33.17m, -442, null },
                    { -648, 35.54m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.77m, 34.7m, 36.48m, -442, null },
                    { -647, 33.98m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.52m, 35.9m, 36.94m, -442, null },
                    { -646, 40.09m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.89m, 38.35m, 35.79m, -442, null },
                    { -645, 34.53m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.67m, 33m, 36.38m, -442, null },
                    { -644, 38.13m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.33m, 37.8m, 35.64m, -442, null },
                    { -643, 34.22m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.31m, 38.73m, 38.85m, -442, null },
                    { -642, 38.73m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.25m, 35.17m, 39.4m, -442, null },
                    { -641, 35.08m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.74m, 38.58m, 33.77m, -442, null },
                    { -640, 36.22m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.39m, 32.02m, 40.58m, -442, null },
                    { -639, 38.09m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.06m, 38.46m, 32.11m, -442, null },
                    { -638, 38.15m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.77m, 34.32m, 37.66m, -442, null },
                    { -637, 35.54m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.26m, 33.9m, 36.51m, -442, null },
                    { -636, 33.16m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.01m, 34.35m, 38.32m, -442, null },
                    { -635, 27.32m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.78m, 33.7m, 35.96m, -442, null },
                    { -634, 34.03m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.3m, 37.08m, 30.12m, -442, null },
                    { -633, 37.04m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.03m, 38.46m, 34.06m, -442, null },
                    { -632, 29.57m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.26m, 34.81m, 34.91m, -442, null },
                    { -631, 33.7m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.34m, 35.17m, 34.78m, -442, null },
                    { -630, 35.1m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.5m, 33.95m, 30.41m, -442, null },
                    { -629, 30.7m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.81m, 34.29m, 34.08m, -442, null },
                    { -628, 35.08m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.85m, 33.09m, 33.53m, -442, null },
                    { -627, 40.53m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.66m, 33.5m, 31.9m, -442, null },
                    { -626, 32.78m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.9m, 33.16m, 32.43m, -442, null },
                    { -625, 38.45m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.27m, 35.89m, 36.66m, -442, null },
                    { -624, 32.5m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.87m, 36.07m, 27.96m, -442, null },
                    { -623, 31.91m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.82m, 29.82m, 31.69m, -442, null },
                    { -622, 32.43m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.39m, 34.72m, 31.41m, -442, null },
                    { -621, 32.17m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.79m, 26.91m, 30.3m, -442, null },
                    { -620, 35.98m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.05m, 33.02m, 33.53m, -442, null },
                    { -619, 30.03m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.2m, 34.9m, 33.54m, -442, null },
                    { -618, 33.8m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.42m, 36.01m, 35.04m, -442, null },
                    { -617, 31.55m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.13m, 30.43m, 32.59m, -442, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -616, 36.11m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.41m, 35.64m, 34.15m, -442, null },
                    { -615, 33.87m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.25m, 36.13m, 31.03m, -442, null },
                    { -614, 27.64m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.34m, 32.45m, 34.1m, -442, null },
                    { -613, 32.59m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 36.13m, 29.09m, 33.12m, -442, null },
                    { -612, 33.06m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.73m, 32.54m, 33.49m, -442, null },
                    { -611, 32.15m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.58m, 32.36m, 33.89m, -442, null },
                    { -610, 36.85m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.78m, 29.71m, 32.74m, -442, null },
                    { -609, 34.42m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.9m, 29.25m, 32.5m, -442, null },
                    { -608, 31.61m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 31.08m, 33.98m, 33.12m, -442, null },
                    { -607, 34.44m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.35m, 34.2m, 34.55m, -442, null },
                    { -606, 35.16m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.39m, 30.73m, 35.54m, -442, null },
                    { -605, 33.28m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.45m, 30.96m, 32.21m, -442, null },
                    { -604, 31.6m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.92m, 33.44m, 33.08m, -442, null },
                    { -603, 38.38m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 33.97m, 31.47m, 34.43m, -442, null },
                    { -602, 34.99m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.58m, 33.62m, 36.41m, -442, null },
                    { -601, 30.9m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.26m, 34.52m, 34.4m, -442, null },
                    { -600, 34.95m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.78m, 34.01m, 35.52m, -442, null },
                    { -599, 35.99m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.66m, 30.01m, 36.6m, -442, null },
                    { -598, 34.34m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.94m, 32.17m, 31.14m, -442, null },
                    { -597, 140.81m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 153.84m, 136.01m, 123.68m, -411, null },
                    { -596, 145.11m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 149.73m, 145.52m, 122.09m, -411, null },
                    { -595, 143.15m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.11m, 139.94m, 155.36m, -411, null },
                    { -594, 131.44m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 172.55m, 152.74m, 137.85m, -411, null },
                    { -593, 150.14m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.43m, 153.67m, 139.45m, -411, null },
                    { -592, 137.59m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.42m, 154.97m, 160.58m, -411, null },
                    { -591, 154.5m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.65m, 138.86m, 151.72m, -411, null },
                    { -590, 150.9m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 142.48m, 130.14m, 147.23m, -411, null },
                    { -589, 138.33m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 158.14m, 156.45m, 127.33m, -411, null },
                    { -588, 138.61m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 143.65m, 155.85m, 147.84m, -411, null },
                    { -587, 140.09m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 133.47m, 149.29m, 146.28m, -411, null },
                    { -586, 136.67m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 133.81m, 151.88m, 148.53m, -411, null },
                    { -585, 146.72m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 163.84m, 145.19m, 138.69m, -411, null },
                    { -584, 141.96m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.68m, 137.81m, 154.34m, -411, null },
                    { -583, 159.06m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 152.89m, 155.39m, 127.01m, -411, null },
                    { -582, 145.39m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.86m, 123.92m, 129.14m, -411, null },
                    { -581, 146.51m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 137.46m, 117.75m, 128.88m, -411, null },
                    { -580, 131.56m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.91m, 147.93m, 142.2m, -411, null },
                    { -579, 135.78m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.31m, 139.11m, 123.64m, -411, null },
                    { -578, 134.71m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.49m, 126.84m, 136.99m, -411, null },
                    { -577, 127.82m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.29m, 150.92m, 114.6m, -411, null },
                    { -576, 147.11m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.98m, 150.49m, 141.12m, -411, null },
                    { -575, 153.55m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 136.67m, 134.08m, 128.04m, -411, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -574, 153.14m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.62m, 144.95m, 129.27m, -411, null },
                    { -573, 125.3m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.87m, 132.39m, 142.01m, -411, null },
                    { -572, 151.45m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 118.16m, 140.32m, 119.99m, -411, null },
                    { -571, 124.25m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.52m, 128.57m, 144.49m, -411, null },
                    { -570, 141.68m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 156.61m, 150.89m, 125.77m, -411, null },
                    { -569, 133.37m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.39m, 126.79m, 137.25m, -411, null },
                    { -568, 139.96m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 133.7m, 127.69m, 131.94m, -411, null },
                    { -567, 133.84m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 125.86m, 147.14m, 145.88m, -411, null },
                    { -566, 130.96m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 130.2m, 133.7m, 153.65m, -411, null },
                    { -565, 135m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 149.63m, 126.32m, 127.13m, -411, null },
                    { -564, 146.66m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 139.63m, 149.22m, 140.84m, -411, null },
                    { -563, 143.06m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 122.54m, 134.43m, 147.85m, -411, null },
                    { -562, 130.84m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.59m, 139.29m, 148.31m, -411, null },
                    { -561, 129.94m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158.1m, 136.48m, 140.89m, -411, null },
                    { -560, 148.04m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 153.13m, 140.06m, 150.47m, -411, null },
                    { -559, 146.85m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 151.22m, 145.19m, 154.44m, -411, null },
                    { -558, 134.82m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 155.99m, 151.26m, 139.6m, -411, null },
                    { -557, 141.73m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 159.29m, 129.94m, 145.62m, -411, null },
                    { -556, 144.05m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 146.28m, 138.43m, 147.81m, -411, null },
                    { -555, 137.13m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 117.98m, 149.76m, 143.21m, -411, null },
                    { -554, 152.82m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.73m, 136.24m, 140.22m, -411, null },
                    { -553, 147.68m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.41m, 130.14m, 125.41m, -411, null },
                    { -552, 148.22m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.07m, 146.19m, 161.55m, -411, null },
                    { -551, 151.07m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 151.12m, 135.78m, 141.75m, -411, null },
                    { -550, 156.46m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.71m, 130.67m, 153.32m, -411, null },
                    { -549, 154.98m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 153.59m, 141.22m, 153.55m, -411, null },
                    { -548, 145.56m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.78m, 136.47m, 155.23m, -411, null },
                    { -547, 155.4m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.44m, 132.78m, 150.25m, -411, null },
                    { -546, 146m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 140.95m, 132.7m, 153.98m, -411, null },
                    { -545, 131.36m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 143.13m, 120.47m, 129.53m, -411, null },
                    { -544, 145.87m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.1m, 121.02m, 128.04m, -411, null },
                    { -543, 145.69m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 138.09m, 146.95m, 149.19m, -411, null },
                    { -542, 158.6m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151.14m, 152.48m, 149.13m, -411, null },
                    { -541, 152.89m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 131.21m, 141.87m, 134.75m, -411, null },
                    { -540, 133.97m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 121.04m, 137.1m, 156.36m, -411, null },
                    { -539, 157.66m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 143.8m, 153.98m, 142.51m, -411, null },
                    { -538, 150.39m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 151.57m, 154.23m, 131.47m, -411, null },
                    { -537, 137.7m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 161.2m, 142.17m, 135.9m, -411, null },
                    { -536, 147.4m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 119.48m, 134.61m, 144.83m, -411, null },
                    { -535, 150.4m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 129.96m, 161.89m, 127.92m, -411, null },
                    { -534, 132.25m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 136.19m, 149.29m, 130.85m, -411, null },
                    { -533, 147.16m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.82m, 161.07m, 124.47m, -411, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -532, 136.65m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 163.14m, 133.41m, 136.12m, -411, null },
                    { -531, 161.69m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 135.37m, 146.76m, 149.8m, -411, null },
                    { -530, 130.53m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 145.99m, 139.21m, 131.73m, -411, null },
                    { -529, 141.15m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 115.25m, 164.57m, 133.43m, -411, null },
                    { -528, 138.88m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.77m, 131.05m, 150.76m, -411, null },
                    { -527, 146.38m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 134.75m, 143.92m, 165.66m, -411, null },
                    { -526, 136.94m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 140.79m, 140.46m, 150.91m, -411, null },
                    { -525, 149.84m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 164.5m, 125.83m, 136.06m, -411, null },
                    { -524, 150.16m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 142.11m, 140.58m, 148.46m, -411, null },
                    { -523, 130.47m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 140.36m, 141.25m, 153.34m, -411, null },
                    { -522, 122.8m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 152.92m, 140.84m, 139.34m, -411, null },
                    { -521, 60.1m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.23m, 60.56m, 64.55m, -406, null },
                    { -520, 55.52m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.72m, 61.84m, 66.54m, -406, null },
                    { -519, 63.78m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.29m, 63.63m, 61.05m, -406, null },
                    { -518, 60.73m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.6m, 47.29m, 56.79m, -406, null },
                    { -517, 57.33m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.66m, 55.83m, 57.48m, -406, null },
                    { -516, 65.08m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.75m, 60.01m, 60.58m, -406, null },
                    { -515, 59.05m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.65m, 58.94m, 56.64m, -406, null },
                    { -514, 61.48m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.46m, 59.48m, 65.01m, -406, null },
                    { -513, 61.25m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.75m, 59.37m, 63.44m, -406, null },
                    { -512, 61.69m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.86m, 56m, 63.37m, -406, null },
                    { -511, 63.87m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.23m, 59.89m, 56.34m, -406, null },
                    { -510, 58.61m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.2m, 58.98m, 60.54m, -406, null },
                    { -509, 59.7m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.97m, 57.28m, 61.32m, -406, null },
                    { -508, 61.87m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.08m, 60.34m, 55.57m, -406, null },
                    { -507, 69.68m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.89m, 55.81m, 65.65m, -406, null },
                    { -506, 55.93m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.11m, 58.37m, 55.85m, -406, null },
                    { -505, 58.33m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.96m, 54.57m, 60.13m, -406, null },
                    { -504, 59.95m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.76m, 57.12m, 60.91m, -406, null },
                    { -503, 57.33m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.67m, 50.36m, 62.5m, -406, null },
                    { -502, 54.18m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.24m, 53.77m, 61.21m, -406, null },
                    { -501, 54.28m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.23m, 58.92m, 56.1m, -406, null },
                    { -500, 51.64m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.91m, 52m, 60.62m, -406, null },
                    { -499, 54.95m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.55m, 52.32m, 54.52m, -406, null },
                    { -498, 58.12m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.44m, 57.17m, 53.06m, -406, null },
                    { -497, 55.3m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.08m, 56.12m, 54.27m, -406, null },
                    { -496, 58.55m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.15m, 58.65m, 56.21m, -406, null },
                    { -495, 60.77m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.69m, 47.13m, 57.19m, -406, null },
                    { -494, 64.96m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.92m, 58.05m, 62.58m, -406, null },
                    { -493, 59.24m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.02m, 59.69m, 55.1m, -406, null },
                    { -492, 49.99m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.08m, 59.83m, 58.57m, -406, null },
                    { -491, 67.66m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.89m, 53.03m, 64.17m, -406, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -490, 63.67m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.03m, 56.7m, 55.73m, -406, null },
                    { -489, 61.18m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.38m, 62.18m, 57.27m, -406, null },
                    { -488, 56.72m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.46m, 60.94m, 50.69m, -406, null },
                    { -487, 60.07m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.22m, 60.21m, 62.67m, -406, null },
                    { -486, 55.88m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.13m, 64.1m, 54.92m, -406, null },
                    { -485, 59.84m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.45m, 57.87m, 62.04m, -406, null },
                    { -484, 56.47m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.58m, 52.09m, 61.04m, -406, null },
                    { -483, 53.59m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.22m, 70.58m, 57.64m, -406, null },
                    { -482, 61.88m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.13m, 63.41m, 59.59m, -406, null },
                    { -481, 61.51m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.9m, 60.92m, 56.93m, -406, null },
                    { -480, 55.92m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.72m, 60.37m, 65.61m, -406, null },
                    { -479, 52.54m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.6m, 57.99m, 62.66m, -406, null },
                    { -478, 56.58m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.49m, 57.16m, 53.2m, -406, null },
                    { -477, 64.87m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.12m, 52.42m, 64.97m, -406, null },
                    { -476, 63.57m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.49m, 54.71m, 64.75m, -406, null },
                    { -475, 62.09m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.67m, 67.23m, 62.82m, -406, null },
                    { -474, 65.66m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.59m, 58.76m, 56.09m, -406, null },
                    { -473, 61.23m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.32m, 60.84m, 57.45m, -406, null },
                    { -472, 62.24m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.59m, 50.77m, 60.23m, -406, null },
                    { -471, 62.4m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.05m, 60.62m, 69m, -406, null },
                    { -470, 62.87m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.36m, 61.97m, 62.39m, -406, null },
                    { -469, 56.49m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.08m, 61.06m, 72.54m, -406, null },
                    { -468, 64.19m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 64m, 67.16m, 57.27m, -406, null },
                    { -467, 64.34m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.48m, 65.61m, 53.14m, -406, null },
                    { -466, 66.25m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.99m, 58.25m, 63.34m, -406, null },
                    { -465, 68.04m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.64m, 70.47m, 57.26m, -406, null },
                    { -464, 60.1m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.48m, 59.67m, 57.54m, -406, null },
                    { -463, 60.63m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.72m, 45.93m, 53.26m, -406, null },
                    { -462, 61.24m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.29m, 77.38m, 69.02m, -406, null },
                    { -461, 52.48m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.4m, 61.26m, 65.52m, -406, null },
                    { -460, 60.19m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.11m, 61.4m, 57.46m, -406, null },
                    { -459, 71.58m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.68m, 60.38m, 63.93m, -406, null },
                    { -458, 62.6m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.14m, 66.49m, 53.31m, -406, null },
                    { -457, 67.29m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.02m, 49.63m, 63.13m, -406, null },
                    { -456, 58.54m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.86m, 59.95m, 66.66m, -406, null },
                    { -455, 57.25m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.51m, 56.21m, 59.83m, -406, null },
                    { -454, 71.26m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.23m, 61.6m, 65.22m, -406, null },
                    { -453, 67.59m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.76m, 63.89m, 65.7m, -406, null },
                    { -452, 62.77m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.85m, 68.27m, 49.66m, -406, null },
                    { -451, 69.59m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.62m, 62.42m, 56.1m, -406, null },
                    { -450, 62.81m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.45m, 57.02m, 60.53m, -406, null },
                    { -449, 58.96m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.08m, 58.08m, 60.31m, -406, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -448, 61.13m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.72m, 65.07m, 57.25m, -406, null },
                    { -447, 58.1m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.02m, 64.21m, 58.99m, -406, null },
                    { -446, 57.23m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.19m, 59.88m, 56.09m, -406, null },
                    { -445, 52.19m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.84m, 60.21m, 59.54m, -403, null },
                    { -444, 60.47m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.2m, 51.79m, 47.91m, -403, null },
                    { -443, 55.03m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.9m, 61.19m, 51.6m, -403, null },
                    { -442, 60.81m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.03m, 57.42m, 56.47m, -403, null },
                    { -441, 62.44m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.66m, 64.83m, 50.8m, -403, null },
                    { -440, 62.93m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.84m, 50.13m, 56.95m, -403, null },
                    { -439, 56.18m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.88m, 48.32m, 54.57m, -403, null },
                    { -438, 60.36m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.54m, 50.49m, 54.59m, -403, null },
                    { -437, 51.91m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.41m, 53.76m, 47.42m, -403, null },
                    { -436, 47.92m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, 60.68m, 52.97m, -403, null },
                    { -435, 47.72m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.87m, 55.96m, 50.74m, -403, null },
                    { -434, 57.88m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.06m, 54.93m, 54.03m, -403, null },
                    { -433, 54.48m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.57m, 55.52m, 54.4m, -403, null },
                    { -432, 55.12m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.11m, 47.73m, 55.71m, -403, null },
                    { -431, 57.24m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.18m, 57.4m, 58.1m, -403, null },
                    { -430, 51.88m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.85m, 55.62m, 49.03m, -403, null },
                    { -429, 46.35m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.78m, 52.2m, 60.05m, -403, null },
                    { -428, 51.72m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.55m, 50.6m, 47.72m, -403, null },
                    { -427, 46.6m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.96m, 57.72m, 61.22m, -403, null },
                    { -426, 52.85m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.96m, 53.39m, 52.5m, -403, null },
                    { -425, 60.56m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.57m, 52.28m, 55.06m, -403, null },
                    { -424, 53.59m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.08m, 53.82m, 67.14m, -403, null },
                    { -423, 45.97m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.93m, 53.62m, 57.15m, -403, null },
                    { -422, 53.38m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.43m, 53.98m, 52.83m, -403, null },
                    { -421, 57.89m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.81m, 49.74m, 57.65m, -403, null },
                    { -420, 42.8m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.28m, 56.61m, 53.85m, -403, null },
                    { -419, 44.31m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.78m, 49.53m, 55.19m, -403, null },
                    { -418, 49.99m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.18m, 54.4m, 57.98m, -403, null },
                    { -417, 48.59m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.23m, 55.84m, 52.66m, -403, null },
                    { -416, 47m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.78m, 48.18m, 60.2m, -403, null },
                    { -415, 56.36m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.87m, 52.05m, 58.21m, -403, null },
                    { -414, 55.79m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.74m, 54.28m, 51.31m, -403, null },
                    { -413, 51.34m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.9m, 54.22m, 62.58m, -403, null },
                    { -412, 58.67m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.86m, 52.93m, 47.45m, -403, null },
                    { -411, 50.25m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.27m, 58.23m, 53.74m, -403, null },
                    { -410, 51.78m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.65m, 51.44m, 49.73m, -403, null },
                    { -409, 52.01m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.65m, 58.93m, 63.73m, -403, null },
                    { -408, 54.32m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.78m, 52.35m, 64.86m, -403, null },
                    { -407, 53.82m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.73m, 52.66m, 55.87m, -403, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -406, 49.9m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.95m, 51.73m, 58.1m, -403, null },
                    { -405, 45.61m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.23m, 58.29m, 53.33m, -403, null },
                    { -404, 55.22m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.57m, 56.45m, 53.84m, -403, null },
                    { -403, 50.78m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.81m, 55.69m, 56.05m, -403, null },
                    { -402, 56.26m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.58m, 55.63m, 51.74m, -403, null },
                    { -401, 46.92m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.3m, 47.02m, 60.3m, -403, null },
                    { -400, 50.79m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.87m, 58.15m, 60.32m, -403, null },
                    { -399, 59.49m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.71m, 50.65m, 49.32m, -403, null },
                    { -398, 57.57m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.03m, 55.79m, 56.13m, -403, null },
                    { -397, 57.44m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.79m, 48.03m, 53.9m, -403, null },
                    { -396, 60.32m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.99m, 61.22m, 53.61m, -403, null },
                    { -395, 55.95m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.42m, 63.14m, 52.86m, -403, null },
                    { -394, 50.91m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.44m, 49.14m, 53.04m, -403, null },
                    { -393, 52.11m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.11m, 50.55m, 54.38m, -403, null },
                    { -392, 56.97m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.94m, 52.57m, 52.46m, -403, null },
                    { -391, 53.7m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.17m, 54.65m, 58.95m, -403, null },
                    { -390, 47.26m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.09m, 50.31m, 50.67m, -403, null },
                    { -389, 49.62m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.61m, 47.95m, 51.32m, -403, null },
                    { -388, 50.51m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.31m, 55.82m, 51.39m, -403, null },
                    { -387, 52.99m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.99m, 42.96m, 51.87m, -403, null },
                    { -386, 51.58m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 48m, 50.24m, 58.16m, -403, null },
                    { -385, 58.73m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.4m, 51.73m, 49.35m, -403, null },
                    { -384, 50.81m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.6m, 50.17m, 50.49m, -403, null },
                    { -383, 54.49m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.57m, 53.08m, 45.31m, -403, null },
                    { -382, 51.8m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.4m, 48.6m, 55.99m, -403, null },
                    { -381, 51.2m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.92m, 51.05m, 52.96m, -403, null },
                    { -380, 47.36m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.37m, 49.86m, 48.48m, -403, null },
                    { -379, 56.04m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.34m, 53.68m, 51.13m, -403, null },
                    { -378, 56.91m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.49m, 43.35m, 56.8m, -403, null },
                    { -377, 49.61m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.85m, 51.54m, 54.47m, -403, null },
                    { -376, 48.56m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.53m, 54.41m, 52.59m, -403, null },
                    { -375, 49.99m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.35m, 52.44m, 51.92m, -403, null },
                    { -374, 56.8m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.52m, 44.48m, 46.37m, -403, null },
                    { -373, 56.62m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.87m, 47.85m, 52.69m, -403, null },
                    { -372, 46.04m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.59m, 49.48m, 52.53m, -403, null },
                    { -371, 54.93m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.75m, 51.49m, 46.25m, -403, null },
                    { -370, 48.71m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.94m, 55.02m, 48.88m, -403, null },
                    { -369, 83.73m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.78m, 62.57m, 60.53m, -400, null },
                    { -368, 70.85m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.79m, 71.7m, 74.2m, -400, null },
                    { -367, 68.13m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.3m, 63.18m, 66.92m, -400, null },
                    { -366, 72.08m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.15m, 64.46m, 59.03m, -400, null },
                    { -365, 66.76m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.14m, 63.15m, 77.83m, -400, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -364, 66.8m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.3m, 62.01m, 76.26m, -400, null },
                    { -363, 63.67m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.1m, 76.03m, 63.06m, -400, null },
                    { -362, 64.41m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.44m, 67.37m, 77.45m, -400, null },
                    { -361, 62.74m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.67m, 65.29m, 75.74m, -400, null },
                    { -360, 63.3m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.01m, 67.33m, 65.26m, -400, null },
                    { -359, 63.52m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.24m, 66.75m, 68.41m, -400, null },
                    { -358, 62.75m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.75m, 69.22m, 69.57m, -400, null },
                    { -357, 66.59m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.36m, 61.23m, 65.58m, -400, null },
                    { -356, 58.53m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.36m, 65.39m, 64.6m, -400, null },
                    { -355, 76.79m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.43m, 66.84m, 68.6m, -400, null },
                    { -354, 58.54m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.08m, 71.67m, 74.01m, -400, null },
                    { -353, 57.01m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.56m, 61.65m, 67.02m, -400, null },
                    { -352, 73.12m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.9m, 74.98m, 72.66m, -400, null },
                    { -351, 69.41m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.76m, 69.69m, 69.97m, -400, null },
                    { -350, 63.58m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.23m, 68.55m, 69.78m, -400, null },
                    { -349, 79.2m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.16m, 74.44m, 73.16m, -400, null },
                    { -348, 68.17m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.13m, 66.33m, 75.7m, -400, null },
                    { -347, 64.3m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.23m, 69.48m, 63.3m, -400, null },
                    { -346, 68.5m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.23m, 56.53m, 65.27m, -400, null },
                    { -345, 63.92m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.71m, 61.57m, 67.92m, -400, null },
                    { -344, 66.68m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.33m, 67.66m, 65.08m, -400, null },
                    { -343, 61.59m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.07m, 62.17m, 73.12m, -400, null },
                    { -342, 63.16m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.48m, 67.56m, 73.57m, -400, null },
                    { -341, 68.34m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.8m, 62.29m, 64.76m, -400, null },
                    { -340, 71.99m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.05m, 53.53m, 68.27m, -400, null },
                    { -339, 66.83m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.09m, 65.64m, 62.06m, -400, null },
                    { -338, 69.94m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 62.94m, 55.48m, 76.01m, -400, null },
                    { -337, 62.97m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.69m, 68.19m, 58.81m, -400, null },
                    { -336, 67.62m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.49m, 66.44m, 64.3m, -400, null },
                    { -335, 65.61m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.7m, 73.54m, 67.81m, -400, null },
                    { -334, 71.57m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.35m, 71.41m, 81.96m, -400, null },
                    { -333, 72.49m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.72m, 68.5m, 68.71m, -400, null },
                    { -332, 68.25m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.19m, 68.77m, 76.41m, -400, null },
                    { -331, 71.01m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.52m, 79.86m, 77.27m, -400, null },
                    { -330, 69.11m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.61m, 69.34m, 71.65m, -400, null },
                    { -329, 70.3m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.27m, 62.14m, 80.57m, -400, null },
                    { -328, 78.08m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.97m, 76.13m, 62.55m, -400, null },
                    { -327, 60.84m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.91m, 63.21m, 73.87m, -400, null },
                    { -326, 81.42m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.69m, 65m, 77.18m, -400, null },
                    { -325, 76.51m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.98m, 71.24m, 75.16m, -400, null },
                    { -324, 71.5m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.06m, 75.36m, 71.91m, -400, null },
                    { -323, 75.25m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.42m, 65.32m, 77.62m, -400, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -322, 70.26m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.22m, 72.13m, 63.47m, -400, null },
                    { -321, 68.46m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.04m, 71.63m, 71.01m, -400, null },
                    { -320, 76.62m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.93m, 78.49m, 68.68m, -400, null },
                    { -319, 71.54m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.24m, 80.24m, 73.72m, -400, null },
                    { -318, 78.94m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.89m, 63.09m, 66.52m, -400, null },
                    { -317, 76.75m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.52m, 67.67m, 69.6m, -400, null },
                    { -316, 77.13m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.04m, 69.33m, 57.81m, -400, null },
                    { -315, 78.25m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.53m, 74.55m, 70.82m, -400, null },
                    { -314, 71.24m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.35m, 75.38m, 76.48m, -400, null },
                    { -313, 79.28m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.5m, 75.3m, 76.11m, -400, null },
                    { -312, 68.58m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.2m, 73.01m, 76.94m, -400, null },
                    { -311, 66.58m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.75m, 76.43m, 65.24m, -400, null },
                    { -310, 66.27m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.71m, 71.48m, 73.57m, -400, null },
                    { -309, 82.26m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.13m, 72.48m, 74.54m, -400, null },
                    { -308, 69.71m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.02m, 73.55m, 70.25m, -400, null },
                    { -307, 74.76m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.21m, 71.16m, 66.88m, -400, null },
                    { -306, 67.41m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.02m, 66.3m, 79.57m, -400, null },
                    { -305, 70.61m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.75m, 64.5m, 73.01m, -400, null },
                    { -304, 68.83m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.64m, 67.36m, 70.01m, -400, null },
                    { -303, 63.23m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.5m, 77.94m, 71.17m, -400, null },
                    { -302, 70.95m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.36m, 73.38m, 61.84m, -400, null },
                    { -301, 64.36m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.83m, 65.68m, 63.32m, -400, null },
                    { -300, 75.07m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.88m, 69.11m, 68.27m, -400, null },
                    { -299, 77.24m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.12m, 67.81m, 68.38m, -400, null },
                    { -298, 77.63m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.24m, 74.05m, 71.6m, -400, null },
                    { -297, 60.5m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 64.92m, 68.38m, 67.05m, -400, null },
                    { -296, 60.76m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.7m, 71.92m, 63.87m, -400, null },
                    { -295, 67.7m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.45m, 58.47m, 61.68m, -400, null },
                    { -294, 65.69m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.7m, 66.34m, 63.11m, -400, null },
                    { -293, 60.98m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.18m, 57.62m, 51.74m, -397, null },
                    { -292, 46.71m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.27m, 47.98m, 55.6m, -397, null },
                    { -291, 53.61m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.05m, 50.05m, 48.06m, -397, null },
                    { -290, 48.34m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.49m, 51.95m, 52.9m, -397, null },
                    { -289, 57.2m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.68m, 53.5m, 48.76m, -397, null },
                    { -288, 52.46m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.91m, 51.37m, 56.72m, -397, null },
                    { -287, 57.99m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.93m, 54.21m, 58.86m, -397, null },
                    { -286, 53.06m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.78m, 55.57m, 57.91m, -397, null },
                    { -285, 48.4m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.69m, 51.48m, 55.51m, -397, null },
                    { -284, 55.37m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.56m, 55.13m, 54.31m, -397, null },
                    { -283, 54.04m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.17m, 54.99m, 47.47m, -397, null },
                    { -282, 52.25m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.3m, 56.39m, 58.8m, -397, null },
                    { -281, 55.24m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.44m, 50.53m, 52.17m, -397, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -280, 53.27m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.86m, 61.76m, 47.3m, -397, null },
                    { -279, 48.4m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.79m, 51.89m, 55.44m, -397, null },
                    { -278, 55.94m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.18m, 52.86m, 47.76m, -397, null },
                    { -277, 53.41m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.27m, 55.24m, 47.05m, -397, null },
                    { -276, 51.82m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.81m, 46.11m, 45.27m, -397, null },
                    { -275, 49.57m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.83m, 52.17m, 48.76m, -397, null },
                    { -274, 46.91m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.57m, 52.19m, 47.92m, -397, null },
                    { -273, 50.66m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.32m, 47.56m, 52.62m, -397, null },
                    { -272, 46.44m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.13m, 51.05m, 45.38m, -397, null },
                    { -271, 57.1m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.13m, 52.92m, 47.1m, -397, null },
                    { -270, 49.8m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.94m, 52.92m, 44.05m, -397, null },
                    { -269, 51.33m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.03m, 49.14m, 47.18m, -397, null },
                    { -268, 45.12m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.68m, 50.37m, 49.59m, -397, null },
                    { -267, 53.47m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.22m, 47.07m, 49.87m, -397, null },
                    { -266, 54.55m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.3m, 49.33m, 54.63m, -397, null },
                    { -265, 52.05m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.66m, 51.78m, 51.4m, -397, null },
                    { -264, 52.73m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.01m, 45.53m, 45.64m, -397, null },
                    { -263, 50.43m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.82m, 54.25m, 49.04m, -397, null },
                    { -262, 59.09m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.33m, 42.33m, 50.5m, -397, null },
                    { -261, 52.69m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.96m, 50.14m, 49.85m, -397, null },
                    { -260, 51.7m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.06m, 52.92m, 58.88m, -397, null },
                    { -259, 47.59m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.49m, 51.77m, 50.43m, -397, null },
                    { -258, 50.3m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.04m, 55.63m, 47.15m, -397, null },
                    { -257, 54.77m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.37m, 54.63m, 46.39m, -397, null },
                    { -256, 48.67m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.6m, 50.07m, 52.52m, -397, null },
                    { -255, 53.62m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.39m, 47.68m, 51.5m, -397, null },
                    { -254, 49.97m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.98m, 51.89m, 52.84m, -397, null },
                    { -253, 49.95m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.53m, 47.02m, 52.01m, -397, null },
                    { -252, 55.67m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.69m, 53.49m, 52.81m, -397, null },
                    { -251, 51.06m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.36m, 54.41m, 57.22m, -397, null },
                    { -250, 53.24m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.32m, 56.23m, 55.52m, -397, null },
                    { -249, 52.18m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.55m, 51.82m, 49.67m, -397, null },
                    { -248, 52.84m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 48m, 54.05m, 51.23m, -397, null },
                    { -247, 53.37m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 59.39m, 56.6m, 56.22m, -397, null },
                    { -246, 53.6m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.88m, 55.73m, 50.47m, -397, null },
                    { -245, 51.36m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.3m, 47.6m, 50.08m, -397, null },
                    { -244, 53.59m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.3m, 55.23m, 52.22m, -397, null },
                    { -243, 50.63m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.42m, 49.92m, 51.58m, -397, null },
                    { -242, 54.67m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.52m, 54.14m, 52.88m, -397, null },
                    { -241, 46.48m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 55.22m, 52.22m, 51.29m, -397, null },
                    { -240, 52.89m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.89m, 57.8m, 62.67m, -397, null },
                    { -239, 53.82m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.79m, 48.16m, 54.21m, -397, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -238, 55.76m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.16m, 52.73m, 50.99m, -397, null },
                    { -237, 53.03m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.68m, 49.62m, 48.82m, -397, null },
                    { -236, 48.14m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 57.51m, 54.13m, 50.58m, -397, null },
                    { -235, 54.02m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.16m, 49.85m, 62.24m, -397, null },
                    { -234, 58.22m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.22m, 50.85m, 50.67m, -397, null },
                    { -233, 51.81m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.49m, 53.4m, 47.52m, -397, null },
                    { -232, 48.9m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.67m, 51.85m, 51.9m, -397, null },
                    { -231, 48.83m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.05m, 55.39m, 53.99m, -397, null },
                    { -230, 48.56m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.68m, 53.87m, 50.64m, -397, null },
                    { -229, 46.83m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 56.52m, 47.87m, 52.38m, -397, null },
                    { -228, 53.94m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.04m, 51.61m, 51.31m, -397, null },
                    { -227, 52.1m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.46m, 54.14m, 44.52m, -397, null },
                    { -226, 49.59m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 46.65m, 52.81m, 53.27m, -397, null },
                    { -225, 43.26m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 47.36m, 52.32m, 53.21m, -397, null },
                    { -224, 52.8m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 58.13m, 50.63m, 55.75m, -397, null },
                    { -223, 52.01m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.32m, 55.25m, 48.32m, -397, null },
                    { -222, 52.31m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.76m, 47.85m, 51.11m, -397, null },
                    { -221, 49.81m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.74m, 48.05m, 45.08m, -397, null },
                    { -220, 56.55m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.31m, 46.66m, 53.57m, -397, null },
                    { -219, 46.93m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.69m, 41.66m, 46.08m, -397, null },
                    { -218, 50.37m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.55m, 47.63m, 52.61m, -397, null },
                    { -217, 75.05m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.68m, 64.06m, 72.8m, -392, null },
                    { -216, 66.7m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.74m, 78.17m, 71.82m, -392, null },
                    { -215, 75.04m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.15m, 69.65m, 65.21m, -392, null },
                    { -214, 77.45m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.09m, 68.81m, 82.19m, -392, null },
                    { -213, 71.78m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.29m, 68.72m, 75.72m, -392, null },
                    { -212, 76.61m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.15m, 77.88m, 72.35m, -392, null },
                    { -211, 79.24m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 83.98m, 76.71m, 75.22m, -392, null },
                    { -210, 74.92m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.33m, 77.36m, 83.38m, -392, null },
                    { -209, 81.28m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.5m, 66.16m, 72.66m, -392, null },
                    { -208, 66.53m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.55m, 81.81m, 79.08m, -392, null },
                    { -207, 85.67m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.64m, 83.5m, 81.08m, -392, null },
                    { -206, 78m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.18m, 76.59m, 73.97m, -392, null },
                    { -205, 78.04m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.54m, 77m, 88.73m, -392, null },
                    { -204, 69.02m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.11m, 78.78m, 83.66m, -392, null },
                    { -203, 78.23m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 65.25m, 77.69m, 75.25m, -392, null },
                    { -202, 70.13m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.25m, 74.67m, 66.97m, -392, null },
                    { -201, 72.3m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.16m, 75.04m, 87.59m, -392, null },
                    { -200, 80.09m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.45m, 83.67m, 72.7m, -392, null },
                    { -199, 62.63m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.09m, 76.6m, 71.64m, -392, null },
                    { -198, 87.88m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.86m, 86.35m, 77.78m, -392, null },
                    { -197, 71.4m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.54m, 81.95m, 71.93m, -392, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -196, 70.93m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 86.26m, 67.51m, 73.5m, -392, null },
                    { -195, 67.23m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.54m, 75.96m, 77.42m, -392, null },
                    { -194, 80.35m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.42m, 66.83m, 74.39m, -392, null },
                    { -193, 64.04m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 67.06m, 67.24m, 77.82m, -392, null },
                    { -192, 64.64m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.6m, 77.59m, 87.45m, -392, null },
                    { -191, 71.96m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.94m, 77.52m, 75.51m, -392, null },
                    { -190, 72.81m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.14m, 73.33m, 71.31m, -392, null },
                    { -189, 65.68m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.09m, 85.94m, 72.1m, -392, null },
                    { -188, 73.64m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.71m, 76.61m, 54.9m, -392, null },
                    { -187, 76.01m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.92m, 79.94m, 77.17m, -392, null },
                    { -186, 66.44m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.12m, 78.02m, 79.06m, -392, null },
                    { -185, 65.06m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.28m, 80.48m, 69.01m, -392, null },
                    { -184, 81.99m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.08m, 83.83m, 77.28m, -392, null },
                    { -183, 73.01m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.83m, 81.44m, 72.32m, -392, null },
                    { -182, 76.39m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.89m, 77.48m, 80.23m, -392, null },
                    { -181, 70.72m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 68.86m, 80.34m, 76.27m, -392, null },
                    { -180, 77.65m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.72m, 74.99m, 68.96m, -392, null },
                    { -179, 69.99m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 70.17m, 73.03m, 64.2m, -392, null },
                    { -178, 73.38m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.29m, 72.6m, 71.87m, -392, null },
                    { -177, 71.81m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 61.58m, 76.55m, 71.65m, -392, null },
                    { -176, 69.38m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.28m, 64.47m, 63.32m, -392, null },
                    { -175, 79.47m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 63.18m, 61.16m, 80.03m, -392, null },
                    { -174, 76.59m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.94m, 82.35m, 71.35m, -392, null },
                    { -173, 74.01m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.79m, 71.48m, 69.13m, -392, null },
                    { -172, 86.12m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.81m, 72.74m, 74.51m, -392, null },
                    { -171, 62.86m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.18m, 68.03m, 69.72m, -392, null },
                    { -170, 57.73m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.43m, 67.96m, 80.33m, -392, null },
                    { -169, 82.81m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.67m, 71.89m, 72.17m, -392, null },
                    { -168, 75.51m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.45m, 65.58m, 71.46m, -392, null },
                    { -167, 74m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.31m, 69.34m, 66m, -392, null },
                    { -166, 74.78m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.58m, 75.43m, 71.41m, -392, null },
                    { -165, 80.59m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.29m, 74.45m, 76.52m, -392, null },
                    { -164, 74.21m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.79m, 79.29m, 85.99m, -392, null },
                    { -163, 80.4m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.49m, 74.47m, 67.12m, -392, null },
                    { -162, 78.1m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.79m, 78.54m, 80.31m, -392, null },
                    { -161, 80.16m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.57m, 76.27m, 74.6m, -392, null },
                    { -160, 73.01m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.7m, 69.88m, 75.36m, -392, null },
                    { -159, 83.41m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.7m, 74.18m, 84.78m, -392, null },
                    { -158, 82.14m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.2m, 75.24m, 71.06m, -392, null },
                    { -157, 79.26m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 72.92m, 75m, 83.27m, -392, null },
                    { -156, 73.41m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.11m, 72.13m, 72.92m, -392, null },
                    { -155, 80.98m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.27m, 75.57m, 74.3m, -392, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -154, 80.4m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.99m, 84.01m, 77.78m, -392, null },
                    { -153, 62.88m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.52m, 77.93m, 80.14m, -392, null },
                    { -152, 75.3m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.79m, 68.16m, 84.74m, -392, null },
                    { -151, 73.63m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.99m, 77.28m, 70.14m, -392, null },
                    { -150, 75.14m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 86.26m, 85.41m, 75.19m, -392, null },
                    { -149, 72.43m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.02m, 66.26m, 77.34m, -392, null },
                    { -148, 68.92m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.57m, 87.58m, 81.67m, -392, null },
                    { -147, 86.68m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.9m, 77.14m, 80.91m, -392, null },
                    { -146, 74.9m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 71.45m, 81.66m, 71.84m, -392, null },
                    { -145, 71.63m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.03m, 68.75m, 76.58m, -392, null },
                    { -144, 72.47m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.41m, 76.65m, 86.52m, -392, null },
                    { -143, 81.3m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.13m, 76m, 76.51m, -392, null },
                    { -142, 80.79m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.47m, 78.44m, 73.39m, -392, null },
                    { -141, 318.36m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 275.24m, 323.71m, 283.81m, -325, null },
                    { -140, 300.93m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 294.75m, 310.68m, 304.03m, -325, null },
                    { -139, 297.67m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 297.36m, 275.98m, 251.74m, -325, null },
                    { -138, 306.35m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 309.01m, 274.05m, 317.37m, -325, null },
                    { -137, 317.63m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 298.24m, 312.04m, 324.2m, -325, null },
                    { -136, 276.82m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 291.44m, 270.88m, 273.84m, -325, null },
                    { -135, 284.91m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 318.89m, 248.63m, 289.42m, -325, null },
                    { -134, 258.09m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 323.62m, 244.79m, 246.85m, -325, null },
                    { -133, 284.6m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 269.3m, 303.87m, 293.79m, -325, null },
                    { -132, 268.13m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 312.82m, 271.03m, 278.26m, -325, null },
                    { -131, 254.82m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 284.31m, 276.4m, 251.64m, -325, null },
                    { -130, 240.76m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 244.23m, 278.34m, 261.14m, -325, null },
                    { -129, 230.46m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 280.91m, 244.3m, 293.27m, -325, null },
                    { -128, 259.06m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 264.54m, 244.93m, 246.59m, -325, null },
                    { -127, 259.87m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 217.8m, 260.35m, 280.19m, -325, null },
                    { -126, 217.4m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 268.31m, 267.26m, 286.32m, -325, null },
                    { -125, 266.17m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 249.98m, 243.22m, 272.88m, -325, null },
                    { -124, 262.04m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 229.53m, 275.59m, 256.52m, -325, null },
                    { -123, 237.88m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 262.58m, 245.5m, 225.08m, -325, null },
                    { -122, 212.9m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 276.93m, 278.46m, 244.22m, -325, null },
                    { -121, 233.19m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 219.96m, 220.83m, 269.46m, -325, null },
                    { -120, 238.9m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 262.48m, 237.51m, 245.82m, -325, null },
                    { -119, 260.45m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 216.76m, 229.44m, 247.72m, -325, null },
                    { -118, 235.43m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 275.56m, 227.13m, 246.71m, -325, null },
                    { -117, 311.52m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 277.15m, 259.23m, 301.16m, -325, null },
                    { -116, 282.37m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 302.51m, 272.15m, 276.18m, -325, null },
                    { -115, 319.35m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 328.47m, 298.91m, 284.94m, -325, null },
                    { -114, 262.93m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 285.35m, 265.58m, 301.53m, -325, null },
                    { -113, 224.67m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 262.63m, 242.23m, 223.08m, -325, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -112, 256.72m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 265.55m, 232.61m, 279.27m, -325, null },
                    { -111, 241.41m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 236.61m, 232.96m, 225.38m, -325, null },
                    { -110, 234.56m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 231.06m, 233.73m, 223.53m, -325, null },
                    { -109, 223.62m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 210.81m, 182.31m, 207.47m, -325, null },
                    { -108, 224.27m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 252.18m, 207.51m, 269.76m, -325, null },
                    { -107, 301.59m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 310.29m, 294.56m, 253.25m, -325, null },
                    { -106, 281.94m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 272.79m, 280.98m, 259.92m, -325, null },
                    { -105, 254.33m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 270.93m, 259.77m, 284.13m, -325, null },
                    { -104, 240.88m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 250.03m, 256.24m, 295.22m, -325, null },
                    { -103, 303.12m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 284.84m, 280m, 295.43m, -325, null },
                    { -102, 289.45m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 278.71m, 287.13m, 276.98m, -325, null },
                    { -101, 300.91m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 277.75m, 282.13m, 330.45m, -325, null },
                    { -100, 290.71m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 282.7m, 258.19m, 257.09m, -325, null },
                    { -99, 268.83m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 285.88m, 267.17m, 251.75m, -325, null },
                    { -98, 312.38m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 267.56m, 265.34m, 279.89m, -325, null },
                    { -97, 244.95m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 283.57m, 289.65m, 274.04m, -325, null },
                    { -96, 294.44m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 254.41m, 313.36m, 242.22m, -325, null },
                    { -95, 255.54m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 276.08m, 276.03m, 275.44m, -325, null },
                    { -94, 290.93m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 302.43m, 265.97m, 272.06m, -325, null },
                    { -93, 231.44m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 318.89m, 267.28m, 284.05m, -325, null },
                    { -92, 287.15m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 314.79m, 262.21m, 250.35m, -325, null },
                    { -91, 261.45m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 269.86m, 236m, 291.2m, -325, null },
                    { -90, 246.12m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 227.85m, 226.71m, 253.29m, -325, null },
                    { -89, 248.95m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 282.97m, 280.5m, 221.89m, -325, null },
                    { -88, 214.27m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 248.48m, 245.55m, 258.48m, -325, null },
                    { -87, 267.35m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 251.72m, 238.31m, 221.32m, -325, null },
                    { -86, 236.18m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 249.71m, 221.5m, 223.54m, -325, null },
                    { -85, 249.69m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 225.81m, 261.24m, 238.23m, -325, null },
                    { -84, 253.86m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 247.81m, 220.82m, 253.17m, -325, null },
                    { -83, 236.64m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 247.84m, 227.37m, 231.36m, -325, null },
                    { -82, 223.04m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 245.74m, 240.98m, 216.61m, -325, null },
                    { -81, 258.86m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 241.5m, 242.7m, 229.45m, -325, null },
                    { -80, 238.32m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 251.81m, 227.4m, 253.89m, -325, null },
                    { -79, 215.05m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 207.58m, 217.93m, 241.49m, -325, null },
                    { -78, 195.77m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 222.98m, 218.57m, 210.43m, -325, null },
                    { -77, 238.92m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 209.13m, 208.1m, 252.5m, -325, null },
                    { -76, 221.09m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 248.19m, 260.68m, 258.18m, -325, null },
                    { -75, 274.92m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 226.6m, 218.96m, 238.22m, -325, null },
                    { -74, 255.97m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 235.2m, 258.24m, 226.58m, -325, null },
                    { -73, 240.6m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 255.32m, 231.7m, 229.36m, -325, null },
                    { -72, 260.03m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 283.07m, 261.41m, 285.19m, -325, null },
                    { -71, 246.04m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 246.94m, 267.72m, 302.03m, -325, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -70, 255.36m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 263.83m, 247.39m, 243.89m, -325, null },
                    { -69, 268.37m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 278.19m, 266.94m, 247.07m, -325, null },
                    { -68, 226.15m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 281.55m, 220.32m, 272.61m, -325, null },
                    { -67, 281.69m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 249.16m, 291.41m, 257.81m, -325, null },
                    { -66, 259.06m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 231.51m, 254.68m, 252.22m, -325, null },
                    { -65, 87.96m, new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.72m, 80.26m, 99.09m, -315, null },
                    { -64, 96.15m, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.23m, 84.69m, 85.74m, -315, null },
                    { -63, 89.77m, new DateTime(2023, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 96.25m, 98.07m, 88.56m, -315, null },
                    { -62, 87.15m, new DateTime(2023, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.57m, 91.47m, 102.34m, -315, null },
                    { -61, 100.92m, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.43m, 97.73m, 91.75m, -315, null },
                    { -60, 102.42m, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.66m, 99.03m, 98.55m, -315, null },
                    { -59, 94.67m, new DateTime(2023, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.17m, 81.25m, 83.24m, -315, null },
                    { -58, 100.92m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.93m, 84.41m, 89.26m, -315, null },
                    { -57, 96.57m, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 96.98m, 108.89m, 100.21m, -315, null },
                    { -56, 98.36m, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 93.78m, 100.06m, 91.46m, -315, null },
                    { -55, 96.48m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.66m, 100.16m, 96.36m, -315, null },
                    { -54, 105.68m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.46m, 98.71m, 94.33m, -315, null },
                    { -53, 97.61m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 99.14m, 103.23m, 99.08m, -315, null },
                    { -52, 100.94m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 107.15m, 96.46m, 95.43m, -315, null },
                    { -51, 90.38m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 97.13m, 94.47m, 105.86m, -315, null },
                    { -50, 103.24m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 96.78m, 96.12m, 100.71m, -315, null },
                    { -49, 96.78m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 105.88m, 113.59m, 105.84m, -315, null },
                    { -48, 93.91m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.98m, 90.94m, 106.27m, -315, null },
                    { -47, 89.91m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 102.79m, 90.34m, 97.81m, -315, null },
                    { -46, 102.21m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 103.7m, 103.69m, 86.13m, -315, null },
                    { -45, 112.86m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 95.28m, 89.6m, 76.38m, -315, null },
                    { -44, 94.61m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 92.82m, 83.11m, 82.01m, -315, null },
                    { -43, 87.13m, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.63m, 93.72m, 91.64m, -315, null },
                    { -42, 93.76m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.64m, 74.51m, 79.62m, -315, null },
                    { -41, 83.17m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 104.13m, 92.58m, 85m, -315, null },
                    { -40, 81.45m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.03m, 85.42m, 87.19m, -315, null },
                    { -39, 78.63m, new DateTime(2023, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.2m, 85.14m, 94.37m, -315, null },
                    { -38, 110.64m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 98.35m, 85.54m, 99.41m, -315, null },
                    { -37, 72.65m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.43m, 80.27m, 76.53m, -315, null },
                    { -36, 85.45m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.78m, 81.7m, 75.78m, -315, null },
                    { -35, 79.03m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 83.62m, 90.96m, 89.06m, -315, null },
                    { -34, 83.91m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 98.78m, 83.66m, 85.32m, -315, null },
                    { -33, 82.67m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 84.54m, 86.02m, 80.5m, -315, null },
                    { -32, 84.27m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.83m, 86.06m, 78.04m, -315, null },
                    { -31, 78.2m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.02m, 74.99m, 79.47m, -315, null },
                    { -30, 71.05m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.22m, 80.04m, 77m, -315, null },
                    { -29, 82.74m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 88.39m, 68.93m, 87.4m, -315, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                columns: new[] { "PriceID", "PriceClose", "PriceDate", "PriceHigh", "PriceLow", "PriceOpen", "SecurityID", "Volume" },
                values: new object[,]
                {
                    { -28, 78.83m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 96.7m, 80.13m, 85.66m, -315, null },
                    { -27, 84.23m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.58m, 83.55m, 85.44m, -315, null },
                    { -26, 82.42m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 81.58m, 79.64m, 71.28m, -315, null },
                    { -25, 87.7m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.25m, 77.06m, 80.2m, -315, null },
                    { -24, 83.97m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.88m, 74.65m, 80.07m, -315, null },
                    { -23, 81.43m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.39m, 69.01m, 76.72m, -315, null },
                    { -22, 69.58m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.55m, 73.15m, 73.76m, -315, null },
                    { -21, 73.14m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.47m, 74.69m, 75.38m, -315, null },
                    { -20, 81.32m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 82.67m, 81.91m, 77.39m, -315, null },
                    { -19, 77.68m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.84m, 82.13m, 75.86m, -315, null },
                    { -18, 77.93m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.49m, 74.59m, 89.96m, -315, null },
                    { -17, 80.46m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.6m, 60.56m, 69.31m, -315, null },
                    { -16, 88.95m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.57m, 80.75m, 87.33m, -315, null },
                    { -15, 83.56m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.11m, 83.63m, 86.16m, -315, null },
                    { -14, 91.21m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.71m, 74.1m, 74.95m, -315, null },
                    { -13, 87.34m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 74.02m, 70.2m, 74.16m, -315, null },
                    { -12, 77.86m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 93.49m, 77.16m, 81.9m, -315, null },
                    { -11, 87.42m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 87.71m, 69.86m, 93.28m, -315, null },
                    { -10, 81.38m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86.59m, 74.93m, 81.45m, -315, null },
                    { -9, 70.99m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 89.12m, 82.45m, 76.69m, -315, null },
                    { -8, 65.25m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 79.03m, 64.07m, 82.67m, -315, null },
                    { -7, 75.8m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 83.23m, 75.86m, 78.37m, -315, null },
                    { -6, 70.17m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.25m, 72.17m, 66.26m, -315, null },
                    { -5, 73.8m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 76.79m, 84.99m, 64.97m, -315, null },
                    { -4, 77.74m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.17m, 75.09m, 69.35m, -315, null },
                    { -3, 65.7m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 69.7m, 71.85m, 67.03m, -315, null },
                    { -2, 85.85m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 66.62m, 67.86m, 66.22m, -315, null }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                columns: new[] { "SymbolID", "Cusip", "CustomSymbol", "EffectiveDate", "OptionTicker", "SecurityID", "SymbolTypeID", "Ticker" },
                values: new object[,]
                {
                    { -30, null, null, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -761, -40, "ASGEF" },
                    { -29, null, null, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -760, -40, "SFS" },
                    { -28, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -759, -40, "CSC" },
                    { -27, null, null, new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -758, -40, "LCOIN" },
                    { -26, null, null, new DateTime(1753, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LMNC202401190001500C", -748, -30, null },
                    { -25, null, null, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -747, -40, "SCOMM" },
                    { -24, null, null, new DateTime(2021, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -745, -40, "CBETF" },
                    { -23, null, null, new DateTime(2021, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -728, -40, "NL" },
                    { -22, null, null, new DateTime(2021, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -727, -40, "UF" },
                    { -21, null, null, new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -578, -40, "HIBETF" },
                    { -20, null, null, new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -577, -40, "ELGEF" },
                    { -19, null, null, new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -576, -40, "FECES" },
                    { -18, null, null, new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -575, -40, "FREF" },
                    { -17, null, null, new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -574, -40, "SIF" },
                    { -16, null, null, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -523, -40, "PV" }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                columns: new[] { "SymbolID", "Cusip", "CustomSymbol", "EffectiveDate", "OptionTicker", "SecurityID", "SymbolTypeID", "Ticker" },
                values: new object[,]
                {
                    { -15, null, null, new DateTime(2020, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -514, -40, "OFB" },
                    { -14, null, null, new DateTime(2020, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -493, -40, "SWM" },
                    { -13, null, null, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -482, -40, "MIND" },
                    { -12, null, null, new DateTime(2016, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -442, -40, "ASBX" },
                    { -11, null, null, new DateTime(2018, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -432, -40, "SGOXX" },
                    { -10, null, "SBP", new DateTime(2007, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -416, -20, null },
                    { -9, null, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -411, -40, "CSG" },
                    { -8, null, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -406, -40, "VISG" },
                    { -7, null, null, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -403, -40, "LUMIN" },
                    { -6, null, null, new DateTime(2018, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -400, -40, "NEBU" },
                    { -5, null, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -397, -40, "SLCX" },
                    { -4, null, null, new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -392, -40, "MCGF" },
                    { -3, null, null, new DateTime(2016, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -325, -40, "QSOFT" },
                    { -2, null, null, new DateTime(2018, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, -315, -40, "ATECH" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -493 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -761 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -760 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -748 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -745 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -728 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -727 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -523 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -482 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -325 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -819, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -805, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -794, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -778, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -432 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -416 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -758 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -748 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -745 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -578 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -514 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -761 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -760 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -759 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -747 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -728 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -727 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -577 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -576 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -575 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -574 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -523 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -493 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -482 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -442 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -411 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -406 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -403 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -400 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -397 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -392 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -325 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityAttributeMemberEntry",
                keyColumns: new[] { "AttributeMemberID", "EffectiveDate", "SecurityID" },
                keyValues: new object[] { -100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -315 });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1711);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1710);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1709);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1708);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1707);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1706);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1705);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1704);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1703);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1702);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1701);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1700);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1699);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1698);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1697);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1696);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1695);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1694);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1693);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1692);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1691);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1690);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1689);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1688);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1687);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1686);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1685);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1684);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1683);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1682);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1681);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1680);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1679);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1678);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1677);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1676);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1675);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1674);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1673);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1672);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1671);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1670);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1669);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1668);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1667);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1666);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1665);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1664);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1663);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1662);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1661);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1660);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1659);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1658);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1657);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1656);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1655);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1654);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1653);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1652);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1651);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1650);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1649);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1648);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1647);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1646);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1645);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1644);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1643);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1642);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1641);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1640);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1639);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1638);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1637);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1636);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1635);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1634);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1633);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1632);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1631);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1630);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1629);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1628);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1627);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1626);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1625);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1624);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1623);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1622);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1621);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1620);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1619);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1618);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1617);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1616);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1615);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1614);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1613);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1612);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1611);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1610);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1609);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1608);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1607);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1606);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1605);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1604);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1603);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1602);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1601);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1600);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1599);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1598);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1597);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1596);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1595);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1594);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1593);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1592);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1591);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1590);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1589);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1588);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1587);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1586);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1585);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1584);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1583);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1582);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1581);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1580);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1579);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1578);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1577);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1576);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1575);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1574);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1573);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1572);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1571);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1570);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1569);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1568);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1567);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1566);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1565);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1564);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1563);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1562);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1561);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1560);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1559);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1558);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1557);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1556);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1555);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1554);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1553);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1552);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1551);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1550);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1549);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1548);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1547);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1546);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1545);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1544);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1543);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1542);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1541);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1540);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1539);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1538);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1537);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1536);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1535);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1534);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1533);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1532);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1531);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1530);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1529);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1528);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1527);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1526);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1525);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1524);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1523);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1522);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1521);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1520);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1519);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1518);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1517);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1516);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1515);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1514);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1513);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1512);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1511);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1510);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1509);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1508);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1507);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1506);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1505);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1504);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1503);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1502);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1501);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1500);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1499);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1498);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1497);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1496);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1495);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1494);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1493);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1492);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1491);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1490);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1489);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1488);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1487);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1486);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1485);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1484);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1483);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1482);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1481);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1480);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1479);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1478);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1477);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1476);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1475);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1474);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1473);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1472);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1471);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1470);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1469);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1468);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1467);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1466);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1465);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1464);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1463);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1462);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1461);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1460);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1459);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1458);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1457);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1456);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1455);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1454);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1453);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1452);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1451);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1450);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1449);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1448);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1447);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1446);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1445);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1444);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1443);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1442);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1441);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1440);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1439);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1438);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1437);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1436);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1435);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1434);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1433);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1432);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1431);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1430);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1429);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1428);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1427);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1426);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1425);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1424);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1423);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1422);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1421);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1420);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1419);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1418);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1417);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1416);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1415);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1414);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1413);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1412);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1411);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1410);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1409);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1408);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1407);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1406);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1405);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1404);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1403);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1402);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1401);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1400);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1399);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1398);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1397);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1396);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1395);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1394);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1393);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1392);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1391);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1390);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1389);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1388);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1387);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1386);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1385);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1384);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1383);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1382);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1381);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1380);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1379);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1378);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1377);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1376);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1375);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1374);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1373);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1372);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1371);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1370);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1369);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1368);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1367);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1366);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1365);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1364);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1363);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1362);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1361);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1360);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1359);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1358);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1357);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1356);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1355);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1354);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1353);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1352);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1351);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1350);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1349);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1348);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1347);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1346);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1345);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1344);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1343);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1342);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1341);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1340);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1339);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1338);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1337);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1336);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1335);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1334);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1333);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1332);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1331);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1330);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1329);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1328);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1327);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1326);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1325);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1324);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1323);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1322);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1321);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1320);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1319);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1318);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1317);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1316);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1315);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1314);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1313);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1312);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1311);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1310);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1309);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1308);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1307);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1306);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1305);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1304);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1303);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1302);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1301);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1300);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1299);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1298);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1297);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1296);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1295);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1294);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1293);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1292);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1291);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1290);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1289);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1288);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1287);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1286);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1285);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1284);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1283);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1282);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1281);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1280);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1279);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1278);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1277);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1276);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1275);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1274);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1273);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1272);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1271);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1270);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1269);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1268);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1267);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1266);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1265);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1264);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1263);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1262);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1261);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1260);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1259);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1258);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1257);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1256);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1255);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1254);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1253);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1252);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1251);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1250);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1249);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1248);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1247);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1246);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1245);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1244);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1243);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1242);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1241);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1240);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1239);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1238);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1237);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1236);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1235);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1234);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1233);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1232);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1231);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1230);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1229);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1228);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1227);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1226);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1225);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1224);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1223);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1222);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1221);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1220);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1219);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1218);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1217);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1216);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1215);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1214);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1213);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1212);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1211);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1210);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1209);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1208);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1207);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1206);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1205);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1204);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1203);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1202);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1201);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1200);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1199);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1198);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1197);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1196);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1195);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1194);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1193);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1192);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1191);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1190);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1189);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1188);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1187);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1186);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1185);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1184);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1183);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1182);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1181);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1180);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1179);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1178);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1177);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1176);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1175);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1174);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1173);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1172);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1171);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1170);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1169);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1168);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1167);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1166);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1165);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1164);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1163);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1162);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1161);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1160);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1159);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1158);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1157);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1156);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1155);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1154);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1153);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1152);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1151);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1150);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1149);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1148);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1147);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1146);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1145);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1144);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1143);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1142);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1141);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1140);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1139);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1138);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1137);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1136);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1135);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1134);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1133);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1132);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1131);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1130);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1129);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1128);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1127);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1126);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1125);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1124);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1123);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1122);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1121);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1120);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1119);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1118);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1117);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1116);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1115);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1114);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1113);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1112);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1111);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1110);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1109);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1108);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1107);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1106);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1105);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1104);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1103);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1102);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1101);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1100);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1099);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1098);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1097);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1096);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1095);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1094);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1093);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1092);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1091);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1090);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1089);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1088);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1087);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1086);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1085);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1084);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1083);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1082);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1081);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1080);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1079);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1078);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1077);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1076);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1075);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1074);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1073);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1072);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1071);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1070);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1069);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1068);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1067);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1066);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1065);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1064);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1063);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1062);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1061);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1060);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1059);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1058);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1057);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1056);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1055);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1054);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1053);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1052);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1051);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1050);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1049);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1048);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1047);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1046);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1045);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1044);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1043);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1042);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1041);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1040);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1039);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1038);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1037);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1036);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1035);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1034);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1033);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1032);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1031);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1030);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1029);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1028);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1027);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1026);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1025);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1024);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1023);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1022);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1021);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1020);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1019);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1018);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1017);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1016);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1015);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1014);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1013);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1012);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1011);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1010);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1009);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1008);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1007);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1006);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1005);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1004);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1003);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1002);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1001);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -1000);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -999);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -998);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -997);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -996);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -995);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -994);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -993);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -992);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -991);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -990);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -989);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -988);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -987);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -986);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -985);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -984);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -983);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -982);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -981);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -980);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -979);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -978);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -977);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -976);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -975);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -974);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -973);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -972);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -971);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -970);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -969);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -968);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -967);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -966);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -965);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -964);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -963);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -962);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -961);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -960);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -959);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -958);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -957);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -956);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -955);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -954);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -953);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -952);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -951);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -950);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -949);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -948);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -947);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -946);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -945);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -944);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -943);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -942);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -941);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -940);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -939);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -938);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -937);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -936);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -935);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -934);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -933);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -932);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -931);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -930);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -929);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -928);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -927);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -926);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -925);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -924);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -923);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -922);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -921);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -920);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -919);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -918);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -917);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -916);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -915);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -914);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -913);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -912);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -911);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -910);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -909);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -908);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -907);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -906);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -905);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -904);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -903);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -902);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -901);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -900);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -899);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -898);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -897);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -896);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -895);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -894);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -893);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -892);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -891);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -890);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -889);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -888);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -887);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -886);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -885);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -884);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -883);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -882);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -881);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -880);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -879);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -878);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -877);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -876);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -875);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -874);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -873);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -872);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -871);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -870);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -869);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -868);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -867);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -866);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -865);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -864);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -863);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -862);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -861);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -860);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -859);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -858);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -857);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -856);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -855);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -854);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -853);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -852);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -851);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -850);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -849);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -848);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -847);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -846);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -845);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -844);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -843);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -842);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -841);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -840);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -839);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -838);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -837);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -836);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -835);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -834);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -833);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -832);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -831);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -830);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -829);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -828);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -827);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -826);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -825);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -824);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -823);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -822);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -821);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -820);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -819);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -818);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -817);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -816);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -815);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -814);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -813);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -812);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -811);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -810);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -809);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -808);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -807);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -806);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -805);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -804);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -803);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -802);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -801);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -800);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -799);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -798);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -797);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -796);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -795);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -794);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -793);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -792);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -791);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -790);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -789);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -788);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -787);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -786);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -785);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -784);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -783);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -782);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -781);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -780);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -779);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -778);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -777);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -776);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -775);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -774);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -773);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -772);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -771);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -770);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -769);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -768);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -767);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -766);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -765);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -764);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -763);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -762);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -761);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -760);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -759);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -758);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -757);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -756);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -755);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -754);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -753);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -752);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -751);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -750);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -749);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -748);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -747);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -746);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -745);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -744);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -743);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -742);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -741);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -740);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -739);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -738);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -737);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -736);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -735);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -734);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -733);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -732);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -731);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -730);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -729);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -728);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -727);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -726);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -725);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -724);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -723);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -722);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -721);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -720);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -719);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -718);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -717);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -716);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -715);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -714);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -713);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -712);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -711);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -710);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -709);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -708);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -707);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -706);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -705);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -704);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -703);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -702);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -701);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -700);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -699);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -698);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -697);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -696);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -695);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -694);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -693);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -692);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -691);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -690);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -689);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -688);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -687);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -686);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -685);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -684);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -683);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -682);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -681);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -680);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -679);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -678);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -677);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -676);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -675);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -674);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -673);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -672);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -671);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -670);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -669);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -668);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -667);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -666);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -665);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -664);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -663);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -662);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -661);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -660);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -659);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -658);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -657);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -656);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -655);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -654);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -653);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -652);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -651);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -650);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -649);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -648);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -647);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -646);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -645);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -644);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -643);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -642);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -641);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -640);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -639);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -638);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -637);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -636);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -635);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -634);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -633);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -632);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -631);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -630);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -629);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -628);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -627);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -626);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -625);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -624);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -623);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -622);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -621);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -620);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -619);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -618);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -617);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -616);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -615);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -614);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -613);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -612);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -611);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -610);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -609);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -608);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -607);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -606);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -605);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -604);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -603);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -602);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -601);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -600);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -599);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -598);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -597);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -596);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -595);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -594);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -593);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -592);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -591);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -590);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -589);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -588);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -587);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -586);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -585);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -584);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -583);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -582);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -581);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -580);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -579);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -578);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -577);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -576);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -575);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -574);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -573);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -572);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -571);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -570);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -569);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -568);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -567);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -566);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -565);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -564);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -563);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -562);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -561);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -560);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -559);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -558);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -557);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -556);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -555);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -554);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -553);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -552);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -551);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -550);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -549);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -548);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -547);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -546);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -545);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -544);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -543);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -542);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -541);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -540);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -539);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -538);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -537);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -536);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -535);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -534);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -533);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -532);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -531);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -530);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -529);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -528);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -527);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -526);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -525);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -524);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -523);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -522);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -521);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -520);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -519);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -518);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -517);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -516);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -515);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -514);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -513);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -512);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -511);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -510);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -509);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -508);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -507);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -506);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -505);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -504);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -503);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -502);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -501);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -500);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -499);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -498);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -497);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -496);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -495);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -494);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -493);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -492);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -491);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -490);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -489);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -488);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -487);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -486);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -485);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -484);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -483);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -482);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -481);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -480);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -479);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -478);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -477);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -476);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -475);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -474);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -473);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -472);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -471);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -470);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -469);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -468);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -467);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -466);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -465);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -464);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -463);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -462);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -461);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -460);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -459);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -458);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -457);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -456);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -455);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -454);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -453);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -452);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -451);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -450);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -449);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -448);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -447);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -446);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -445);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -444);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -443);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -442);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -441);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -440);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -439);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -438);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -437);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -436);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -435);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -434);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -433);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -432);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -431);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -430);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -429);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -428);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -427);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -426);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -425);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -424);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -423);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -422);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -421);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -420);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -419);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -418);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -417);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -416);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -415);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -414);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -413);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -412);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -411);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -410);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -409);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -408);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -407);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -406);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -405);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -404);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -403);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -402);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -401);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -400);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -399);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -398);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -397);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -396);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -395);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -394);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -393);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -392);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -391);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -390);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -389);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -388);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -387);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -386);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -385);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -384);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -383);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -382);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -381);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -380);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -379);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -378);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -377);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -376);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -375);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -374);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -373);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -372);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -371);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -370);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -369);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -368);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -367);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -366);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -365);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -364);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -363);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -362);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -361);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -360);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -359);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -358);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -357);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -356);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -355);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -354);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -353);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -352);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -351);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -350);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -349);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -348);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -347);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -346);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -345);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -344);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -343);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -342);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -341);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -340);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -339);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -338);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -337);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -336);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -335);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -334);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -333);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -332);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -331);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -330);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -329);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -328);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -327);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -326);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -325);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -324);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -323);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -322);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -321);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -320);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -319);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -318);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -317);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -316);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -315);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -314);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -313);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -312);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -311);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -310);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -309);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -308);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -307);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -306);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -305);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -304);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -303);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -302);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -301);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -300);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -299);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -298);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -297);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -296);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -295);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -294);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -293);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -292);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -291);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -290);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -289);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -288);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -287);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -286);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -285);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -284);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -283);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -282);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -281);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -280);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -279);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -278);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -277);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -276);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -275);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -274);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -273);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -272);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -271);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -270);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -269);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -268);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -267);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -266);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -265);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -264);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -263);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -262);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -261);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -260);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -259);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -258);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -257);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -256);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -255);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -254);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -253);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -252);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -251);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -250);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -249);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -248);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -247);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -246);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -245);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -244);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -243);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -242);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -241);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -240);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -239);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -238);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -237);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -236);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -235);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -234);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -233);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -232);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -231);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -230);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -229);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -228);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -227);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -226);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -225);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -224);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -223);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -222);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -221);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -220);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -219);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -218);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -217);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -216);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -215);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -214);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -213);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -212);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -211);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -210);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -209);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -208);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -207);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -206);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -205);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -204);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -203);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -202);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -201);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -200);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -199);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -198);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -197);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -196);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -195);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -194);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -193);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -192);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -191);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -190);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -189);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -188);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -187);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -186);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -185);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -184);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -183);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -182);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -181);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -180);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -179);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -178);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -177);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -176);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -175);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -174);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -173);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -172);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -171);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -170);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -169);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -168);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -167);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -166);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -165);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -164);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -163);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -162);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -161);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -160);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -159);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -158);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -157);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -156);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -155);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -154);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -153);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -152);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -151);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -150);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -149);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -148);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -147);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -146);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -145);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -144);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -143);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -142);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -141);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -140);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -139);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -138);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -137);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -136);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -135);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -134);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -133);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -132);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -131);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -130);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -129);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -128);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -127);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -126);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -125);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -124);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -123);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -122);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -121);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -120);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -119);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -118);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -117);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -116);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -115);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -114);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -113);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -112);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -111);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -110);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -109);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -108);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -107);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -106);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -105);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -104);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -103);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -102);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -101);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -100);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -99);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -98);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -97);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -96);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -95);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -94);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -93);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -92);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -91);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -90);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -89);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -88);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -87);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -86);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -85);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -84);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -83);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -82);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -81);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -80);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -79);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -78);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -77);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -76);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -75);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -74);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -73);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -72);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -71);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -70);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -69);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -68);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -67);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -66);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -65);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -64);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -63);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -62);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -61);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -60);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -59);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -58);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -57);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -56);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -55);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -54);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -53);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -52);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -51);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -50);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -49);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -48);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -47);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -46);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -45);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -44);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -43);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -42);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -41);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -40);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -39);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -38);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -37);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -36);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -35);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -34);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -33);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -32);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -31);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -30);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -29);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -28);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -27);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -26);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -25);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -24);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -22);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -21);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -20);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -19);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -18);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -17);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -16);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -15);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecurityPrice",
                keyColumn: "PriceID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -30);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -29);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -28);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -27);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -26);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -25);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -24);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -23);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -22);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -21);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -20);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -19);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -18);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -17);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -16);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -15);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -14);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -13);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -12);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -11);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -10);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -9);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -8);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -7);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "SecuritySymbol",
                keyColumn: "SymbolID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -761);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -760);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -759);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -758);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -748);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -747);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -745);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -728);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -727);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -578);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -577);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -576);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -575);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -574);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -523);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -514);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -493);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -482);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -442);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -432);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -416);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -411);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -406);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -403);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -400);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -397);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -392);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -325);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "Security",
                keyColumn: "SecurityID",
                keyValue: -315);
        }
    }
}
