using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;
using System;

namespace MovieDatabase.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Producers",
                table => new
                {
                    ProducerID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Biography = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Producers", x => x.ProducerID); });

            migrationBuilder.CreateTable(
                "Studios",
                table => new
                {
                    StudioID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Studios", x => x.StudioID); });

            migrationBuilder.CreateTable(
                "Movies",
                table => new
                {
                    MovieID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Runtime = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IMDBLink = table.Column<string>(nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    StudioID = table.Column<int>(nullable: true),
                    ProducerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieID);
                    table.ForeignKey(
                        "FK_Movies_Producers_ProducerID",
                        x => x.ProducerID,
                        "Producers",
                        "ProducerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Movies_Studios_StudioID",
                        x => x.StudioID,
                        "Studios",
                        "StudioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Movies_ProducerID",
                "Movies",
                "ProducerID");

            migrationBuilder.CreateIndex(
                "IX_Movies_StudioID",
                "Movies",
                "StudioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Movies");

            migrationBuilder.DropTable(
                "Producers");

            migrationBuilder.DropTable(
                "Studios");
        }
    }
}