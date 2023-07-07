using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ver7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_UserCart_UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "UserCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "UserCart",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "UserCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCart_GameId",
                table: "UserCart",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCart_Games_GameId",
                table: "UserCart",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCart_Games_GameId",
                table: "UserCart");

            migrationBuilder.DropIndex(
                name: "IX_UserCart_GameId",
                table: "UserCart");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserCart");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "UserCart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "UserCart");

            migrationBuilder.AddColumn<string>(
                name: "UserCartUserId",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UserCartUserId",
                table: "OrderDetails",
                column: "UserCartUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_UserCart_UserCartUserId",
                table: "OrderDetails",
                column: "UserCartUserId",
                principalTable: "UserCart",
                principalColumn: "UserId");
        }
    }
}
