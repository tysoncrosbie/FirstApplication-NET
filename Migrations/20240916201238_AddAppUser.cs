using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "3510d9ae-d3b1-4408-b1aa-9d0c9c8d9c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "d47dd3bc-e45e-4024-805d-ba6e5e8158e0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "21fa87a1-a644-4d41-a10d-561343ea1cd4", null, "User", "USER" },
                    { "7541a1c6-6c34-4f99-b391-81cb2cdbf729", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "21fa87a1-a644-4d41-a10d-561343ea1cd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "7541a1c6-6c34-4f99-b391-81cb2cdbf729");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "3510d9ae-d3b1-4408-b1aa-9d0c9c8d9c61", null, "User", "USER" },
                    { "d47dd3bc-e45e-4024-805d-ba6e5e8158e0", null, "Admin", "ADMIN" }
                });
        }
    }
}
