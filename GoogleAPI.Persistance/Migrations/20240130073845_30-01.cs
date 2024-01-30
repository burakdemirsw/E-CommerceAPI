using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _3001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MarketPlaces_MarketPlaceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Dimensions_DimensionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketPlaces",
                table: "MarketPlaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.RenameTable(
                name: "MarketPlaces",
                newName: "MarketPlace");

            migrationBuilder.RenameTable(
                name: "Dimensions",
                newName: "Dimension");

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "MarketPlace",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApiSecretKey",
                table: "MarketPlace",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                table: "MarketPlace",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketPlace",
                table: "MarketPlace",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MarketPlace_MarketPlaceId",
                table: "Orders",
                column: "MarketPlaceId",
                principalTable: "MarketPlace",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Dimension_DimensionId",
                table: "Products",
                column: "DimensionId",
                principalTable: "Dimension",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MarketPlace_MarketPlaceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Dimension_DimensionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarketPlace",
                table: "MarketPlace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension");

            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "MarketPlace");

            migrationBuilder.DropColumn(
                name: "ApiSecretKey",
                table: "MarketPlace");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "MarketPlace");

            migrationBuilder.RenameTable(
                name: "MarketPlace",
                newName: "MarketPlaces");

            migrationBuilder.RenameTable(
                name: "Dimension",
                newName: "Dimensions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarketPlaces",
                table: "MarketPlaces",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MarketPlaces_MarketPlaceId",
                table: "Orders",
                column: "MarketPlaceId",
                principalTable: "MarketPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Dimensions_DimensionId",
                table: "Products",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
