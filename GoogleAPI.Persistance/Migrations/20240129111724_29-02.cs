using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _2902 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarketPlaceId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MarketPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketPlaces", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MarketPlaceId",
                table: "Orders",
                column: "MarketPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_MarketPlaces_MarketPlaceId",
                table: "Orders",
                column: "MarketPlaceId",
                principalTable: "MarketPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_MarketPlaces_MarketPlaceId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "MarketPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MarketPlaceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MarketPlaceId",
                table: "Orders");
        }
    }
}
