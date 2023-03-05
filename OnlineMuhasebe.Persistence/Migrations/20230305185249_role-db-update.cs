using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMuhasebe.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class roledbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsRoleCreatedByAdmin = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleMainRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AppRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMainRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMainRoles_MainRoles_MainRoleId",
                        column: x => x.MainRoleId,
                        principalTable: "MainRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoleMainRoles_Roles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainRoles_CompanyId",
                table: "MainRoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMainRoles_AppRoleId",
                table: "RoleMainRoles",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMainRoles_MainRoleId",
                table: "RoleMainRoles",
                column: "MainRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMainRoles");

            migrationBuilder.DropTable(
                name: "MainRoles");
        }
    }
}
