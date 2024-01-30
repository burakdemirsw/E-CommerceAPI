using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _2501 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_BillingAddresses_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "CorparateDescription",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorporate",
                table: "ShippingAddresses",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndividual",
                table: "ShippingAddresses",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxAuthorityDescription",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNo",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorparateDescription",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "IsCorporate",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "IsIndividual",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "TaxAuthorityDescription",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "TaxNo",
                table: "ShippingAddresses");

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    NeighborhoodId = table.Column<int>(type: "int", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorparateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCorporate = table.Column<bool>(type: "bit", nullable: true),
                    IsIndividual = table.Column<bool>(type: "bit", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TCKN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAuthorityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Neighborhoods_NeighborhoodId",
                        column: x => x.NeighborhoodId,
                        principalTable: "Neighborhoods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_CountryId",
                table: "BillingAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_DistrictId",
                table: "BillingAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_NeighborhoodId",
                table: "BillingAddresses",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_ProvinceId",
                table: "BillingAddresses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_UserId",
                table: "BillingAddresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_BillingAddresses_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId",
                principalTable: "BillingAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
