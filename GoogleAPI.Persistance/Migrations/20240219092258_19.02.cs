using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1902 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CCCPC_LowerPriceLimit",
                table: "CargoFirms",
                newName: "CCPC_LowerPriceLimit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CCPC_LowerPriceLimit",
                table: "CargoFirms",
                newName: "CCCPC_LowerPriceLimit");
        }
    }
}
