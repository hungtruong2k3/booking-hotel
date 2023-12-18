using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Hotel.Migrations
{
    public partial class LevelProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LevelHotel",
                columns: table => new
                {
                    LeverID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelHotel", x => x.LeverID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeverID = table.Column<int>(type: "int", nullable: false),
                    levelHotelLeverID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_LevelHotel_levelHotelLeverID",
                        column: x => x.levelHotelLeverID,
                        principalTable: "LevelHotel",
                        principalColumn: "LeverID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_levelHotelLeverID",
                table: "Product",
                column: "levelHotelLeverID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "LevelHotel");
        }
    }
}
