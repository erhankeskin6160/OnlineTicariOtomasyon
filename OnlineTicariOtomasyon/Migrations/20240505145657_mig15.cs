using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class mig15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentName",
                table: "Currents",
                type: "Varchar(29)",
                maxLength: 29,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CurrentName",
                table: "Currents",
                type: "Varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(29)",
                oldMaxLength: 29);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentLastName",
                table: "Currents",
                type: "Varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(20)",
                oldMaxLength: 20);
        }
    }
}
