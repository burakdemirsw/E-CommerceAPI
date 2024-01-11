using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoogleAPI.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhoto_Photos_PhotoId",
                table: "ProductPhoto");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhoto_Products_ProductId",
                table: "ProductPhoto");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhoto",
                table: "ProductPhoto");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductCard_VM");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProductCard_VM");

            migrationBuilder.RenameTable(
                name: "ProductPhoto",
                newName: "ProductPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhoto_PhotoId",
                table: "ProductPhotos",
                newName: "IX_ProductPhotos_PhotoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(281),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(13),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3531));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9489),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8827),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8692),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8577),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2559));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos",
                columns: new[] { "ProductId", "PhotoId" });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaskedNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8166))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BillingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TCKN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIndividual = table.Column<bool>(type: "bit", nullable: true),
                    IsCorporate = table.Column<bool>(type: "bit", nullable: true),
                    CorparateDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxAuthorityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9890))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9772))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(155))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8397))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
                    BasketId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9194))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_BillingAddresses_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "BillingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillingAddresses_UserId",
                table: "BillingAddresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId",
                unique: true,
                filter: "[BasketId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_UserId",
                table: "ShippingAddresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Photos_PhotoId",
                table: "ProductPhotos",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Photos_PhotoId",
                table: "ProductPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPhotos_Products_ProductId",
                table: "ProductPhotos");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "BillingAddresses");

            migrationBuilder.DropTable(
                name: "ShippingAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPhotos",
                table: "ProductPhotos");

            migrationBuilder.RenameTable(
                name: "ProductPhotos",
                newName: "ProductPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPhotos_PhotoId",
                table: "ProductPhoto",
                newName: "IX_ProductPhoto_PhotoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3956),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 777, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3531),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductCard_VM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductCard_VM",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Photos",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9489));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Personals",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Logs",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dimensions",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3036),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2925),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8827));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8692));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Brands",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(2559),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 11, 28, 16, 4, 6, 776, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPhoto",
                table: "ProductPhoto",
                columns: new[] { "ProductId", "PhotoId" });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AddressDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2023, 11, 27, 3, 48, 34, 412, DateTimeKind.Local).AddTicks(3691))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhoto_Photos_PhotoId",
                table: "ProductPhoto",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPhoto_Products_ProductId",
                table: "ProductPhoto",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
