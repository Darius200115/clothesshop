using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testproj843823.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItem",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrdersId");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrdersId",
                table: "OrderItem",
                column: "OrdersId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrdersId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Clothes");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrderItem",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrdersId",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
