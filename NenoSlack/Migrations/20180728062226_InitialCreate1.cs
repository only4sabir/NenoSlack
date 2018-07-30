using Microsoft.EntityFrameworkCore.Migrations;

namespace NenoSlack.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatDetails_userDetails_UserId",
                table: "chatDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userDetails",
                table: "userDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_chatDetails",
                table: "chatDetails");

            migrationBuilder.RenameTable(
                name: "userDetails",
                newName: "UserDetail");

            migrationBuilder.RenameTable(
                name: "chatDetails",
                newName: "ChatDetail");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserDetail",
                newName: "UserName");

            migrationBuilder.RenameIndex(
                name: "IX_chatDetails_UserId",
                table: "ChatDetail",
                newName: "IX_ChatDetail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatDetail",
                table: "ChatDetail",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatDetail_UserDetail_UserId",
                table: "ChatDetail",
                column: "UserId",
                principalTable: "UserDetail",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatDetail_UserDetail_UserId",
                table: "ChatDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetail",
                table: "UserDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatDetail",
                table: "ChatDetail");

            migrationBuilder.RenameTable(
                name: "UserDetail",
                newName: "userDetails");

            migrationBuilder.RenameTable(
                name: "ChatDetail",
                newName: "chatDetails");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "userDetails",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_ChatDetail_UserId",
                table: "chatDetails",
                newName: "IX_chatDetails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDetails",
                table: "userDetails",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_chatDetails",
                table: "chatDetails",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatDetails_userDetails_UserId",
                table: "chatDetails",
                column: "UserId",
                principalTable: "userDetails",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
