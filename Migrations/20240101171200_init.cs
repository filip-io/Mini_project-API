using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_project_API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestLinks",
                columns: table => new
                {
                    InterestLinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinks", x => x.InterestLinkId);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InterestDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "InterestInterestLink",
                columns: table => new
                {
                    InterestLinksInterestLinkId = table.Column<int>(type: "int", nullable: false),
                    InterestsInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestInterestLink", x => new { x.InterestLinksInterestLinkId, x.InterestsInterestId });
                    table.ForeignKey(
                        name: "FK_InterestInterestLink_InterestLinks_InterestLinksInterestLinkId",
                        column: x => x.InterestLinksInterestLinkId,
                        principalTable: "InterestLinks",
                        principalColumn: "InterestLinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestInterestLink_Interests_InterestsInterestId",
                        column: x => x.InterestsInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestLinkPerson",
                columns: table => new
                {
                    InterestLinksInterestLinkId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestLinkPerson", x => new { x.InterestLinksInterestLinkId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_InterestLinkPerson_InterestLinks_InterestLinksInterestLinkId",
                        column: x => x.InterestLinksInterestLinkId,
                        principalTable: "InterestLinks",
                        principalColumn: "InterestLinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestLinkPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestPerson",
                columns: table => new
                {
                    InterestsInterestId = table.Column<int>(type: "int", nullable: false),
                    PersonsPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPerson", x => new { x.InterestsInterestId, x.PersonsPersonId });
                    table.ForeignKey(
                        name: "FK_InterestPerson_Interests_InterestsInterestId",
                        column: x => x.InterestsInterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPerson_Persons_PersonsPersonId",
                        column: x => x.PersonsPersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InterestInterestLink_InterestsInterestId",
                table: "InterestInterestLink",
                column: "InterestsInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinkPerson_PersonsPersonId",
                table: "InterestLinkPerson",
                column: "PersonsPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_PersonsPersonId",
                table: "InterestPerson",
                column: "PersonsPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestInterestLink");

            migrationBuilder.DropTable(
                name: "InterestLinkPerson");

            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropTable(
                name: "InterestLinks");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
