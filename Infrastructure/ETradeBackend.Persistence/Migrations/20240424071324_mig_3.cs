using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETradeBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwapForProductAdverts_Products_ProductId",
                table: "SwapForProductAdverts");

            migrationBuilder.DropIndex(
                name: "IX_SwapForProductAdverts_ProductId",
                table: "SwapForProductAdverts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "SwapForProductAdverts");

            migrationBuilder.CreateIndex(
                name: "IX_SwapForProductAdverts_DesiredProductId",
                table: "SwapForProductAdverts",
                column: "DesiredProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwapForProductAdverts_Products_DesiredProductId",
                table: "SwapForProductAdverts",
                column: "DesiredProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwapForProductAdverts_Products_DesiredProductId",
                table: "SwapForProductAdverts");

            migrationBuilder.DropIndex(
                name: "IX_SwapForProductAdverts_DesiredProductId",
                table: "SwapForProductAdverts");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "SwapForProductAdverts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwapForProductAdverts_ProductId",
                table: "SwapForProductAdverts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwapForProductAdverts_Products_ProductId",
                table: "SwapForProductAdverts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
