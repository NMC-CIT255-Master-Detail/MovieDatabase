using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.EntityFramework.Migrations
{
    public partial class UpdatedStudioModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Phone",
                table: "Studios",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Studios",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
