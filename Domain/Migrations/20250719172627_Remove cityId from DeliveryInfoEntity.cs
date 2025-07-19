using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class RemovecityIdfromDeliveryInfoEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Cities_CityId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropIndex(
                name: "IX_tbl_DeliveryInfos_CityId",
                table: "tbl_DeliveryInfos");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "tbl_DeliveryInfos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CityId",
                table: "tbl_DeliveryInfos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DeliveryInfos_CityId",
                table: "tbl_DeliveryInfos",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_DeliveryInfos_tbl_Cities_CityId",
                table: "tbl_DeliveryInfos",
                column: "CityId",
                principalTable: "tbl_Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
