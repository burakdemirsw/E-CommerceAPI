using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4880));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5077));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5341),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4880),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4776),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4643),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4280),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(4167),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(3957),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Addresses",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 46, 20, 315, DateTimeKind.Local).AddTicks(5077),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3691));

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
