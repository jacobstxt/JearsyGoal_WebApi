using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Editnameoftables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tbl_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_tbl_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "tbl_OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "tbl_OrderItems",
                newName: "IX_tbl_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "tbl_OrderItems",
                newName: "IX_tbl_OrderItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_OrderItems",
                table: "tbl_OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_OrderItems_tbl_Orders_OrderId",
                table: "tbl_OrderItems",
                column: "OrderId",
                principalTable: "tbl_Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_OrderItems_tbl_Products_ProductId",
                table: "tbl_OrderItems",
                column: "ProductId",
                principalTable: "tbl_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_OrderItems_tbl_Orders_OrderId",
                table: "tbl_OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_OrderItems_tbl_Products_ProductId",
                table: "tbl_OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_OrderItems",
                table: "tbl_OrderItems");

            migrationBuilder.RenameTable(
                name: "tbl_OrderItems",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_OrderItems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_OrderItems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

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
        }
    }
}
