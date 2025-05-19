using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trelite.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId1",
                schema: "App",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId1",
                schema: "App",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                schema: "App",
                table: "Users");

            migrationBuilder.AlterColumn<short>(
                name: "RoleId",
                schema: "App",
                table: "Users",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                schema: "App",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "App",
                table: "Users",
                column: "RoleId",
                principalSchema: "App",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                schema: "App",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                schema: "App",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                schema: "App",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddColumn<short>(
                name: "RoleId1",
                schema: "App",
                table: "Users",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId1",
                schema: "App",
                table: "Users",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId1",
                schema: "App",
                table: "Users",
                column: "RoleId1",
                principalSchema: "App",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
