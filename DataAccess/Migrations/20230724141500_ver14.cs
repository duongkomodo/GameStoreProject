﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ver14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                   name: "OrderDetailGameId",
                   table: "GameKeys");
            migrationBuilder.DropColumn(
          name: "OrderDetailOrderId",
          table: "GameKeys");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "GameKeys",
                newName: "OrderId");

      

            migrationBuilder.CreateIndex(
                name: "IX_GameKeys_OrderId_GameId",
                table: "GameKeys",
                columns: new[] { "OrderId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameKeys_OrderDetails_OrderId_GameId",
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

            migrationBuilder.RenameColumn(
                name: "OrderDetailOrderId",
                table: "GameKeys",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GameKeys_OrderId_GameId",
                table: "GameKeys",
                columns: new[] { "OrderId", "GameId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GameKeys_OrderDetails_OrderId_GameId",
                table: "GameKeys",
                columns: new[] { "OrderId", "GameId" },
                principalTable: "OrderDetails",
                principalColumns: new[] { "OrderId", "GameId" });
        }
    }
}
