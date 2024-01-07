using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_project_API.Migrations
{
    public partial class UpdatedInterestColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InterestName",
                table: "Interests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "InterestDescription",
                table: "Interests",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Interests",
                newName: "InterestName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Interests",
                newName: "InterestDescription");
        }
    }
}
