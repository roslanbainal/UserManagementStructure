using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Migrations
{
    public partial class CreateEndPointsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndPointsId",
                table: "LKP_ROLE",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ENDPOINTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ControllerName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ActionName = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreatedBy = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDPOINTS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDPOINT_ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EndPointsId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RoleId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDPOINT_ROLES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENDPOINT_ROLES_ENDPOINTS_EndPointsId",
                        column: x => x.EndPointsId,
                        principalTable: "ENDPOINTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENDPOINT_ROLES_LKP_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "LKP_ROLE",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "LKP_ROLE",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c8964fa4-e90c-4a71-b6ef-162ff2f853ef");

            migrationBuilder.UpdateData(
                table: "MST_USERS",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d5dea92-bdd1-4baf-a107-923b469b3be5", "f99e1a30-0da3-4dc4-9f7e-6a41e755955f" });

            migrationBuilder.CreateIndex(
                name: "IX_LKP_ROLE_EndPointsId",
                table: "LKP_ROLE",
                column: "EndPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_ENDPOINT_ROLES_EndPointsId",
                table: "ENDPOINT_ROLES",
                column: "EndPointsId");

            migrationBuilder.CreateIndex(
                name: "IX_ENDPOINT_ROLES_RoleId",
                table: "ENDPOINT_ROLES",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_LKP_ROLE_ENDPOINTS_EndPointsId",
                table: "LKP_ROLE",
                column: "EndPointsId",
                principalTable: "ENDPOINTS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LKP_ROLE_ENDPOINTS_EndPointsId",
                table: "LKP_ROLE");

            migrationBuilder.DropTable(
                name: "ENDPOINT_ROLES");

            migrationBuilder.DropTable(
                name: "ENDPOINTS");

            migrationBuilder.DropIndex(
                name: "IX_LKP_ROLE_EndPointsId",
                table: "LKP_ROLE");

            migrationBuilder.DropColumn(
                name: "EndPointsId",
                table: "LKP_ROLE");

            migrationBuilder.UpdateData(
                table: "LKP_ROLE",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b222d955-6fe6-4a6f-8190-60ad4298058a");

            migrationBuilder.UpdateData(
                table: "MST_USERS",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fad3e178-3d79-45b5-af06-09b0e406bba8", "f04a26db-2b4d-48fb-92b2-64d0dd7eeb28" });
        }
    }
}
