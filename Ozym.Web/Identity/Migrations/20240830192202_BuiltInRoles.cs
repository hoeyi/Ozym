using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ozym.Web.Identity.Migrations
{
    /// <inheritdoc />
    public partial class BuiltInRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "WebId",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31e57550-05b1-44f8-943f-9c36c4ba131e", null, "Superuser", "SUPERUSER" },
                    { "be5cc023-8bff-4354-944e-c3285ba6aa81", null, "Datawriter", "DATAWRITER" },
                    { "d619b09f-a096-4d83-948b-7aa53c5f961a", null, "Datareader", "DATAREADER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31e57550-05b1-44f8-943f-9c36c4ba131e");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be5cc023-8bff-4354-944e-c3285ba6aa81");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d619b09f-a096-4d83-948b-7aa53c5f961a");
        }
    }
}
