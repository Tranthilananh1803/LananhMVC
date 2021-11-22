using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreDemo.Migrations
{
    public partial class Create_Table_Giaoviens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GiaovienID",
                table: "LopHocs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Giaoviens",
                columns: table => new
                {
                    GiaovienID = table.Column<string>(type: "TEXT", nullable: false),
                    Tengiaovien = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giaoviens", x => x.GiaovienID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LopHocs_GiaovienID",
                table: "LopHocs",
                column: "GiaovienID");

            migrationBuilder.AddForeignKey(
                name: "FK_LopHocs_Giaoviens_GiaovienID",
                table: "LopHocs",
                column: "GiaovienID",
                principalTable: "Giaoviens",
                principalColumn: "GiaovienID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LopHocs_Giaoviens_GiaovienID",
                table: "LopHocs");

            migrationBuilder.DropTable(
                name: "Giaoviens");

            migrationBuilder.DropIndex(
                name: "IX_LopHocs_GiaovienID",
                table: "LopHocs");

            migrationBuilder.DropColumn(
                name: "GiaovienID",
                table: "LopHocs");
        }
    }
}
