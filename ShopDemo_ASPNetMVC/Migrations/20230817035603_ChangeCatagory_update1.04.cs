using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDemo_ASPNetMVC.Migrations
{
    public partial class ChangeCatagory_update104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_ClotheCategory_ClotheCategoryId",
                table: "Clothe");

            migrationBuilder.DropIndex(
                name: "IX_Clothe_ClotheCategoryId",
                table: "Clothe");

            migrationBuilder.DropColumn(
                name: "ClotheCategoryId",
                table: "Clothe");

            migrationBuilder.AddColumn<int>(
                name: "ClotheCategory",
                table: "Clothe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClotheCategory",
                table: "Clothe");

            migrationBuilder.AddColumn<int>(
                name: "ClotheCategoryId",
                table: "Clothe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_ClotheCategoryId",
                table: "Clothe",
                column: "ClotheCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_ClotheCategory_ClotheCategoryId",
                table: "Clothe",
                column: "ClotheCategoryId",
                principalTable: "ClotheCategory",
                principalColumn: "Id");
        }
    }
}
