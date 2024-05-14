using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Items_Bills_BillsBillId",
                table: "Bill_Items");

            migrationBuilder.RenameColumn(
                name: "BillsBillId",
                table: "Bill_Items",
                newName: "BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_Items_BillsBillId",
                table: "Bill_Items",
                newName: "IX_Bill_Items_BillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Items_Bills_BillId",
                table: "Bill_Items",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Items_Bills_BillId",
                table: "Bill_Items");

            migrationBuilder.RenameColumn(
                name: "BillId",
                table: "Bill_Items",
                newName: "BillsBillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_Items_BillId",
                table: "Bill_Items",
                newName: "IX_Bill_Items_BillsBillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Items_Bills_BillsBillId",
                table: "Bill_Items",
                column: "BillsBillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
