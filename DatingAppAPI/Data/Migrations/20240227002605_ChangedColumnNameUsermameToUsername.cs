using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingAppAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumnNameUsermameToUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderUsermame",
                table: "Messages",
                newName: "SenderUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderUsername",
                table: "Messages",
                newName: "SenderUsermame");
        }
    }
}
