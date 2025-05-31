using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Addtbl_productIngridients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_productIngridients",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    IngredientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_productIngridients", x => new { x.ProductId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_tbl_productIngridients_tbl_ingridients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "tbl_ingridients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_productIngridients_tbl_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tbl_products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_productIngridients_IngredientId",
                table: "tbl_productIngridients",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_productIngridients");
        }
    }
}
