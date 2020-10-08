using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieDatabase.EntityFramework.Migrations
{
    public partial class UpdatedMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Movies",
                type: "varbinary(4000)",
                nullable: true);
        }
    }
}
