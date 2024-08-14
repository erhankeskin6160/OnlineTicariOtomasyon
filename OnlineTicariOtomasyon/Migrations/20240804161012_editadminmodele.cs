using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTicariOtomasyon.Migrations
{
    public partial class editadminmodele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                table: "Admins",
                type: "Varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Char(1)",
                oldMaxLength: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                table: "Admins",
                type: "Char(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Varchar(1)",
                oldMaxLength: 1);
        }
    }
}
