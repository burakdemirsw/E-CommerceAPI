using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _2101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9647),
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
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8952),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8615),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4209));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4055));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8305),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7864),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7278),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7128),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3248));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7000),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3096));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(6542),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(6837),
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7425))
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9071))
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7713))
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
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8148))
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(5111),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4523),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8615));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4055),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3901),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8305));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3761),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3629),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7864));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3248),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(3096),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(4664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(9198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 12, 20, 5, 8, 245, DateTimeKind.Local).AddTicks(2944),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 21, 18, 26, 54, 259, DateTimeKind.Local).AddTicks(6837));
        }
    }
}
