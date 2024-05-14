using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class mig16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(120)",
                oldMaxLength: 120);
        }
    }
}
