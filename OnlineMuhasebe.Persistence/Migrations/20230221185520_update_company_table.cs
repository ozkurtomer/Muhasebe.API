using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_company_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyDatabaseName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPassword",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyServerName",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyUserId",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyDatabaseName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyPassword",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyServerName",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Companies");
        }
    }
}
