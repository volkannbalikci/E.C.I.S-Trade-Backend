using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETradeBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwapForCategoryAdverts_Categories_CategoryId",
                table: "SwapForCategoryAdverts");

            migrationBuilder.DropIndex(
                name: "IX_SwapForCategoryAdverts_CategoryId",
                table: "SwapForCategoryAdverts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SwapForCategoryAdverts");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "AdvertPhotoPaths",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_SwapForCategoryAdverts_DesiredCategoryId",
                table: "SwapForCategoryAdverts",
                column: "DesiredCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwapForCategoryAdverts_Categories_DesiredCategoryId",
                table: "SwapForCategoryAdverts",
                column: "DesiredCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SwapForCategoryAdverts_Categories_DesiredCategoryId",
                table: "SwapForCategoryAdverts");

            migrationBuilder.DropIndex(
                name: "IX_SwapForCategoryAdverts_DesiredCategoryId",
                table: "SwapForCategoryAdverts");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "AdvertPhotoPaths");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "SwapForCategoryAdverts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SwapForCategoryAdverts_CategoryId",
                table: "SwapForCategoryAdverts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SwapForCategoryAdverts_Categories_CategoryId",
                table: "SwapForCategoryAdverts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
