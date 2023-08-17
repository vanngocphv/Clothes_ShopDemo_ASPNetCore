using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDemo_ASPNetMVC.Migrations
{
    public partial class UpdateDescriptionAndCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Clothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Clothes");
        }
    }
}
