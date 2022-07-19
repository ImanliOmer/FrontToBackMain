using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class slidercontentscolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SliderContents",
                columns: new[] { "Id", "Desc", "ImgUrl", "Title" },
                values: new object[] { 1, "Where flowers are our inspiration to create lasting memories. Whatever the occasion, our flowers will   make it special cursus a sit amet mauris.", "h2-sign-img.png", "<h1>Send <span>flowers</span> lorem like</h1>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SliderContents",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
