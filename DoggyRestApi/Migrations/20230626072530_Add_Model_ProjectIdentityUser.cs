using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoggyRestApi.Migrations
{
    public partial class Add_Model_ProjectIdentityUser : Migration
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

            migrationBuilder.CreateTable(
                name: "shoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingCarts_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TouristRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShoppingCartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItem_shoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "shoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ShoppingCartId",
                table: "LineItem",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_OwnerId",
                table: "shoppingCarts",
                column: "OwnerId",
                unique: true);

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

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "shoppingCarts");

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
