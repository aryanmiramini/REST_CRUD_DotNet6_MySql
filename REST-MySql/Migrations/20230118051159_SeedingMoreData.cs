using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_MySql.Migrations
{
    public partial class SeedingMoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Test3");

            migrationBuilder.InsertData(
                table: "BookS",
                columns: new[] { "Id", "Author", "Language", "Title" },
                values: new object[] { 3, "NotInjaneb", "English", "Test4" });

            migrationBuilder.InsertData(
                table: "BookS",
                columns: new[] { "Id", "Author", "Language", "Title" },
                values: new object[] { 4, "Arabdude", "Arabic", "Test5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Test2");
        }
    }
}
