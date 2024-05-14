using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departments_DepartmentsDepartmentId",
                table: "Personels");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDepartmentId",
                table: "Personels",
                newName: "Departmentid");

            migrationBuilder.RenameIndex(
                name: "IX_Personels_DepartmentsDepartmentId",
                table: "Personels",
                newName: "IX_Personels_Departmentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departments_Departmentid",
                table: "Personels",
                column: "Departmentid",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Departments_Departmentid",
                table: "Personels");

            migrationBuilder.RenameColumn(
                name: "Departmentid",
                table: "Personels",
                newName: "DepartmentsDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Personels_Departmentid",
                table: "Personels",
                newName: "IX_Personels_DepartmentsDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Departments_DepartmentsDepartmentId",
                table: "Personels",
                column: "DepartmentsDepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
