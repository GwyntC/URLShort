using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShort.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsAdmin_Add_Url_IsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_URLS_AspNetUsers_UserId",
                table: "URLS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_URLS",
                table: "URLS");

            migrationBuilder.RenameTable(
                name: "URLS",
                newName: "Urls");

            migrationBuilder.RenameIndex(
                name: "IX_URLS_UserId",
                table: "Urls",
                newName: "IX_Urls_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Urls",
                table: "Urls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Urls",
                table: "Urls");

            migrationBuilder.RenameTable(
                name: "Urls",
                newName: "URLS");

            migrationBuilder.RenameIndex(
                name: "IX_Urls_UserId",
                table: "URLS",
                newName: "IX_URLS_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_URLS",
                table: "URLS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_URLS_AspNetUsers_UserId",
                table: "URLS",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
