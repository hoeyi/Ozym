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
            migrationBuilder.InsertData(
                schema: "WebIdentity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a9bc966-6537-44c0-ac1e-05ce14b0582e", null, "Superuser", "SUPERUSER" },
                    { "23d885e5-bb87-4c62-ba98-e3a023103b93", null, "Datareader", "DATAREADER" },
                    { "b6d6b6b1-eb69-4ea1-8bb2-ba2a4e130831", null, "Datawriter", "DATAWRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "WebIdentity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a9bc966-6537-44c0-ac1e-05ce14b0582e");

            migrationBuilder.DeleteData(
                schema: "WebIdentity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23d885e5-bb87-4c62-ba98-e3a023103b93");

            migrationBuilder.DeleteData(
                schema: "WebIdentity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6d6b6b1-eb69-4ea1-8bb2-ba2a4e130831");
        }
    }
}
