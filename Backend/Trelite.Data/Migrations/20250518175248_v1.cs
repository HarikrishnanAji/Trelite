using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trelite.Data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "App",
                newName: "Roles",
                newSchema: "Lookup");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Lookup",
                newName: "Roles",
                newSchema: "App");
        }
    }
}
