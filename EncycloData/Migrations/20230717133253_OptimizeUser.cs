using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloData.Migrations
{
    public partial class OptimizeUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Animal_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Bacteria_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Fungus_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_Virus_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Animal_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Bacteria_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Fungus_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Virus_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Animal_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Bacteria_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Fungus_ApplicationUserId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Virus_ApplicationUserId",
                table: "Post");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Animal_ApplicationUserId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Bacteria_ApplicationUserId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Fungus_ApplicationUserId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Virus_ApplicationUserId",
                table: "Post",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Animal_ApplicationUserId",
                table: "Post",
                column: "Animal_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Bacteria_ApplicationUserId",
                table: "Post",
                column: "Bacteria_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Fungus_ApplicationUserId",
                table: "Post",
                column: "Fungus_ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Virus_ApplicationUserId",
                table: "Post",
                column: "Virus_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Animal_ApplicationUserId",
                table: "Post",
                column: "Animal_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Bacteria_ApplicationUserId",
                table: "Post",
                column: "Bacteria_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Fungus_ApplicationUserId",
                table: "Post",
                column: "Fungus_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_Virus_ApplicationUserId",
                table: "Post",
                column: "Virus_ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
