using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_MySql.Migrations
{
    public partial class ReCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookMaterial",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 4,
                column: "BookMaterial",
                value: 0);
        }
    }
}
