using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserManagement.Migrations
{
    public partial class TestSeedDataAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_LKP_ROLE_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_MST_USERS_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "USER_ROLE");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "USER_ROLE",
                newName: "IX_USER_ROLE_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER_ROLE",
                table: "USER_ROLE",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "LKP_ROLE",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b222d955-6fe6-4a6f-8190-60ad4298058a");

            migrationBuilder.InsertData(
                table: "MST_USERS",
                columns: new[] { "UserId", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "fad3e178-3d79-45b5-af06-09b0e406bba8", "admin-st@yopmail.com", true, false, null, "ADMIN-ST@YOPMAIL.COM", "ADMIN-ST@YOPMAIL.COM", "AQAAAAEAACcQAAAAEM3rDxVY2sLJsX6rVxCd6/ZRXZEoZssNlROSGYXy8dskBIVvcYr0JJl2Vd5a+x9+5Q==", null, false, "f04a26db-2b4d-48fb-92b2-64d0dd7eeb28", false, "admin-st@yopmail.com" });

            migrationBuilder.InsertData(
                table: "USER_ROLE",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_LKP_ROLE_RoleId",
                table: "USER_ROLE",
                column: "RoleId",
                principalTable: "LKP_ROLE",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_ROLE_MST_USERS_UserId",
                table: "USER_ROLE",
                column: "UserId",
                principalTable: "MST_USERS",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_LKP_ROLE_RoleId",
                table: "USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_ROLE_MST_USERS_UserId",
                table: "USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER_ROLE",
                table: "USER_ROLE");

            migrationBuilder.DeleteData(
                table: "USER_ROLE",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MST_USERS",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "USER_ROLE",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_USER_ROLE_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.UpdateData(
                table: "LKP_ROLE",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5a101452-ca36-4b1a-ac93-b8a76d4db0cd");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_LKP_ROLE_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "LKP_ROLE",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_MST_USERS_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "MST_USERS",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
