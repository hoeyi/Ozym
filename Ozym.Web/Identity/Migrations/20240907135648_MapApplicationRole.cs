using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ozym.Web.Identity.Migrations
{
    /// <inheritdoc />
    public partial class MapApplicationRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "WebId",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "WebId",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50d8a8e2-772b-474e-bcf3-b0108bc003b6", "dbcd874d-8d47-4530-ad34-5a0b46971fed", "Datawriter", "DATAWRITER" },
                    { "9831dc10-ddc1-455b-bc05-e19e81ee9e98", "c75177d6-031e-44a9-90f3-c24497fb61ea", "Superuser", "SUPERUSER" },
                    { "e8a39bc3-4a87-47b7-87df-c0d706368b05", "5812bd14-f377-4c7e-ba1d-975801540ec5", "Datareader", "DATAREADER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50d8a8e2-772b-474e-bcf3-b0108bc003b6");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9831dc10-ddc1-455b-bc05-e19e81ee9e98");

            migrationBuilder.DeleteData(
                schema: "WebId",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a39bc3-4a87-47b7-87df-c0d706368b05");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                schema: "WebId",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

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
    }
}
