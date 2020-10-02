using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BandApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[] { new Guid("38e324f7-256b-40e8-a55a-a9882f5ed342"), new DateTime(2003, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Cairokee" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "ReleaseDate", "Title" },
                values: new object[] { new Guid("1840d63c-ff07-40d9-95ab-6639d7ddb863"), new Guid("38e324f7-256b-40e8-a55a-a9882f5ed342"), "The best Album ever", new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Ugly Duck" });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "ReleaseDate", "Title" },
                values: new object[] { new Guid("f54f445f-f8dc-4fcc-9e20-64756d0057d7"), new Guid("38e324f7-256b-40e8-a55a-a9882f5ed342"), "The second best Album ever", new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "White Point" });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
