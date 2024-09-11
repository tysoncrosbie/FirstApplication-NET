using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class FixTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "stocks");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "stocks",
                newName: "Stocks");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");
        }
    }
}
