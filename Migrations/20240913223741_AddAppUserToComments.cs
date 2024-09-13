using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUserToComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "1341a8f3-aa17-453c-a701-c1ee5547fb88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "5a77f451-6d75-4cdd-b8cb-25a89a8f4028");

            migrationBuilder.AddColumn<string>(
                name: "app_user_id",
                table: "comments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "3510d9ae-d3b1-4408-b1aa-9d0c9c8d9c61", null, "User", "USER" },
                    { "d47dd3bc-e45e-4024-805d-ba6e5e8158e0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_comments_app_user_id",
                table: "comments",
                column: "app_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_app_user_id",
                table: "comments",
                column: "app_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_users_app_user_id",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "ix_comments_app_user_id",
                table: "comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "3510d9ae-d3b1-4408-b1aa-9d0c9c8d9c61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "id",
                keyValue: "d47dd3bc-e45e-4024-805d-ba6e5e8158e0");

            migrationBuilder.DropColumn(
                name: "app_user_id",
                table: "comments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "1341a8f3-aa17-453c-a701-c1ee5547fb88", null, "Admin", "ADMIN" },
                    { "5a77f451-6d75-4cdd-b8cb-25a89a8f4028", null, "User", "USER" }
                });
        }
    }
}
