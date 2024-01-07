using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_project_API.Migrations
{
    public partial class AdjustedInterestLinkClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestInterestLink");

            migrationBuilder.DropTable(
                name: "InterestLinkPerson");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "InterestLinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "InterestLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_InterestId",
                table: "InterestLinks",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_PersonId",
                table: "InterestLinks",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_Interests_InterestId",
                table: "InterestLinks",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_People_PersonId",
                table: "InterestLinks",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_Interests_InterestId",
                table: "InterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_People_PersonId",
                table: "InterestLinks");

            migrationBuilder.DropIndex(
                name: "IX_InterestLinks_InterestId",
                table: "InterestLinks");

            migrationBuilder.DropIndex(
                name: "IX_InterestLinks_PersonId",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "InterestLinks");

            migrationBuilder.CreateTable(
                name: "InterestInterestLink",
                columns: table => new
                {
                    InterestLinksId = table.Column<int>(type: "int", nullable: false),
                    InterestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestInterestLink", x => new { x.InterestLinksId, x.InterestsId });
                    table.ForeignKey(
                        name: "FK_InterestInterestLink_InterestLinks_InterestLinksId",
                        column: x => x.InterestLinksId,
                        principalTable: "InterestLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestInterestLink_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestLinkPerson",
                columns: table => new
                {
                    InterestLinksId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinkPerson", x => new { x.InterestLinksId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_InterestLinkPerson_InterestLinks_InterestLinksId",
                        column: x => x.InterestLinksId,
                        principalTable: "InterestLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLinkPerson_People_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestInterestLink_InterestsId",
                table: "InterestInterestLink",
                column: "InterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinkPerson_PersonsId",
                table: "InterestLinkPerson",
                column: "PersonsId");
        }
    }
}
