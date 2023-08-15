using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBook.Data.Migrations
{
    public partial class fser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Symptoms_SymptomId",
                table: "Post");

            migrationBuilder.AddColumn<string>(
                name: "Host",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParasiticFungus_SymptomId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Virus_SymptomId",
                table: "Post",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_ParasiticFungus_SymptomId",
                table: "Post",
                column: "ParasiticFungus_SymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Virus_SymptomId",
                table: "Post",
                column: "Virus_SymptomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Symptoms_ParasiticFungus_SymptomId",
                table: "Post",
                column: "ParasiticFungus_SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Symptoms_SymptomId",
                table: "Post",
                column: "SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Symptoms_Virus_SymptomId",
                table: "Post",
                column: "Virus_SymptomId",
                principalTable: "Symptoms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Symptoms_ParasiticFungus_SymptomId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Symptoms_SymptomId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Symptoms_Virus_SymptomId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_ParasiticFungus_SymptomId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Virus_SymptomId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Host",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "ParasiticFungus_SymptomId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Virus_SymptomId",
                table: "Post");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Food_FoodId",
                table: "Post",
                column: "FoodId",
                principalTable: "Food",
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
    }
}
