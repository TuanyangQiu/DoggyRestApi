using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggyRestApi.Migrations
{
    public partial class InsertSeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectIdentityUserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectIdentityUserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectIdentityUserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectIdentityUserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a1a8878b-8c3e-4ca4-98d9-615ba9fe59f5", "fa306cbf-3cd9-4244-bba2-03349487fc5c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf306d2c-f248-4231-a825-064adac42106", 0, null, "071454b2-10f7-443f-9b7e-40a6d85f9e65", "admin01@gmail.com", true, false, null, "ADMIN01@GMAIL.COM", "ADMIN01@GMAIL.COM", "AQAAAAEAACcQAAAAEEl7+18SEP4iJ+RDdm2OeiS/3RkU9YQ/sUq20FO4pC55e8jZzm6udcAjwYR9igrA3g==", "0201912077", false, "e97bb290-ed43-4aa9-b5cc-5b1bba70f45a", false, "admin01@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "ProjectIdentityUserId" },
                values: new object[] { "a1a8878b-8c3e-4ca4-98d9-615ba9fe59f5", "cf306d2c-f248-4231-a825-064adac42106", null });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserTokens_ProjectIdentityUserId",
                table: "AspNetUserTokens",
                column: "ProjectIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_ProjectIdentityUserId",
                table: "AspNetUserRoles",
                column: "ProjectIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_ProjectIdentityUserId",
                table: "AspNetUserLogins",
                column: "ProjectIdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_ProjectIdentityUserId",
                table: "AspNetUserClaims",
                column: "ProjectIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserClaims",
                column: "ProjectIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserLogins",
                column: "ProjectIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserRoles",
                column: "ProjectIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserTokens",
                column: "ProjectIdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_ProjectIdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserTokens_ProjectIdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_ProjectIdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserLogins_ProjectIdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserClaims_ProjectIdentityUserId",
                table: "AspNetUserClaims");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a1a8878b-8c3e-4ca4-98d9-615ba9fe59f5", "cf306d2c-f248-4231-a825-064adac42106" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a8878b-8c3e-4ca4-98d9-615ba9fe59f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf306d2c-f248-4231-a825-064adac42106");

            migrationBuilder.DropColumn(
                name: "ProjectIdentityUserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectIdentityUserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "ProjectIdentityUserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropColumn(
                name: "ProjectIdentityUserId",
                table: "AspNetUserClaims");
        }
    }
}
