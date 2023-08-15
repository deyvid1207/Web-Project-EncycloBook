using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBook.Data.Migrations
{
    public partial class AddedMoreInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalSubClass",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsParasitic",
                table: "Post",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWild",
                table: "Post",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootType",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StemType",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SymptomId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsLifeThreatening = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { -8, "Everything" },
                    { -7, "Birds" },
                    { -6, "Mushrooms" },
                    { -5, "Fish" },
                    { -4, "Mammals" },
                    { -3, "Grass" },
                    { -2, "Flowers" },
                    { -1, "Leaves" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "IsLifeThreatening", "Name" },
                values: new object[,]
                {
                    { -7, false, "Fatigue" },
                    { -6, true, "Extreme Dehydration" },
                    { -5, false, "Dehydration" },
                    { -4, true, "Major Organ Failure" },
                    { -3, false, "Headache" },
                    { -2, false, "Stomachache" },
                    { -1, false, "Fever" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_FoodId",
                table: "Post",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SymptomId",
                table: "Post",
                column: "SymptomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Foods_FoodId",
                table: "Post",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Symptoms_SymptomId",
                table: "Post",
                column: "SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Foods_FoodId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Symptoms_SymptomId",
                table: "Post");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Post_FoodId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_SymptomId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "AnimalSubClass",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsParasitic",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "IsWild",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "RootType",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "StemType",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "SymptomId",
                table: "Post");
        }
    }
}
