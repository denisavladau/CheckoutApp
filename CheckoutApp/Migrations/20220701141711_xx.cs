using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckoutApp.Migrations
{
    public partial class xx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Basket_BasketId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_BasketId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BasketId",
                table: "Item",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Basket_BasketId",
                table: "Item",
                column: "BasketId",
                principalTable: "Basket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
