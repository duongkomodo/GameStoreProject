using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ver4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCartUserId",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserCart",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCart", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserCart_User",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_UserCart_UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "UserCart");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserCartUserId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");
        }
    }
}
