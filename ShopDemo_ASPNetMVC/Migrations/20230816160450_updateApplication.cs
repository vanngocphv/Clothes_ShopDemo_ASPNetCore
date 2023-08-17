using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopDemo_ASPNetMVC.Migrations
{
    public partial class updateApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_ClotheCategories_ClotheCategoryId",
                table: "Clothes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMessages",
                table: "ContactMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothes",
                table: "Clothes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClotheCategories",
                table: "ClotheCategories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "ContactMessages",
                newName: "ContactMessage");

            migrationBuilder.RenameTable(
                name: "Clothes",
                newName: "Clothe");

            migrationBuilder.RenameTable(
                name: "ClotheCategories",
                newName: "ClotheCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Clothes_ClotheCategoryId",
                table: "Clothe",
                newName: "IX_Clothe_ClotheCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMessage",
                table: "ContactMessage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothe",
                table: "Clothe",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClotheCategory",
                table: "ClotheCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_ClotheCategory_ClotheCategoryId",
                table: "Clothe",
                column: "ClotheCategoryId",
                principalTable: "ClotheCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_ClotheCategory_ClotheCategoryId",
                table: "Clothe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMessage",
                table: "ContactMessage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClotheCategory",
                table: "ClotheCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clothe",
                table: "Clothe");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "ContactMessage",
                newName: "ContactMessages");

            migrationBuilder.RenameTable(
                name: "ClotheCategory",
                newName: "ClotheCategories");

            migrationBuilder.RenameTable(
                name: "Clothe",
                newName: "Clothes");

            migrationBuilder.RenameIndex(
                name: "IX_Clothe_ClotheCategoryId",
                table: "Clothes",
                newName: "IX_Clothes_ClotheCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMessages",
                table: "ContactMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClotheCategories",
                table: "ClotheCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clothes",
                table: "Clothes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_ClotheCategories_ClotheCategoryId",
                table: "Clothes",
                column: "ClotheCategoryId",
                principalTable: "ClotheCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
