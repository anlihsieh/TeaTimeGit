using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeaTimeDemo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomizationSystemTablesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SelectionMode = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    MinSelection = table.Column<int>(type: "int", nullable: false),
                    MaxSelection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    MinQty = table.Column<int>(type: "int", nullable: false),
                    MaxQty = table.Column<int>(type: "int", nullable: false),
                    CustomGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomOptions_CustomGroups_CustomGroupId",
                        column: x => x.CustomGroupId,
                        principalTable: "CustomGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomGroupId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCustomGroups_CustomGroups_CustomGroupId",
                        column: x => x.CustomGroupId,
                        principalTable: "CustomGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCustomGroups_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomTemplateGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomTemplateId = table.Column<int>(type: "int", nullable: false),
                    CustomGroupId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomTemplateGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomTemplateGroups_CustomGroups_CustomGroupId",
                        column: x => x.CustomGroupId,
                        principalTable: "CustomGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomTemplateGroups_CustomTemplates_CustomTemplateId",
                        column: x => x.CustomTemplateId,
                        principalTable: "CustomTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetailCustomOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    CustomOptionId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailCustomOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetailCustomOptions_CustomOptions_CustomOptionId",
                        column: x => x.CustomOptionId,
                        principalTable: "CustomOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetailCustomOptions_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartCustomOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    CustomOptionId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartCustomOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartCustomOptions_CustomOptions_CustomOptionId",
                        column: x => x.CustomOptionId,
                        principalTable: "CustomOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartCustomOptions_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomGroups",
                columns: new[] { "Id", "IsRequired", "MaxSelection", "MinSelection", "Name", "SelectionMode" },
                values: new object[,]
                {
                    { 1, true, 1, 1, "尺寸", 1 },
                    { 2, true, 1, 1, "甜度", 1 },
                    { 3, true, 1, 1, "溫度", 1 },
                    { 4, false, 2, 0, "加料", 2 },
                    { 5, true, 1, 1, "尺寸", 1 },
                    { 6, true, 1, 1, "甜度", 1 },
                    { 7, true, 1, 1, "溫度", 1 },
                    { 8, true, 1, 1, "尺寸", 1 },
                    { 9, true, 1, 1, "溫度", 1 }
                });

            migrationBuilder.InsertData(
                table: "CustomTemplates",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "", "預設" });

            migrationBuilder.InsertData(
                table: "CustomOptions",
                columns: new[] { "Id", "CustomGroupId", "MaxQty", "MinQty", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 0, "中杯", 0m },
                    { 2, 1, 1, 0, "大杯", 5m },
                    { 3, 2, 1, 0, "全糖", 0m },
                    { 4, 2, 1, 0, "少糖", 0m },
                    { 5, 2, 1, 0, "半糖", 0m },
                    { 6, 2, 1, 0, "微糖", 0m },
                    { 7, 2, 1, 0, "一分糖", 0m },
                    { 8, 2, 1, 0, "無糖", 0m },
                    { 9, 3, 1, 0, "正常冰", 0m },
                    { 10, 3, 1, 0, "少冰", 0m },
                    { 11, 3, 1, 0, "微冰", 0m },
                    { 12, 3, 1, 0, "去冰", 0m },
                    { 13, 3, 1, 0, "常溫", 0m },
                    { 14, 3, 1, 0, "溫", 0m },
                    { 15, 3, 1, 0, "熱", 0m },
                    { 16, 4, 2, 0, "珍珠", 10m },
                    { 17, 5, 1, 0, "大杯", 0m },
                    { 18, 6, 1, 0, "全糖", 0m },
                    { 19, 6, 1, 0, "少糖", 0m },
                    { 20, 6, 1, 0, "半糖", 0m },
                    { 21, 7, 1, 0, "正常冰", 0m },
                    { 22, 7, 1, 0, "少冰", 0m },
                    { 23, 7, 1, 0, "微冰", 0m },
                    { 24, 7, 1, 0, "去冰", 0m },
                    { 25, 8, 1, 0, "中杯", 0m },
                    { 26, 9, 1, 0, "正常冰", 0m },
                    { 27, 9, 1, 0, "少冰", 0m },
                    { 28, 9, 1, 0, "微冰", 0m },
                    { 29, 9, 1, 0, "去冰", 0m },
                    { 30, 9, 1, 0, "常溫", 0m },
                    { 31, 9, 1, 0, "溫", 0m },
                    { 32, 9, 1, 0, "熱", 0m }
                });

            migrationBuilder.InsertData(
                table: "CustomTemplateGroups",
                columns: new[] { "Id", "CustomGroupId", "CustomTemplateId", "DisplayOrder" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 2 },
                    { 4, 4, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProductCustomGroups",
                columns: new[] { "Id", "CustomGroupId", "DisplayOrder", "ProductId" },
                values: new object[,]
                {
                    { 1, 5, 0, 1 },
                    { 2, 6, 1, 1 },
                    { 3, 7, 2, 1 },
                    { 4, 1, 0, 2 },
                    { 5, 2, 1, 2 },
                    { 6, 3, 2, 2 },
                    { 7, 4, 3, 2 },
                    { 8, 8, 0, 3 },
                    { 9, 9, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomOptions_CustomGroupId",
                table: "CustomOptions",
                column: "CustomGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTemplateGroups_CustomGroupId",
                table: "CustomTemplateGroups",
                column: "CustomGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomTemplateGroups_CustomTemplateId",
                table: "CustomTemplateGroups",
                column: "CustomTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailCustomOptions_CustomOptionId",
                table: "OrderDetailCustomOptions",
                column: "CustomOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetailCustomOptions_OrderDetailId",
                table: "OrderDetailCustomOptions",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomGroups_CustomGroupId",
                table: "ProductCustomGroups",
                column: "CustomGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomGroups_ProductId",
                table: "ProductCustomGroups",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartCustomOptions_CustomOptionId",
                table: "ShoppingCartCustomOptions",
                column: "CustomOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartCustomOptions_ShoppingCartId",
                table: "ShoppingCartCustomOptions",
                column: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomTemplateGroups");

            migrationBuilder.DropTable(
                name: "OrderDetailCustomOptions");

            migrationBuilder.DropTable(
                name: "ProductCustomGroups");

            migrationBuilder.DropTable(
                name: "ShoppingCartCustomOptions");

            migrationBuilder.DropTable(
                name: "CustomTemplates");

            migrationBuilder.DropTable(
                name: "CustomOptions");

            migrationBuilder.DropTable(
                name: "CustomGroups");
        }
    }
}
