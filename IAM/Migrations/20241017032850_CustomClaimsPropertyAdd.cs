using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAM.Migrations
{
    /// <inheritdoc />
    public partial class CustomClaimsPropertyAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Users",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CustomClaims",
                table: "Users",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomClaims",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Users",
                newName: "Department");
        }
    }
}
