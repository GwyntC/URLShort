using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShort.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsAdmin_Add_Url_IsRemoved_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Urls",
                newName: "IsRemoved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemoved",
                table: "Urls",
                newName: "IsActive");
        }
    }
}
