using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ozym.Web.Identity.Migrations
{
    /// <inheritdoc />
    public partial class BuiltinRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "WebId",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "289b10ff-09a3-4bf8-9c3d-146c2d5b374a", "6a2695f3-e0ea-450a-afd6-76a49e6baa37", "Datawriter", "DATAWRITER" },
                    { "64dbe3da-f244-4136-9921-801bdce4bef0", "64e375cc-edea-4d95-b629-02334ab9f0b2", "Superuser", "SUPERUSER" },
                    { "c727af09-2359-4b24-9c23-59fc1e6bbc43", "68de9beb-0202-4c46-bb19-f08551b4bc63", "Datareader", "DATAREADER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "289b10ff-09a3-4bf8-9c3d-146c2d5b374a");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64dbe3da-f244-4136-9921-801bdce4bef0");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c727af09-2359-4b24-9c23-59fc1e6bbc43");

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
    }
}
