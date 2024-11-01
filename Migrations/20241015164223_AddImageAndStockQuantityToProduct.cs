using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace commerceProjet.Migrations
{
    /// <inheritdoc />
    public partial class AddImageAndStockQuantityToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageCat",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageCat",
                table: "Category");
        }
    }
}
