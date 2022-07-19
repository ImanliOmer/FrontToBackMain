using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Positation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "AuthorName", "Facebook", "ImageUrl", "Linkedn" },
                values: new object[] { 5, "Aqil", "Cj0KCQjwtvqVBhCVARIsAFUxcRv7PtwND0mb_zQZOHEyCwzR8nce3lB8LQyvcAf8uu_Cb6agQSJCTJgaAkJZEALw_wcB", null, "https://www.linkexdin.com/" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum", "Popular" },
                    { 2, "Lorem ipsum", "Winter" },
                    { 3, "Lorem ipsum", "Exotic" },
                    { 4, "Lorem ipsum", "Varius" },
                    { 5, "Lorem ipsum", "Venor" }
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "ImgUrl" },
                values: new object[,]
                {
                    { 1, "h3-slider-background.jpg" },
                    { 2, "h3-slider-background-2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 0, "shop-13-img.jpg", "Product1", 60 },
                    { 2, 2, 0, "shop-12-img.jpg", "Product2", 65 },
                    { 3, 3, 0, "shop-11-img.jpg", "Product3", 70 },
                    { 6, 3, 0, "shop-11-img.jpg", "Product6", 90 },
                    { 4, 4, 0, "shop-13-img.jpg", "Product4", 80 },
                    { 5, 5, 0, "shop-8-img.jpg", "Product5", 90 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experts");

            migrationBuilder.DeleteData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sliders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
