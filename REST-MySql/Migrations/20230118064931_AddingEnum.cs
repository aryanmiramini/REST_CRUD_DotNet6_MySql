using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_MySql.Migrations
{
    public partial class AddingEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookMaterial",
                table: "BookS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 1,
                column: "BookMaterial",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookS",
                keyColumn: "Id",
                keyValue: 3,
                column: "BookMaterial",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookMaterial",
                table: "BookS");
        }
    }
}
