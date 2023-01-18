using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_MySql.Migrations
{
    public partial class Secondry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "BookS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookS",
                table: "BookS",
                column: "Id");

            migrationBuilder.InsertData(
                table: "BookS",
                columns: new[] { "Id", "Author", "Language", "Title" },
                values: new object[] { 1, "Injaneb", "Persian", "Test1" });

            migrationBuilder.InsertData(
                table: "BookS",
                columns: new[] { "Id", "Author", "Language", "Title" },
                values: new object[] { 2, "NotInjaneb", "English", "Test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookS",
                table: "BookS");

            migrationBuilder.DeleteData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "BookS",
                newName: "Books");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }
    }
}
