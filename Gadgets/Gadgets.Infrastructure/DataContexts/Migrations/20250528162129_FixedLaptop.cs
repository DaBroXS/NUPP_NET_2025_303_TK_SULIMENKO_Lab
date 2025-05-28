using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gadgets.Infrastructure.DataContexts.Migrations
{
    /// <inheritdoc />
    public partial class FixedLaptop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Screens_LaptopModel",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "LaptopModel",
                table: "Laptops",
                newName: "ScreenId");

            migrationBuilder.RenameIndex(
                name: "IX_Laptops_LaptopModel",
                table: "Laptops",
                newName: "IX_Laptops_ScreenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Screens_ScreenId",
                table: "Laptops",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptops_Screens_ScreenId",
                table: "Laptops");

            migrationBuilder.RenameColumn(
                name: "ScreenId",
                table: "Laptops",
                newName: "LaptopModel");

            migrationBuilder.RenameIndex(
                name: "IX_Laptops_ScreenId",
                table: "Laptops",
                newName: "IX_Laptops_LaptopModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptops_Screens_LaptopModel",
                table: "Laptops",
                column: "LaptopModel",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
