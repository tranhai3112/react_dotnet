using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class Create_database_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "person");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "person",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "person",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "ntext", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_address_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_PersonId",
                table: "address",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "person");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "person",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMoney",
                table: "person",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
