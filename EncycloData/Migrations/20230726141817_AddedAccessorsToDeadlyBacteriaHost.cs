using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloData.Migrations
{
    public partial class AddedAccessorsToDeadlyBacteriaHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParasiticFungus_Host",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParasiticFungus_Host",
                table: "Post");
        }
    }
}
