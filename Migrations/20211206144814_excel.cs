using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreDemo.Migrations
{
    public partial class excel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonHangnumber",
                table: "Persons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonHangnumber",
                table: "Persons",
                type: "TEXT",
                nullable: true);
        }
    }
}
