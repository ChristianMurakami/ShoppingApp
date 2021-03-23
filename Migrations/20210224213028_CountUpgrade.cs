using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Migrations
{
    public partial class CountUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemImage",
                table: "ItemsNCounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "ItemsNCounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemImage",
                table: "ItemsNCounts");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "ItemsNCounts");
        }
    }
}
