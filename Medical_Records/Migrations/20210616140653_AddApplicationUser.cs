using Microsoft.EntityFrameworkCore.Migrations;

namespace Medical_Records.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CongenitalDesease",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentMedication",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrugAllergy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CongenitalDesease",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentMedication",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DrugAllergy",
                table: "AspNetUsers");
        }
    }
}
