using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Ver12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "GameKeys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameKeys_OrderId",
                table: "GameKeys",
                columns: new[] {"OrderId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameKeys_OrderDetails",
                table: "GameKeys",
                columns: new[] { "OrderId", "GameId" },
                principalTable: "OrderDetails",
                principalColumns: new[] { "OrderId", "GameId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameKeys_OrderDetails_OrderDetailOrderId_OrderDetailGameId",
                table: "GameKeys");

            migrationBuilder.DropIndex(
                name: "IX_GameKeys_OrderDetailOrderId_OrderDetailGameId",
                table: "GameKeys");

            migrationBuilder.DropColumn(
                name: "OrderDetailGameId",
                table: "GameKeys");

            migrationBuilder.DropColumn(
                name: "OrderDetailOrderId",
                table: "GameKeys");
        }
    }
}
