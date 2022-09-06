using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFDataAccessLibrary.Migrations
{
    public partial class create_relationship_address_person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_address_PersonId",
                table: "address",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_person_PersonId",
                table: "address",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_person_PersonId",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_PersonId",
                table: "address");
        }
    }
}
