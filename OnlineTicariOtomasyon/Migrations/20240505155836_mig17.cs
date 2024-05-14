using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class mig17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(120)",
                oldMaxLength: 120);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)",
                oldMaxLength: 30);
        }
    }
}
