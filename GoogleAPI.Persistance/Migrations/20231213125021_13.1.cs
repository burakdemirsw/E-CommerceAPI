using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class _131 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3611),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.AlterColumn<decimal>(
                name: "NormalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ticket_2",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ticket_3",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2842),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2664),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.AlterColumn<int>(
                name: "BasketId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2417),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2311),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2201),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2050),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(1637),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(1902),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8397));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Ticket_2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Ticket_3",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ShippingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(155),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(13),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3502));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Providers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9772),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.AlterColumn<decimal>(
                name: "NormalPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9194),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2664));

            migrationBuilder.AlterColumn<int>(
                name: "BasketId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(2050));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BillingAddresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(3348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Baskets",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BasketItems",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8397),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 12, 13, 15, 50, 21, 209, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId",
                unique: true,
                filter: "[BasketId] IS NOT NULL");
        }
    }
}
