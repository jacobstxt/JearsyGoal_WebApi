using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Editnameofmanytables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_tblProducts_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tblOrders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tblProducts_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tblDeliveryInfos_tblCities_CityId",
                table: "tblDeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tblDeliveryInfos_tblOrders_OrderId",
                table: "tblDeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tblDeliveryInfos_tblPaymentTypes_PaymentTypeId",
                table: "tblDeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tblDeliveryInfos_tblPostDepartments_PostDepartmentId",
                table: "tblDeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_AspNetUsers_UserId",
                table: "tblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrders_tblOrderStatuses_OrderStatusId",
                table: "tblOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_tblPostDepartments_tblCities_CityId",
                table: "tblPostDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductImages_tblProducts_ProductId",
                table: "tblProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductIngredients_tblIngredients_IngredientId",
                table: "tblProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductIngredients_tblProducts_ProductId",
                table: "tblProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblCategories_CategoryId",
                table: "tblProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProducts_tblProductSizes_ProductSizeId",
                table: "tblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProductSizes",
                table: "tblProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProductIngredients",
                table: "tblProductIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProductImages",
                table: "tblProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPostDepartments",
                table: "tblPostDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPaymentTypes",
                table: "tblPaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrderStatuses",
                table: "tblOrderStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblIngredients",
                table: "tblIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblDeliveryInfos",
                table: "tblDeliveryInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCities",
                table: "tblCities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCategories",
                table: "tblCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "tblProductSizes",
                newName: "tbl_ProductSizes");

            migrationBuilder.RenameTable(
                name: "tblProducts",
                newName: "tbl_Products");

            migrationBuilder.RenameTable(
                name: "tblProductIngredients",
                newName: "tbl_ProductIngredients");

            migrationBuilder.RenameTable(
                name: "tblProductImages",
                newName: "tbl_ProductImages");

            migrationBuilder.RenameTable(
                name: "tblPostDepartments",
                newName: "tbl_PostDepartments");

            migrationBuilder.RenameTable(
                name: "tblPaymentTypes",
                newName: "tbl_PaymentTypes");

            migrationBuilder.RenameTable(
                name: "tblOrderStatuses",
                newName: "tbl_OrderStatuses");

            migrationBuilder.RenameTable(
                name: "tblOrders",
                newName: "tbl_Orders");

            migrationBuilder.RenameTable(
                name: "tblIngredients",
                newName: "tbl_Ingredients");

            migrationBuilder.RenameTable(
                name: "tblDeliveryInfos",
                newName: "tbl_DeliveryInfos");

            migrationBuilder.RenameTable(
                name: "tblCities",
                newName: "tbl_Cities");

            migrationBuilder.RenameTable(
                name: "tblCategories",
                newName: "tbl_Categories");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "tbl_Carts");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_ProductSizeId",
                table: "tbl_Products",
                newName: "IX_tbl_Products_ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tbl_Products",
                newName: "IX_tbl_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProductIngredients_IngredientId",
                table: "tbl_ProductIngredients",
                newName: "IX_tbl_ProductIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_tblProductImages_ProductId",
                table: "tbl_ProductImages",
                newName: "IX_tbl_ProductImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tblPostDepartments_CityId",
                table: "tbl_PostDepartments",
                newName: "IX_tbl_PostDepartments_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_tblOrders_UserId",
                table: "tbl_Orders",
                newName: "IX_tbl_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblOrders_OrderStatusId",
                table: "tbl_Orders",
                newName: "IX_tbl_Orders_OrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_tblDeliveryInfos_PostDepartmentId",
                table: "tbl_DeliveryInfos",
                newName: "IX_tbl_DeliveryInfos_PostDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_tblDeliveryInfos_PaymentTypeId",
                table: "tbl_DeliveryInfos",
                newName: "IX_tbl_DeliveryInfos_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tblDeliveryInfos_CityId",
                table: "tbl_DeliveryInfos",
                newName: "IX_tbl_DeliveryInfos_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_UserId",
                table: "tbl_Carts",
                newName: "IX_tbl_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ProductSizes",
                table: "tbl_ProductSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Products",
                table: "tbl_Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ProductIngredients",
                table: "tbl_ProductIngredients",
                columns: new[] { "ProductId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_ProductImages",
                table: "tbl_ProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_PostDepartments",
                table: "tbl_PostDepartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_PaymentTypes",
                table: "tbl_PaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_OrderStatuses",
                table: "tbl_OrderStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Orders",
                table: "tbl_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Ingredients",
                table: "tbl_Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_DeliveryInfos",
                table: "tbl_DeliveryInfos",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Cities",
                table: "tbl_Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Categories",
                table: "tbl_Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Carts",
                table: "tbl_Carts",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_tbl_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "tbl_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_tbl_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Carts_AspNetUsers_UserId",
                table: "tbl_Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Carts_tbl_Products_ProductId",
                table: "tbl_Carts",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Cities_CityId",
                table: "tbl_DeliveryInfos",
                column: "CityId",
                principalTable: "tbl_Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Orders_OrderId",
                table: "tbl_DeliveryInfos",
                column: "OrderId",
                principalTable: "tbl_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_PaymentTypes_PaymentTypeId",
                table: "tbl_DeliveryInfos",
                column: "PaymentTypeId",
                principalTable: "tbl_PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_PostDepartments_PostDepartmentId",
                table: "tbl_DeliveryInfos",
                column: "PostDepartmentId",
                principalTable: "tbl_PostDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Orders_AspNetUsers_UserId",
                table: "tbl_Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Orders_tbl_OrderStatuses_OrderStatusId",
                table: "tbl_Orders",
                column: "OrderStatusId",
                principalTable: "tbl_OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_PostDepartments_tbl_Cities_CityId",
                table: "tbl_PostDepartments",
                column: "CityId",
                principalTable: "tbl_Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ProductImages_tbl_Products_ProductId",
                table: "tbl_ProductImages",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ProductIngredients_tbl_Ingredients_IngredientId",
                table: "tbl_ProductIngredients",
                column: "IngredientId",
                principalTable: "tbl_Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_ProductIngredients_tbl_Products_ProductId",
                table: "tbl_ProductIngredients",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Products_tbl_Categories_CategoryId",
                table: "tbl_Products",
                column: "CategoryId",
                principalTable: "tbl_Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Products_tbl_ProductSizes_ProductSizeId",
                table: "tbl_Products",
                column: "ProductSizeId",
                principalTable: "tbl_ProductSizes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tbl_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tbl_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Carts_AspNetUsers_UserId",
                table: "tbl_Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Carts_tbl_Products_ProductId",
                table: "tbl_Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Cities_CityId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Orders_OrderId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_PaymentTypes_PaymentTypeId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_PostDepartments_PostDepartmentId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Orders_AspNetUsers_UserId",
                table: "tbl_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Orders_tbl_OrderStatuses_OrderStatusId",
                table: "tbl_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_PostDepartments_tbl_Cities_CityId",
                table: "tbl_PostDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ProductImages_tbl_Products_ProductId",
                table: "tbl_ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ProductIngredients_tbl_Ingredients_IngredientId",
                table: "tbl_ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_ProductIngredients_tbl_Products_ProductId",
                table: "tbl_ProductIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Products_tbl_Categories_CategoryId",
                table: "tbl_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Products_tbl_ProductSizes_ProductSizeId",
                table: "tbl_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ProductSizes",
                table: "tbl_ProductSizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Products",
                table: "tbl_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ProductIngredients",
                table: "tbl_ProductIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_ProductImages",
                table: "tbl_ProductImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_PostDepartments",
                table: "tbl_PostDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_PaymentTypes",
                table: "tbl_PaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_OrderStatuses",
                table: "tbl_OrderStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Orders",
                table: "tbl_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Ingredients",
                table: "tbl_Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_DeliveryInfos",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Cities",
                table: "tbl_Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Categories",
                table: "tbl_Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Carts",
                table: "tbl_Carts");

            migrationBuilder.RenameTable(
                name: "tbl_ProductSizes",
                newName: "tblProductSizes");

            migrationBuilder.RenameTable(
                name: "tbl_Products",
                newName: "tblProducts");

            migrationBuilder.RenameTable(
                name: "tbl_ProductIngredients",
                newName: "tblProductIngredients");

            migrationBuilder.RenameTable(
                name: "tbl_ProductImages",
                newName: "tblProductImages");

            migrationBuilder.RenameTable(
                name: "tbl_PostDepartments",
                newName: "tblPostDepartments");

            migrationBuilder.RenameTable(
                name: "tbl_PaymentTypes",
                newName: "tblPaymentTypes");

            migrationBuilder.RenameTable(
                name: "tbl_OrderStatuses",
                newName: "tblOrderStatuses");

            migrationBuilder.RenameTable(
                name: "tbl_Orders",
                newName: "tblOrders");

            migrationBuilder.RenameTable(
                name: "tbl_Ingredients",
                newName: "tblIngredients");

            migrationBuilder.RenameTable(
                name: "tbl_DeliveryInfos",
                newName: "tblDeliveryInfos");

            migrationBuilder.RenameTable(
                name: "tbl_Cities",
                newName: "tblCities");

            migrationBuilder.RenameTable(
                name: "tbl_Categories",
                newName: "tblCategories");

            migrationBuilder.RenameTable(
                name: "tbl_Carts",
                newName: "Carts");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Products_ProductSizeId",
                table: "tblProducts",
                newName: "IX_tblProducts_ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Products_CategoryId",
                table: "tblProducts",
                newName: "IX_tblProducts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ProductIngredients_IngredientId",
                table: "tblProductIngredients",
                newName: "IX_tblProductIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_ProductImages_ProductId",
                table: "tblProductImages",
                newName: "IX_tblProductImages_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_PostDepartments_CityId",
                table: "tblPostDepartments",
                newName: "IX_tblPostDepartments_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Orders_UserId",
                table: "tblOrders",
                newName: "IX_tblOrders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Orders_OrderStatusId",
                table: "tblOrders",
                newName: "IX_tblOrders_OrderStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_DeliveryInfos_PostDepartmentId",
                table: "tblDeliveryInfos",
                newName: "IX_tblDeliveryInfos_PostDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_DeliveryInfos_PaymentTypeId",
                table: "tblDeliveryInfos",
                newName: "IX_tblDeliveryInfos_PaymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_DeliveryInfos_CityId",
                table: "tblDeliveryInfos",
                newName: "IX_tblDeliveryInfos_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Carts_UserId",
                table: "Carts",
                newName: "IX_Carts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProductSizes",
                table: "tblProductSizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProducts",
                table: "tblProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProductIngredients",
                table: "tblProductIngredients",
                columns: new[] { "ProductId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProductImages",
                table: "tblProductImages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPostDepartments",
                table: "tblPostDepartments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPaymentTypes",
                table: "tblPaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrderStatuses",
                table: "tblOrderStatuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblOrders",
                table: "tblOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblIngredients",
                table: "tblIngredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblDeliveryInfos",
                table: "tblDeliveryInfos",
                column: "OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCities",
                table: "tblCities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCategories",
                table: "tblCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                columns: new[] { "ProductId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_tblProducts_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_tblOrders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "tblOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_tblProducts_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDeliveryInfos_tblCities_CityId",
                table: "tblDeliveryInfos",
                column: "CityId",
                principalTable: "tblCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDeliveryInfos_tblOrders_OrderId",
                table: "tblDeliveryInfos",
                column: "OrderId",
                principalTable: "tblOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDeliveryInfos_tblPaymentTypes_PaymentTypeId",
                table: "tblDeliveryInfos",
                column: "PaymentTypeId",
                principalTable: "tblPaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblDeliveryInfos_tblPostDepartments_PostDepartmentId",
                table: "tblDeliveryInfos",
                column: "PostDepartmentId",
                principalTable: "tblPostDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_AspNetUsers_UserId",
                table: "tblOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrders_tblOrderStatuses_OrderStatusId",
                table: "tblOrders",
                column: "OrderStatusId",
                principalTable: "tblOrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblPostDepartments_tblCities_CityId",
                table: "tblPostDepartments",
                column: "CityId",
                principalTable: "tblCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductImages_tblProducts_ProductId",
                table: "tblProductImages",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductIngredients_tblIngredients_IngredientId",
                table: "tblProductIngredients",
                column: "IngredientId",
                principalTable: "tblIngredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductIngredients_tblProducts_ProductId",
                table: "tblProductIngredients",
                column: "ProductId",
                principalTable: "tblProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblCategories_CategoryId",
                table: "tblProducts",
                column: "CategoryId",
                principalTable: "tblCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProducts_tblProductSizes_ProductSizeId",
                table: "tblProducts",
                column: "ProductSizeId",
                principalTable: "tblProductSizes",
                principalColumn: "Id");
        }
    }
}
