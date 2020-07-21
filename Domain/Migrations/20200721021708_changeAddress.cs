using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class changeAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "School",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Address",
                table: "School",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
