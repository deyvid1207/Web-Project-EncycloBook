using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBookData.Migrations
{
    public partial class CustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_PublisherId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Bacteria_AspNetUsers_PublisherId",
                table: "Bacteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Fungi_AspNetUsers_PublisherId",
                table: "Fungi");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_PublisherId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_AspNetUsers_PublisherId",
                table: "Viruses");

            migrationBuilder.AddColumn<Guid>(
                name: "PostUserId",
                table: "Viruses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostUserId",
                table: "Plants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostUserId",
                table: "Fungi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PostUserId",
                table: "Bacteria",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "PostUserId",
                table: "Animals",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viruses_PostUserId",
                table: "Viruses",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_PostUserId",
                table: "Plants",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Fungi_PostUserId",
                table: "Fungi",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bacteria_PostUserId",
                table: "Bacteria",
                column: "PostUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_PostUserId",
                table: "Animals",
                column: "PostUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_PostUserId",
                table: "Animals",
                column: "PostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_IdentityUser_PublisherId",
                table: "Animals",
                column: "PublisherId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bacteria_AspNetUsers_PostUserId",
                table: "Bacteria",
                column: "PostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bacteria_IdentityUser_PublisherId",
                table: "Bacteria",
                column: "PublisherId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fungi_AspNetUsers_PostUserId",
                table: "Fungi",
                column: "PostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fungi_IdentityUser_PublisherId",
                table: "Fungi",
                column: "PublisherId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_PostUserId",
                table: "Plants",
                column: "PostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_IdentityUser_PublisherId",
                table: "Plants",
                column: "PublisherId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_AspNetUsers_PostUserId",
                table: "Viruses",
                column: "PostUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_IdentityUser_PublisherId",
                table: "Viruses",
                column: "PublisherId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_PostUserId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_IdentityUser_PublisherId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Bacteria_AspNetUsers_PostUserId",
                table: "Bacteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Bacteria_IdentityUser_PublisherId",
                table: "Bacteria");

            migrationBuilder.DropForeignKey(
                name: "FK_Fungi_AspNetUsers_PostUserId",
                table: "Fungi");

            migrationBuilder.DropForeignKey(
                name: "FK_Fungi_IdentityUser_PublisherId",
                table: "Fungi");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_AspNetUsers_PostUserId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_IdentityUser_PublisherId",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_AspNetUsers_PostUserId",
                table: "Viruses");

            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_IdentityUser_PublisherId",
                table: "Viruses");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Viruses_PostUserId",
                table: "Viruses");

            migrationBuilder.DropIndex(
                name: "IX_Plants_PostUserId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Fungi_PostUserId",
                table: "Fungi");

            migrationBuilder.DropIndex(
                name: "IX_Bacteria_PostUserId",
                table: "Bacteria");

            migrationBuilder.DropIndex(
                name: "IX_Animals_PostUserId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "Viruses");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "Fungi");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "Bacteria");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "Animals");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_PublisherId",
                table: "Animals",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bacteria_AspNetUsers_PublisherId",
                table: "Bacteria",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fungi_AspNetUsers_PublisherId",
                table: "Fungi",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_AspNetUsers_PublisherId",
                table: "Plants",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_AspNetUsers_PublisherId",
                table: "Viruses",
                column: "PublisherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
