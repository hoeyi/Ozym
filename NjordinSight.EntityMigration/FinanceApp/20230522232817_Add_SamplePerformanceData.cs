using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SamplePerformanceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, -105, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7500m, 0m, 0m, 7500m, 0m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7500m, 0m, 0m, 7500m, 0m, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7404.64m, -95.36m, -0.0031m, 7404.64m, 0m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 7717.21m, 312.57m, 0.0112m, 7717.21m, 0m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3316.52m, -4400.69m, -0.0152m, 3316.52m, 0m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5447.82m, 2131.29m, 0.0206m, 5793.97m, 346.155m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5793.97m, 0m, 0m, 5793.97m, 0m, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5793.97m, 0m, 0m, 5793.97m, 0m, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6856.49m, 1062.52m, 0.007m, 6856.49m, 0m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6357.21m, -499.28m, 0.0095m, 6357.21m, 0m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8175.92m, 1818.71m, 0.0142m, 8175.92m, 0m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 8775.65m, 599.73m, 0.0059m, 8775.65m, 0m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9127.43m, 351.78m, 0.0062m, 9127.43m, 0m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 9127.43m, 0m, 0m, 9127.43m, 0m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 9127.43m, 0m, 0m, 9127.43m, 0m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9127.43m, 0m, 0m, 9127.43m, 0m, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9338.96m, 211.53m, 0.0019m, 9338.96m, 0m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7772.02m, -1566.94m, -0.0104m, 7772.02m, 0m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8164.33m, 392.31m, -0.0096m, 8164.33m, 0m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 11060.74m, 2896.41m, 0.0197m, 11060.74m, 0m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 11060.74m, 0m, 0m, 11060.74m, 0m, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 11060.74m, 0m, 0m, 11060.74m, 0m, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 13010.61m, 1949.86m, 0.0146m, 13356.76m, 346.155m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 12694.96m, -661.8m, -0.0038m, 12694.96m, 0m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 12710.36m, 15.4m, 0.0003m, 12710.36m, 0m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 12813.05m, 102.69m, 0.0111m, 12813.05m, 0m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 12864.12m, 51.07m, 0.0039m, 12864.12m, 0m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 12864.12m, 0m, 0m, 12864.12m, 0m, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12864.12m, 0m, 0m, 12864.12m, 0m, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 10273.67m, -2590.45m, -0.0152m, 10273.67m, 0m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 13468.18m, 3194.51m, 0.0162m, 13468.18m, 0m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 14598.85m, 1130.67m, 0.0178m, 14598.85m, 0m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14923.56m, 324.71m, 0.0164m, 14923.56m, 0m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 17116.89m, 2193.33m, -0.0156m, 17116.89m, 0m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17116.89m, 0m, 0m, 17116.89m, 0m, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 17116.89m, 0m, 0m, 17116.89m, 0m, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 16992.76m, -124.13m, -0.0111m, 17335.04m, 342.28m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 17907.83m, 572.79m, 0.0131m, 17907.83m, 0m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17525.53m, -382.3m, -0.0105m, 17525.53m, 0m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16992.81m, -532.72m, -0.0066m, 16992.81m, 0m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 16736.05m, -256.76m, -0.0044m, 16736.05m, 0m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 16736.05m, 0m, 0m, 16736.05m, 0m, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, -105, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 16736.05m, 0m, 0m, 16736.05m, 0m, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 19290.46m, 2554.41m, 0.0123m, 19290.46m, 0m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 19597.62m, 307.16m, 0.0046m, 19597.62m, 0m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 20319.55m, 721.93m, 0.0068m, 20319.55m, 0m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17362.24m, -2957.32m, -0.0131m, 17708.39m, 346.155m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 15754.89m, -1953.5m, -0.0076m, 15754.89m, 0m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 15754.89m, 0m, 0m, 15754.89m, 0m, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 15754.89m, 0m, 0m, 15754.89m, 0m, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 15754.89m, 0m, 0m, 15754.89m, 0m, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 14800.3m, -954.59m, -0.0217m, 14800.3m, 0m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 14796.67m, -3.63m, -0.0001m, 14796.67m, 0m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 15175.59m, 378.92m, 0.0067m, 15175.59m, 0m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 13997.11m, -1178.48m, -0.0137m, 13997.11m, 0m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 13997.11m, 0m, 0m, 13997.11m, 0m, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 13997.11m, 0m, 0m, 13997.11m, 0m, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 13399.56m, -597.55m, 0.0052m, 13399.56m, 0m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 13187.52m, -212.04m, -0.0022m, 13187.52m, 0m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 13071.24m, -116.28m, -0.0019m, 13071.24m, 0m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14079.14m, 1007.9m, 0.0079m, 14079.14m, 0m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 19367.17m, 5288.03m, 0.0162m, 19367.17m, 0m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 19367.17m, 0m, 0m, 19367.17m, 0m, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 19367.17m, 0m, 0m, 19367.17m, 0m, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 19233.54m, -133.64m, -0.0034m, 19579.69m, 346.155m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 18035.21m, -1544.48m, -0.0133m, 18035.21m, 0m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 18083.61m, 48.4m, 0.0026m, 18083.61m, 0m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15441.95m, -2641.66m, -0.0199m, 15441.95m, 0m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 13122.04m, -2319.91m, -0.0211m, 13122.04m, 0m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13122.04m, 0m, 0m, 13122.04m, 0m, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 13122.04m, 0m, 0m, 13122.04m, 0m, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12653.85m, -468.19m, -0.0022m, 12653.85m, 0m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 12473.39m, -180.46m, 0.0172m, 12473.39m, 0m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10858.25m, -1615.14m, -0.0118m, 10858.25m, 0m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11170.87m, 312.61m, 0.0183m, 11517.02m, 346.155m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 9681.17m, -1835.85m, -0.0111m, 9681.17m, 0m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9681.17m, 0m, 0m, 9681.17m, 0m, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 9681.17m, 0m, 0m, 9681.17m, 0m, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 9667.53m, -13.64m, 0.0077m, 9667.53m, 0m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10021.4m, 353.87m, 0.0168m, 10021.4m, 0m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 8182.71m, -1838.69m, -0.0145m, 8182.71m, 0m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 8559.08m, 376.37m, 0.005m, 8559.08m, 0m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 8408.95m, -150.13m, -0.001m, 8408.95m, 0m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8408.95m, 0m, 0m, 8408.95m, 0m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, -105, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8408.95m, 0m, 0m, 8408.95m, 0m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 8715.89m, 306.94m, 0.0023m, 8715.89m, 0m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 8617.64m, -98.25m, -0.0008m, 8617.64m, 0m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 11056.33m, 2438.69m, 0.0142m, 11056.33m, 0m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 12126.18m, 1069.85m, 0.0074m, 12126.18m, 0m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -105, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 12435.68m, 309.49m, 0.0148m, 12781.83m, 346.155m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, 0m, 0m, 15000m, 0m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, 0m, 0m, 15000m, 0m, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15020.87m, 20.87m, -0.0028m, 15020.87m, 0m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15479.11m, 458.24m, 0.0099m, 15479.11m, 0m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 15052.17m, -426.94m, -0.0092m, 15052.17m, 0m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15522.55m, 470.38m, 0.0221m, 15522.55m, 0m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15522.55m, 0m, 0m, 15522.55m, 0m, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15522.55m, 0m, 0m, 15522.55m, 0m, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 15520.56m, -1.99m, 0.0006m, 15520.56m, 0m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 15474.2m, -46.36m, 0.0051m, 15474.2m, 0m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15878.86m, 404.66m, 0.0098m, 15878.86m, 0m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 16005.38m, 126.52m, 0.0063m, 17505.38m, 1500m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 17648m, 142.62m, 0.0028m, 17648m, 0m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17648m, 0m, 0m, 17648m, 0m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 17648m, 0m, 0m, 17648m, 0m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17648m, 0m, 0m, 17648m, 0m, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 17633.62m, -14.38m, -0.0005m, 17633.62m, 0m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 16907.58m, -726.04m, -0.0101m, 16907.58m, 0m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16684.63m, -222.95m, -0.0053m, 16684.63m, 0m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 16419.3m, -265.33m, 0.0138m, 16419.3m, 0m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16419.3m, 0m, 0m, 16419.3m, 0m, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16419.3m, 0m, 0m, 16419.3m, 0m, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16548.71m, 129.41m, 0.0095m, 17298.71m, 750m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17290.42m, -8.29m, -0.0006m, 17290.42m, 0m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 17373.46m, 83.04m, 0.0014m, 17373.46m, 0m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 17888.24m, 514.78m, 0.0072m, 17888.24m, 0m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 17923.9m, 35.66m, 0.0015m, 17923.9m, 0m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 17923.9m, 0m, 0m, 17923.9m, 0m, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 17923.9m, 0m, 0m, 17923.9m, 0m, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 17537.42m, -386.48m, -0.01m, 17537.42m, 0m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 18212.59m, 675.17m, 0.0118m, 18212.59m, 0m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 18102.49m, -110.1m, 0.0108m, 18102.49m, 0m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17921.96m, -180.53m, 0.0085m, 17921.96m, 0m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 17915.85m, -6.11m, -0.0076m, 17915.85m, 0m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17915.85m, 0m, 0m, 17915.85m, 0m, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 17915.85m, 0m, 0m, 17915.85m, 0m, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, -100, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 17776.34m, -139.51m, -0.0077m, 17776.34m, 0m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 18032.23m, 255.89m, 0.0102m, 18032.23m, 0m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17853.51m, -178.72m, -0.0083m, 17853.51m, 0m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17617.31m, -236.2m, -0.0058m, 17617.31m, 0m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 17640.05m, 22.74m, 0.0022m, 17640.05m, 0m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 17640.05m, 0m, 0m, 17640.05m, 0m, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 17640.05m, 0m, 0m, 17640.05m, 0m, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 18005.09m, 365.04m, 0.0104m, 18005.09m, 0m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 18015.59m, 10.5m, 0.0003m, 18015.59m, 0m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 18129.7m, 114.11m, 0.002m, 18129.7m, 0m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 17997.86m, -131.84m, -0.0089m, 17997.86m, 0m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 17971.35m, -26.51m, -0.0025m, 17971.35m, 0m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 17971.35m, 0m, 0m, 17971.35m, 0m, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 17971.35m, 0m, 0m, 17971.35m, 0m, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 17971.35m, 0m, 0m, 17971.35m, 0m, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16689.13m, -1282.22m, -0.0188m, 16689.13m, 0m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16674.27m, -14.86m, -0.0021m, 16674.27m, 0m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16854.98m, 180.71m, 0.0062m, 16854.98m, 0m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 17061.19m, 206.21m, -0.0103m, 17061.19m, 0m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 17061.19m, 0m, 0m, 17061.19m, 0m, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 17061.19m, 0m, 0m, 17061.19m, 0m, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 17451.62m, 390.43m, 0.0044m, 17451.62m, 0m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 17172.27m, -279.35m, -0.0042m, 17172.27m, 0m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 17183.06m, 10.79m, 0.0003m, 17183.06m, 0m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17500.51m, 317.45m, 0.0055m, 17500.51m, 0m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 17909.9m, 409.39m, 0.0136m, 17909.9m, 0m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 17909.9m, 0m, 0m, 17909.9m, 0m, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 17909.9m, 0m, 0m, 17909.9m, 0m, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 17851.21m, -58.69m, -0.0029m, 17851.21m, 0m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 16895.36m, -955.85m, -0.0137m, 17645.36m, 750m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 17640.3m, -5.06m, 0.0027m, 17640.3m, 0m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16218.8m, -1421.5m, -0.0161m, 16218.8m, 0m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 15777.18m, -441.62m, -0.0166m, 15777.18m, 0m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15777.18m, 0m, 0m, 15777.18m, 0m, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 15777.18m, 0m, 0m, 15777.18m, 0m, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 15600.82m, -176.36m, -0.0067m, 15600.82m, 0m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 16520.9m, 920.08m, 0.0139m, 16520.9m, 0m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 16896.72m, 375.82m, -0.0142m, 16896.72m, 0m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16454.08m, -442.64m, 0.0148m, 16454.08m, 0m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 16405.2m, -48.88m, -0.0153m, 16405.2m, 0m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 16405.2m, 0m, 0m, 16405.2m, 0m, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16405.2m, 0m, 0m, 16405.2m, 0m, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                columns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, -100, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 16596.53m, 191.33m, 0.0122m, 16596.53m, 0m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16664.32m, 67.79m, 0.0114m, 16664.32m, 0m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 16163.56m, -500.76m, -0.016m, 16163.56m, 0m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 16232.98m, 69.42m, 0.0035m, 16232.98m, 0m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 16309.54m, 76.56m, 0.0046m, 16309.54m, 0m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 16309.54m, 0m, 0m, 16309.54m, 0m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 16309.54m, 0m, 0m, 16309.54m, 0m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 16538.46m, 228.92m, 0.0054m, 16538.46m, 0m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 16538.44m, -0.02m, 0.0003m, 16538.44m, 0m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 17199.29m, 660.85m, 0.0127m, 17949.29m, 750m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 18238.34m, 289.05m, 0.0061m, 18238.34m, 0m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, -100, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 19030.34m, 792m, 0.0116m, 19030.34m, 0m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                columns: new[] { "AccountObjectID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 22500m, 0m, 0m, 22500m, 0m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22500m, 0m, 0m, 22500m, 0m, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 22500m, -74.49m, -0.0033m, 22425.51m, 0m, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 22425.51m, 770.81m, 0.0344m, 23196.32m, 0m, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 23196.32m, -4827.63m, -0.2081m, 18368.69m, 0m, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 18714.845m, 2601.67m, 0.139m, 21316.52m, 346.155m, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 21316.52m, 0m, 0m, 21316.52m, 0m, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 21316.52m, 0m, 0m, 21316.52m, 0m, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 21316.52m, 1060.53m, 0.0498m, 22377.05m, 0m, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 22377.05m, -545.64m, -0.0244m, 21831.41m, 0m, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 21831.41m, 2223.37m, 0.1018m, 24054.78m, 0m, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25554.78m, 726.25m, 0.0284m, 26281.03m, 1500m, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 26281.03m, 494.4m, 0.0188m, 26775.43m, 0m, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 26775.43m, 0m, 0m, 26775.43m, 0m, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 26775.43m, 0m, 0m, 26775.43m, 0m, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 26775.43m, 0m, 0m, 26775.43m, 0m, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 26775.43m, 197.15m, 0.0074m, 26972.58m, 0m, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 26972.58m, -2292.98m, -0.085m, 24679.6m, 0m, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24679.6m, 169.36m, 0.0069m, 24848.96m, 0m, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 24848.96m, 2631.08m, 0.1059m, 27480.04m, 0m, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 27480.04m, 0m, 0m, 27480.04m, 0m, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 27480.04m, 0m, 0m, 27480.04m, 0m, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 28576.195m, 2079.27m, 0.0728m, 30655.47m, 1096.155m, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 30655.47m, -670.09m, -0.0219m, 29985.38m, 0m, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 29985.38m, 98.44m, 0.0033m, 30083.82m, 0m, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 30083.82m, 617.47m, 0.0205m, 30701.29m, 0m, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 30701.29m, 86.73m, 0.0028m, 30788.02m, 0m, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 30788.02m, 0m, 0m, 30788.02m, 0m, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 30788.02m, 0m, 0m, 30788.02m, 0m, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 30788.02m, -2976.93m, -0.0967m, 27811.09m, 0m, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                columns: new[] { "AccountObjectID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 27811.09m, 3869.68m, 0.1391m, 31680.77m, 0m, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 31680.77m, 1020.57m, 0.0322m, 32701.34m, 0m, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32701.34m, 144.18m, 0.0044m, 32845.52m, 0m, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 32845.52m, 2187.22m, 0.0666m, 35032.74m, 0m, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 35032.74m, 0m, 0m, 35032.74m, 0m, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 35032.74m, 0m, 0m, 35032.74m, 0m, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 35375.02m, -263.64m, -0.0075m, 35111.38m, 342.28m, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 35111.38m, 828.68m, 0.0236m, 35940.06m, 0m, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 35940.06m, -561.02m, -0.0156m, 35379.04m, 0m, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 35379.04m, -768.92m, -0.0217m, 34610.12m, 0m, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 34610.12m, -234.02m, -0.0068m, 34376.1m, 0m, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 34376.1m, 0m, 0m, 34376.1m, 0m, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 34376.1m, 0m, 0m, 34376.1m, 0m, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 34376.1m, 2919.45m, 0.0849m, 37295.55m, 0m, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 37295.55m, 317.66m, 0.0085m, 37613.21m, 0m, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 37613.21m, 836.04m, 0.0222m, 38449.25m, 0m, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 38795.405m, -3089.16m, -0.0796m, 35706.25m, 346.155m, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 35706.25m, -1980.01m, -0.0555m, 33726.24m, 0m, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 33726.24m, 0m, 0m, 33726.24m, 0m, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 33726.24m, 0m, 0m, 33726.24m, 0m, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 33726.24m, 0m, 0m, 33726.24m, 0m, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 33726.24m, -2236.81m, -0.0663m, 31489.43m, 0m, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 31489.43m, -18.49m, -0.0006m, 31470.94m, 0m, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 31470.94m, 559.63m, 0.0178m, 32030.57m, 0m, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 32030.57m, -972.27m, -0.0304m, 31058.3m, 0m, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 31058.3m, 0m, 0m, 31058.3m, 0m, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 31058.3m, 0m, 0m, 31058.3m, 0m, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 31058.3m, -207.12m, -0.0067m, 30851.18m, 0m, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 30851.18m, -491.39m, -0.0159m, 30359.79m, 0m, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 30359.79m, -105.49m, -0.0035m, 30254.3m, 0m, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30254.3m, 1325.35m, 0.0438m, 31579.65m, 0m, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 31579.65m, 5697.42m, 0.1804m, 37277.07m, 0m, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 37277.07m, 0m, 0m, 37277.07m, 0m, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 37277.07m, 0m, 0m, 37277.07m, 0m, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 37623.225m, -192.33m, -0.0051m, 37430.9m, 346.155m, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 38180.9m, -2500.33m, -0.0655m, 35680.57m, 750m, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 35680.57m, 43.34m, 0.0012m, 35723.91m, 0m, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 35723.91m, -4063.16m, -0.1137m, 31660.75m, 0m, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 31660.75m, -2761.53m, -0.0872m, 28899.22m, 0m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 28899.22m, 0m, 0m, 28899.22m, 0m, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 28899.22m, 0m, 0m, 28899.22m, 0m, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 28899.22m, -644.55m, -0.0223m, 28254.67m, 0m, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                columns: new[] { "AccountObjectID", "FromDate", "AverageCapital", "Gain", "IRR", "MarketValue", "NetContribution", "ToDate" },
                values: new object[,]
                {
                    { -11, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 28254.67m, 739.62m, 0.0262m, 28994.29m, 0m, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 28994.29m, -1239.32m, -0.0427m, 27754.97m, 0m, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 28101.125m, -130.03m, -0.0046m, 27971.1m, 346.155m, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 27971.1m, -1884.73m, -0.0674m, 26086.37m, 0m, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 26086.37m, 0m, 0m, 26086.37m, 0m, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 26086.37m, 0m, 0m, 26086.37m, 0m, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 26086.37m, 177.69m, 0.0068m, 26264.06m, 0m, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 26264.06m, 421.66m, 0.0161m, 26685.72m, 0m, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 26685.72m, -2339.45m, -0.0877m, 24346.27m, 0m, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 24346.27m, 445.79m, 0.0183m, 24792.06m, 0m, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 24792.06m, -73.57m, -0.003m, 24718.49m, 0m, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 24718.49m, 0m, 0m, 24718.49m, 0m, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 24718.49m, 0m, 0m, 24718.49m, 0m, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 24718.49m, 535.86m, 0.0217m, 25254.35m, 0m, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 25254.35m, -98.27m, -0.0039m, 25156.08m, 0m, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 25906.08m, 3099.54m, 0.1196m, 29005.62m, 750m, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 29005.62m, 1358.9m, 0.0468m, 30364.52m, 0m, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { -11, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 30710.675m, 1101.49m, 0.0359m, 31812.17m, 346.155m, new DateTime(2023, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -105, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceAttributeMemberEntry",
                keyColumns: new[] { "AccountObjectID", "AttributeMemberID", "FromDate" },
                keyValues: new object[] { -11, -100, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2022, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "InvestmentPerformanceEntry",
                keyColumns: new[] { "AccountObjectID", "FromDate" },
                keyValues: new object[] { -11, new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
