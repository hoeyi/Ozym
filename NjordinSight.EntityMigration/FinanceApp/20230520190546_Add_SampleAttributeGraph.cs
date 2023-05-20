using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NjordinSight.EntityMigration.FinanceApp
{
    public partial class Add_SampleAttributeGraph : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                columns: new[] { "AttributeID", "DisplayName" },
                values: new object[] { -930, "Transaction Group" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                columns: new[] { "AttributeID", "DisplayName" },
                values: new object[] { -920, "Transaction Type" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                columns: new[] { "AttributeID", "DisplayName" },
                values: new object[] { -90, "Account Type" });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                columns: new[] { "AttributeMemberID", "AttributeID", "DisplayName", "DisplayOrder" },
                values: new object[,]
                {
                    { -933, -930, "Income", (short)2 },
                    { -932, -930, "Discretionary expense", (short)1 },
                    { -931, -930, "Necessary expense", (short)0 },
                    { -926, -920, "Employment", (short)6 },
                    { -925, -920, "Restaurants/Dining", (short)5 },
                    { -924, -920, "Housing", (short)4 },
                    { -923, -920, "Medical", (short)3 },
                    { -922, -920, "Entertainment", (short)2 },
                    { -921, -920, "Utilities", (short)1 },
                    { -920, -920, "Transportation", (short)0 },
                    { -911, -90, "Roth Contributory IRA", (short)10 },
                    { -910, -90, "Health-Savings", (short)9 },
                    { -909, -90, "Credit", (short)8 },
                    { -908, -90, "Savings", (short)7 },
                    { -907, -90, "Checking", (short)6 },
                    { -906, -90, "Stock Purchase Plan", (short)5 },
                    { -905, -90, "Brokerage", (short)4 },
                    { -904, -90, "Contributory IRA", (short)3 },
                    { -903, -90, "Rollover IRA", (short)2 },
                    { -902, -90, "401(k)", (short)1 },
                    { -901, -90, "Student Loan", (short)0 }
                });

            migrationBuilder.InsertData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                columns: new[] { "AttributeID", "ScopeCode" },
                values: new object[,]
                {
                    { -930, "bnk" },
                    { -920, "bnk" },
                    { -90, "acc" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -933);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -932);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -931);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -926);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -925);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -924);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -923);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -922);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -921);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -920);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -911);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -910);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -909);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -908);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -907);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -906);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -905);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -904);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -903);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -902);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeMember",
                keyColumn: "AttributeMemberID",
                keyValue: -901);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                keyColumns: new[] { "AttributeID", "ScopeCode" },
                keyValues: new object[] { -930, "bnk" });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                keyColumns: new[] { "AttributeID", "ScopeCode" },
                keyValues: new object[] { -920, "bnk" });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttributeScope",
                keyColumns: new[] { "AttributeID", "ScopeCode" },
                keyValues: new object[] { -90, "acc" });

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                keyColumn: "AttributeID",
                keyValue: -930);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                keyColumn: "AttributeID",
                keyValue: -920);

            migrationBuilder.DeleteData(
                schema: "FinanceApp",
                table: "ModelAttribute",
                keyColumn: "AttributeID",
                keyValue: -90);
        }
    }
}
