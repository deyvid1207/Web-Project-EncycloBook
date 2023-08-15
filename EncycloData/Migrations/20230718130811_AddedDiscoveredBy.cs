using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBook.Data.Migrations
{
    public partial class AddedDiscoveredBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscoveredBy",
                table: "Post",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "YearDiscovered",
                table: "Post",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscoveredBy",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "YearDiscovered",
                table: "Post");
        }
    }
}
