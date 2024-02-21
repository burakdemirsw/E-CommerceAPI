using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class k1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoPaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCPCActive = table.Column<bool>(type: "bit", nullable: false),
                    CPCPrice = table.Column<decimal>(name: "CPC_Price", type: "decimal(18,2)", nullable: false),
                    CPCLowerPriceLimit = table.Column<decimal>(name: "CPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    CPCUpperPriceLimit = table.Column<decimal>(name: "CPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    IsCCPCActive = table.Column<bool>(type: "bit", nullable: false),
                    CCPCPrice = table.Column<decimal>(name: "CCPC_Price", type: "decimal(18,2)", nullable: false),
                    CCCPCLowerPriceLimit = table.Column<decimal>(name: "CCCPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    CCPCUpperPriceLimit = table.Column<decimal>(name: "CCPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    IsBPCActive = table.Column<bool>(type: "bit", nullable: false),
                    BPCPrice = table.Column<decimal>(name: "BPC_Price", type: "decimal(18,2)", nullable: false),
                    BPCLowerPriceLimit = table.Column<decimal>(name: "BPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    BPCUpperPriceLimit = table.Column<decimal>(name: "BPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isZPLBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDifferentBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
