using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _1102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Endpoints_EndpointId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_EndpointId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EndpointId",
                table: "Roles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3469),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2938),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2504),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2359),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2226),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1843),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1729),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3074),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1178),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9416));

            migrationBuilder.CreateTable(
                name: "EndpointRole",
                columns: table => new
                {
                    EndpointsId = table.Column<int>(type: "int", nullable: false),
                    RolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndpointRole", x => new { x.EndpointsId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_EndpointRole_Endpoints_EndpointsId",
                        column: x => x.EndpointsId,
                        principalTable: "Endpoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndpointRole_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EndpointRole_RolesId",
                table: "EndpointRole",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndpointRole");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1471),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1302),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3211));

            migrationBuilder.AddColumn<int>(
                name: "EndpointId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(702),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(598),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(486),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Menus",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(221),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2226));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Endpoints",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(59),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(2099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9946),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9837),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 719, DateTimeKind.Local).AddTicks(1009),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9181),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 1, 11, 16, 12, 32, 718, DateTimeKind.Local).AddTicks(9416),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 1, 11, 16, 15, 13, 638, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EndpointId",
                table: "Roles",
                column: "EndpointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Endpoints_EndpointId",
                table: "Roles",
                column: "EndpointId",
                principalTable: "Endpoints",
                principalColumn: "Id");
        }
    }
}
