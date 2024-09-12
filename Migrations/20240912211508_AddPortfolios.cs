using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfolios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "9eb80f42-d13b-4d3d-abf1-5122d2810c7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "e10bd38f-21af-49bd-9b64-e0723eb3cf40");

            migrationBuilder.CreateTable(
                name: "portfolios",
                columns: table => new
                {
                    app_user_id = table.Column<string>(type: "text", nullable: false),
                    stock_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_portfolios", x => new { x.app_user_id, x.stock_id });
                    table.ForeignKey(
                        name: "fk_portfolios_stocks_stock_id",
                        column: x => x.stock_id,
                        principalTable: "stocks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_portfolios_users_app_user_id",
                        column: x => x.app_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "1341a8f3-aa17-453c-a701-c1ee5547fb88", null, "Admin", "ADMIN" },
                    { "5a77f451-6d75-4cdd-b8cb-25a89a8f4028", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_portfolios_stock_id",
                table: "portfolios",
                column: "stock_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "1341a8f3-aa17-453c-a701-c1ee5547fb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "5a77f451-6d75-4cdd-b8cb-25a89a8f4028");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "9eb80f42-d13b-4d3d-abf1-5122d2810c7f", null, "User", "USER" },
                    { "e10bd38f-21af-49bd-9b64-e0723eb3cf40", null, "Admin", "ADMIN" }
                });
        }
    }
}
