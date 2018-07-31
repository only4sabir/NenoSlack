using Microsoft.EntityFrameworkCore.Migrations;

namespace NenoSlack.Migrations
{
    public partial class InitialCreate1012123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "UserDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "UserDetail");
        }
    }
}
