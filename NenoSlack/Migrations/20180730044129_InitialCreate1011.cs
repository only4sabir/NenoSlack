using Microsoft.EntityFrameworkCore.Migrations;

namespace NenoSlack.Migrations
{
    public partial class InitialCreate1011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToUserId",
                table: "ChatDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "ChatDetail",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "ChatDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ToUserId",
                table: "ChatDetail",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
