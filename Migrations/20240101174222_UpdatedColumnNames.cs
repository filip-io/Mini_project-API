using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_project_API.Migrations
{
    public partial class UpdatedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestInterestLink_InterestLinks_InterestLinksInterestLinkId",
                table: "InterestInterestLink");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestInterestLink_Interests_InterestsInterestId",
                table: "InterestInterestLink");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_InterestLinks_InterestLinksInterestLinkId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsPersonId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_Interests_InterestsInterestId",
                table: "InterestPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_Persons_PersonsPersonId",
                table: "InterestPerson");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InterestId",
                table: "Interests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonsPersonId",
                table: "InterestPerson",
                newName: "PersonsId");

            migrationBuilder.RenameColumn(
                name: "InterestsInterestId",
                table: "InterestPerson",
                newName: "InterestsId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestPerson_PersonsPersonId",
                table: "InterestPerson",
                newName: "IX_InterestPerson_PersonsId");

            migrationBuilder.RenameColumn(
                name: "InterestLinkId",
                table: "InterestLinks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonsPersonId",
                table: "InterestLinkPerson",
                newName: "PersonsId");

            migrationBuilder.RenameColumn(
                name: "InterestLinksInterestLinkId",
                table: "InterestLinkPerson",
                newName: "InterestLinksId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLinkPerson_PersonsPersonId",
                table: "InterestLinkPerson",
                newName: "IX_InterestLinkPerson_PersonsId");

            migrationBuilder.RenameColumn(
                name: "InterestsInterestId",
                table: "InterestInterestLink",
                newName: "InterestsId");

            migrationBuilder.RenameColumn(
                name: "InterestLinksInterestLinkId",
                table: "InterestInterestLink",
                newName: "InterestLinksId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestInterestLink_InterestsInterestId",
                table: "InterestInterestLink",
                newName: "IX_InterestInterestLink_InterestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestInterestLink_InterestLinks_InterestLinksId",
                table: "InterestInterestLink",
                column: "InterestLinksId",
                principalTable: "InterestLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestInterestLink_Interests_InterestsId",
                table: "InterestInterestLink",
                column: "InterestsId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_InterestLinks_InterestLinksId",
                table: "InterestLinkPerson",
                column: "InterestLinksId",
                principalTable: "InterestLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsId",
                table: "InterestLinkPerson",
                column: "PersonsId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPerson_Interests_InterestsId",
                table: "InterestPerson",
                column: "InterestsId",
                principalTable: "Interests",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestInterestLink_InterestLinks_InterestLinksId",
                table: "InterestInterestLink");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestInterestLink_Interests_InterestsId",
                table: "InterestInterestLink");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_InterestLinks_InterestLinksId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsId",
                table: "InterestLinkPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_Interests_InterestsId",
                table: "InterestPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestPerson_Persons_PersonsId",
                table: "InterestPerson");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persons",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interests",
                newName: "InterestId");

            migrationBuilder.RenameColumn(
                name: "PersonsId",
                table: "InterestPerson",
                newName: "PersonsPersonId");

            migrationBuilder.RenameColumn(
                name: "InterestsId",
                table: "InterestPerson",
                newName: "InterestsInterestId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestPerson_PersonsId",
                table: "InterestPerson",
                newName: "IX_InterestPerson_PersonsPersonId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InterestLinks",
                newName: "InterestLinkId");

            migrationBuilder.RenameColumn(
                name: "PersonsId",
                table: "InterestLinkPerson",
                newName: "PersonsPersonId");

            migrationBuilder.RenameColumn(
                name: "InterestLinksId",
                table: "InterestLinkPerson",
                newName: "InterestLinksInterestLinkId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLinkPerson_PersonsId",
                table: "InterestLinkPerson",
                newName: "IX_InterestLinkPerson_PersonsPersonId");

            migrationBuilder.RenameColumn(
                name: "InterestsId",
                table: "InterestInterestLink",
                newName: "InterestsInterestId");

            migrationBuilder.RenameColumn(
                name: "InterestLinksId",
                table: "InterestInterestLink",
                newName: "InterestLinksInterestLinkId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestInterestLink_InterestsId",
                table: "InterestInterestLink",
                newName: "IX_InterestInterestLink_InterestsInterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestInterestLink_InterestLinks_InterestLinksInterestLinkId",
                table: "InterestInterestLink",
                column: "InterestLinksInterestLinkId",
                principalTable: "InterestLinks",
                principalColumn: "InterestLinkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestInterestLink_Interests_InterestsInterestId",
                table: "InterestInterestLink",
                column: "InterestsInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_InterestLinks_InterestLinksInterestLinkId",
                table: "InterestLinkPerson",
                column: "InterestLinksInterestLinkId",
                principalTable: "InterestLinks",
                principalColumn: "InterestLinkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinkPerson_Persons_PersonsPersonId",
                table: "InterestLinkPerson",
                column: "PersonsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPerson_Interests_InterestsInterestId",
                table: "InterestPerson",
                column: "InterestsInterestId",
                principalTable: "Interests",
                principalColumn: "InterestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPerson_Persons_PersonsPersonId",
                table: "InterestPerson",
                column: "PersonsPersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
