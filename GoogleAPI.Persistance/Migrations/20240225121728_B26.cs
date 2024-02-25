using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class B26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StockCode",
                table: "CargoFirms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockCode",
                table: "CargoFirms");
        }
    }
}
