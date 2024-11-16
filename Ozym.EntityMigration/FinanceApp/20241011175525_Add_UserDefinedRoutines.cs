using Microsoft.EntityFrameworkCore.Migrations;
using Ozym.EntityModel;

#nullable disable

namespace Ozym.EntityMigration.FinanceApp
{
    /// <inheritdoc />
    public partial class Add_UserDefinedRoutines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUserDefinedFunctions();
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUserDefinedFunctions();
        }
    }
}
