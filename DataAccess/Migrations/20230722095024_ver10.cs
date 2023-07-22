using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ver10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCart_Games_GameId",
                table: "UserCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCart",
                table: "UserCart");

            migrationBuilder.RenameTable(
                name: "UserCart",
                newName: "UserCarts");

            migrationBuilder.RenameIndex(
                name: "IX_UserCart_GameId",
                table: "UserCarts",
                newName: "IX_UserCarts_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCarts",
                table: "UserCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCarts_Games_GameId",
                table: "UserCarts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCarts_Games_GameId",
                table: "UserCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCarts",
                table: "UserCarts");

            migrationBuilder.RenameTable(
                name: "UserCarts",
                newName: "UserCart");

            migrationBuilder.RenameIndex(
                name: "IX_UserCarts_GameId",
                table: "UserCart",
                newName: "IX_UserCart_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCart",
                table: "UserCart",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCart_Games_GameId",
                table: "UserCart",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
