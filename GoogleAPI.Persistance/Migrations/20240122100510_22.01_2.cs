using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _22012 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "District",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "City",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "District",
                table: "BillingAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "ShippingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "ShippingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "ShippingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "ShippingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "BillingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "BillingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "BillingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "BillingAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2944));

            migrationBuilder.CreateTable(
                name: "Countries",
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
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhoods_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_CountryId",
                table: "ShippingAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_DistrictId",
                table: "ShippingAddresses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_NeighborhoodId",
                table: "ShippingAddresses",
                column: "NeighborhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_ProvinceId",
                table: "ShippingAddresses",
                column: "ProvinceId");

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
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_DistrictId",
                table: "Neighborhoods",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddresses_Countries_CountryId",
                table: "BillingAddresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddresses_Districts_DistrictId",
                table: "BillingAddresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddresses_Neighborhoods_NeighborhoodId",
                table: "BillingAddresses",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillingAddresses_Provinces_ProvinceId",
                table: "BillingAddresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Countries_CountryId",
                table: "ShippingAddresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Districts_DistrictId",
                table: "ShippingAddresses",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Neighborhoods_NeighborhoodId",
                table: "ShippingAddresses",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_Provinces_ProvinceId",
                table: "ShippingAddresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddresses_Countries_CountryId",
                table: "BillingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddresses_Districts_DistrictId",
                table: "BillingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddresses_Neighborhoods_NeighborhoodId",
                table: "BillingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_BillingAddresses_Provinces_ProvinceId",
                table: "BillingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Countries_CountryId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Districts_DistrictId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Neighborhoods_NeighborhoodId",
                table: "ShippingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_Provinces_ProvinceId",
                table: "ShippingAddresses");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_CountryId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_DistrictId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_NeighborhoodId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ShippingAddresses_ProvinceId",
                table: "ShippingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddresses_CountryId",
                table: "BillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddresses_DistrictId",
                table: "BillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddresses_NeighborhoodId",
                table: "BillingAddresses");

            migrationBuilder.DropIndex(
                name: "IX_BillingAddresses_ProvinceId",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "ShippingAddresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "BillingAddresses");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "BillingAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(5111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "ShippingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "BillingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "BillingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "BillingAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
