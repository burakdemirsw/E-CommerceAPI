using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints");

            migrationBuilder.DropTable(
                name: "Personals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menus",
                table: "Menus");

            migrationBuilder.RenameTable(
                name: "Menus",
                newName: "Menu");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(3057),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2919),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2811),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2553),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2253),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2080),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1760),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1651),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1501),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1389),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(768),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1082),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menu",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1910),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menu",
                table: "Menu",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menu_MenuId",
                table: "Endpoints",
                column: "MenuId",
                principalTable: "Menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endpoints_Menu_MenuId",
                table: "Endpoints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Menu",
                table: "Menu");

            migrationBuilder.RenameTable(
                name: "Menu",
                newName: "Menus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(3057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2919));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2811));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2553));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1501));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 18, 41, 10, 398, DateTimeKind.Local).AddTicks(1910));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Menus",
                table: "Menus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Personals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2504))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personals", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Endpoints_Menus_MenuId",
                table: "Endpoints",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
