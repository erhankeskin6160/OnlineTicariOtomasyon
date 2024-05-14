using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Products_ProductsProductId",
                table: "SalesActivities");

            migrationBuilder.DropIndex(
                name: "IX_SalesActivities_ProductsProductId",
                table: "SalesActivities");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "SalesActivities");

            migrationBuilder.RenameColumn(
                name: "Urunid",
                table: "SalesActivities",
                newName: "Productid");

            migrationBuilder.CreateIndex(
                name: "IX_SalesActivities_Productid",
                table: "SalesActivities",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Products_Productid",
                table: "SalesActivities",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Products_Productid",
                table: "SalesActivities");

            migrationBuilder.DropIndex(
                name: "IX_SalesActivities_Productid",
                table: "SalesActivities");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "SalesActivities",
                newName: "Urunid");

            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "SalesActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesActivities_ProductsProductId",
                table: "SalesActivities",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Products_ProductsProductId",
                table: "SalesActivities",
                column: "ProductsProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
