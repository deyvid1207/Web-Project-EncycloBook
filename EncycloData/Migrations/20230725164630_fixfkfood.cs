using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncycloBook.Data.Migrations
{
    public partial class fixfkfood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Leaves" },
                    { 2, "Flowers" },
                    { 3, "Grass" },
                    { 4, "Mammals" },
                    { 5, "Fish" },
                    { 6, "Mushrooms" },
                    { 7, "Birds" },
                    { 8, "Everything" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "IsLifeThreatening", "Name" },
                values: new object[,]
                {
                    { 1, false, "Fever" },
                    { 2, false, "Stomachache" },
                    { 3, false, "Headache" },
                    { 4, true, "Major Organ Failure" },
                    { 5, false, "Dehydration" },
                    { 6, true, "Extreme Dehydration" },
                    { 7, false, "Fatigue" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Symptoms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Food",
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
        }
    }
}
