using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameSetWebApi.Migrations
{
    /// <inheritdoc />
    public partial class personMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList");

            migrationBuilder.RenameTable(
                name: "PersonList",
                newName: "person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_person",
                table: "person",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                table: "person");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "PersonList");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList",
                column: "Id");
        }
    }
}
