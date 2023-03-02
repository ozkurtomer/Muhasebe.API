using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class companydbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyUserId",
                table: "Companies",
                newName: "CompanyServerPassword");

            migrationBuilder.RenameColumn(
                name: "CompanyPassword",
                table: "Companies",
                newName: "CompanyServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyServerPassword",
                table: "Companies",
                newName: "CompanyUserId");

            migrationBuilder.RenameColumn(
                name: "CompanyServerId",
                table: "Companies",
                newName: "CompanyPassword");
        }
    }
}
