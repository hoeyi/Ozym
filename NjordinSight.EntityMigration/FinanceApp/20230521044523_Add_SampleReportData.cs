using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleReportData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ReportConfiguration",
                columns: new[] { "ConfigurationID", "ConfigurationCode", "ConfigurationDescription", "XmlDefinition" },
                values: new object[] { -1, "Default", "Standard style sheet for report content.", "<ReportConfiguration xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><Settings><Setting Name=\"CurrencyPrecision\" Label=\"Currency Precision\" Value=\"c\" /><Setting Name=\"IncludeClosed\" Label=\"Include Closed\" Value=\"false\" /><Setting Name=\"TradableAccountsOnly\" Label=\"Tradable Accounts Only\" Value=\"true\" /><Setting Name=\"Theme\" Label=\"Theme\" Value=\"Default\" /></Settings></ReportConfiguration>" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ReportStyleSheet",
                columns: new[] { "StyleSheetID", "StyleSheetCode", "StyleSheetDescription", "XmlDefinition" },
                values: new object[] { -1, "Default", "Standard style sheet for report content.", "<StyleSheet xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">\r\n  <Fonts>\r\n    <Font Name=\"TableGroupHeader\" FontFamily=\"Arial\" FontWeight=\"Bold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray5\" BackColor=\"blue\" />\r\n    <Font Name=\"TableSubGroupHeader\" FontFamily=\"Arial\" FontWeight=\"SemiBold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableColumnHeader\" FontFamily=\"Arial\" FontWeight=\"SemiBold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableCell\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ChartAxisLabel\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"7pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ChartTitle\" FontFamily=\"Arial\" FontWeight=\"SemiBold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"12pt\" Color=\"blue\" BackColor=\"No Color\" />\r\n    <Font Name=\"ReportParameter\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Italic\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ReportTitle\" FontFamily=\"Cambria\" FontWeight=\"Bold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"14pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ChartLegend\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableCellSubTotal\" FontFamily=\"Arial\" FontWeight=\"SemiBold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableCellTotal\" FontFamily=\"Arial\" FontWeight=\"Bold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ReportPageNumber\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"7pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableDefault\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"ReportDefault\" FontFamily=\"Arial\" FontWeight=\"Default\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n    <Font Name=\"TableTotalRow\" FontFamily=\"Arial\" FontWeight=\"Bold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"8pt\" Color=\"gray5\" BackColor=\"blue\" />\r\n    <Font Name=\"ChartSeriesLabel\" FontFamily=\"Arial\" FontWeight=\"SemiBold\" TextDecoration=\"Default\" FontStyle=\"Default\" FontSize=\"7pt\" Color=\"gray1\" BackColor=\"No Color\" />\r\n  </Fonts>\r\n  <Colors>\r\n    <Color Name=\"gray0\" HexCode=\"#191919\" />\r\n    <Color Name=\"gray1\" HexCode=\"#212121\" />\r\n    <Color Name=\"gray2\" HexCode=\"#303030\" />\r\n    <Color Name=\"gray3\" HexCode=\"#424242\" />\r\n    <Color Name=\"gray4\" HexCode=\"#D2D2D2\" />\r\n    <Color Name=\"gray5\" HexCode=\"#E6E6E6\" />\r\n    <Color Name=\"blue\" HexCode=\"#0E2C39\" />\r\n    <Color Name=\"yellow\" HexCode=\"#5B4713\" />\r\n    <Color Name=\"green\" HexCode=\"#0E391B\" />\r\n    <Color Name=\"red\" HexCode=\"#5B2113\" />\r\n  </Colors>\r\n  <DefaultFont BackColor=\"No Color\" Color=\"#000000\" Name=\"default\" Decoration=\"Default\" Size=\"8pt\" Weight=\"Default\" Style=\"Default\" Family=\"Arial\" />\r\n  <AlphaBlendHexCode>#ffffff</AlphaBlendHexCode>\r\n</StyleSheet>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ReportConfiguration",
                keyColumn: "ConfigurationID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ReportStyleSheet",
                keyColumn: "StyleSheetID",
                keyValue: -1);
        }
    }
}
