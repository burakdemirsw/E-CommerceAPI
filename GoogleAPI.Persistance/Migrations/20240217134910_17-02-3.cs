using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _17023 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.CreateTable(
                name: "CargoFirms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargoPaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    IsSPCActive = table.Column<bool>(type: "bit", nullable: false),
                    SPCPrice = table.Column<decimal>(name: "SPC_Price", type: "decimal(18,2)", nullable: false),
                    SPCLowerPriceLimit = table.Column<decimal>(name: "SPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    SPCUpperPriceLimit = table.Column<decimal>(name: "SPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isZPLBarcode = table.Column<bool>(type: "bit", nullable: false),
                    isDifferentBarcode = table.Column<bool>(type: "bit", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoFirms", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoFirms");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiSecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BPCLowerPriceLimit = table.Column<decimal>(name: "BPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    BPCPrice = table.Column<decimal>(name: "BPC_Price", type: "decimal(18,2)", nullable: false),
                    BPCUpperPriceLimit = table.Column<decimal>(name: "BPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    CCCPCLowerPriceLimit = table.Column<decimal>(name: "CCCPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    CCPCPrice = table.Column<decimal>(name: "CCPC_Price", type: "decimal(18,2)", nullable: false),
                    CCPCUpperPriceLimit = table.Column<decimal>(name: "CCPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    CPCLowerPriceLimit = table.Column<decimal>(name: "CPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    CPCPrice = table.Column<decimal>(name: "CPC_Price", type: "decimal(18,2)", nullable: false),
                    CPCUpperPriceLimit = table.Column<decimal>(name: "CPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    CargoPaymentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBPCActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCCPCActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCPCActive = table.Column<bool>(type: "bit", nullable: false),
                    IsSPCActive = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPCLowerPriceLimit = table.Column<decimal>(name: "SPC_LowerPriceLimit", type: "decimal(18,2)", nullable: false),
                    SPCPrice = table.Column<decimal>(name: "SPC_Price", type: "decimal(18,2)", nullable: false),
                    SPCUpperPriceLimit = table.Column<decimal>(name: "SPC_UpperPriceLimit", type: "decimal(18,2)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDifferentBarcode = table.Column<bool>(type: "bit", nullable: false),
                    isZPLBarcode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });
        }
    }
}
