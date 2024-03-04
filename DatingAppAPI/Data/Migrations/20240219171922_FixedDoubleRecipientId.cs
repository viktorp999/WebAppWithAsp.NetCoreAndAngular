using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatingAppAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedDoubleRecipientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecepientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecepientId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "RecepientId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "RecepientUsername",
                table: "Messages",
                newName: "RecipientUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages",
                column: "RecipientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_RecipientId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "RecipientUsername",
                table: "Messages",
                newName: "RecepientUsername");

            migrationBuilder.AddColumn<Guid>(
                name: "RecepientId",
                table: "Messages",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecepientId",
                table: "Messages",
                column: "RecepientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_RecepientId",
                table: "Messages",
                column: "RecepientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
