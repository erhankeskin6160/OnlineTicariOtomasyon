using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Currents_CurrentsCurrentId",
                table: "SalesActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Personels_PersonelsPersonelId",
                table: "SalesActivities");

            migrationBuilder.DropIndex(
                name: "IX_SalesActivities_PersonelsPersonelId",
                table: "SalesActivities");

            migrationBuilder.RenameColumn(
                name: "PersonelsPersonelId",
                table: "SalesActivities",
                newName: "Urunid");

            migrationBuilder.RenameColumn(
                name: "CurrentsCurrentId",
                table: "SalesActivities",
                newName: "Personelid");

            migrationBuilder.RenameIndex(
                name: "IX_SalesActivities_CurrentsCurrentId",
                table: "SalesActivities",
                newName: "IX_SalesActivities_Personelid");

            migrationBuilder.AddColumn<int>(
                name: "Currentid",
                table: "SalesActivities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SalesActivities_Currentid",
                table: "SalesActivities",
                column: "Currentid");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Currents_Currentid",
                table: "SalesActivities",
                column: "Currentid",
                principalTable: "Currents",
                principalColumn: "CurrentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Personels_Personelid",
                table: "SalesActivities",
                column: "Personelid",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Currents_Currentid",
                table: "SalesActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesActivities_Personels_Personelid",
                table: "SalesActivities");

            migrationBuilder.DropIndex(
                name: "IX_SalesActivities_Currentid",
                table: "SalesActivities");

            migrationBuilder.DropColumn(
                name: "Currentid",
                table: "SalesActivities");

            migrationBuilder.RenameColumn(
                name: "Urunid",
                table: "SalesActivities",
                newName: "PersonelsPersonelId");

            migrationBuilder.RenameColumn(
                name: "Personelid",
                table: "SalesActivities",
                newName: "CurrentsCurrentId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesActivities_Personelid",
                table: "SalesActivities",
                newName: "IX_SalesActivities_CurrentsCurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesActivities_PersonelsPersonelId",
                table: "SalesActivities",
                column: "PersonelsPersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Currents_CurrentsCurrentId",
                table: "SalesActivities",
                column: "CurrentsCurrentId",
                principalTable: "Currents",
                principalColumn: "CurrentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesActivities_Personels_PersonelsPersonelId",
                table: "SalesActivities",
                column: "PersonelsPersonelId",
                principalTable: "Personels",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
