using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBook.Data.Migrations
{
    public partial class FixedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Foods_FoodId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Foods",
                table: "Foods");

            migrationBuilder.RenameTable(
                name: "Foods",
                newName: "Food");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Food",
                table: "Food",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Food",
                table: "Food");

            migrationBuilder.RenameTable(
                name: "Food",
                newName: "Foods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Foods",
                table: "Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Foods_FoodId",
                table: "Post",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
