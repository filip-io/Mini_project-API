using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_project_API.Migrations
{
    public partial class ChangedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_Persons_PersonsId",
                table: "InterestPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_People_PersonsId",
                table: "InterestLinkPerson",
                column: "PersonsId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPerson_People_PersonsId",
                table: "InterestPerson",
                column: "PersonsId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_People_PersonsId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_People_PersonsId",
                table: "InterestPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsId",
                table: "InterestLinkPerson",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPerson_Persons_PersonsId",
                table: "InterestPerson",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
