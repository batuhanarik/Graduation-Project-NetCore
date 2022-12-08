using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateEntityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WeddingPlaceId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeddingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateCode = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceType = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<short>(type: "smallint", nullable: false),
                    PriceFirst = table.Column<double>(type: "float", nullable: false),
                    PriceLast = table.Column<double>(type: "float", nullable: false),
                    Discount_1 = table.Column<short>(type: "smallint", nullable: false),
                    Discount_2 = table.Column<short>(type: "smallint", nullable: false),
                    Discount_3 = table.Column<short>(type: "smallint", nullable: false),
                    PlaceOwnerId = table.Column<int>(type: "int", nullable: false),
                    placePhotos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isReserved = table.Column<bool>(type: "bit", nullable: false),
                    isFoodIncluded = table.Column<bool>(type: "bit", nullable: false),
                    isAlcoholIncluded = table.Column<bool>(type: "bit", nullable: false),
                    PlaceStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeddingPlaces_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeddingPlaces_CategoryId",
                table: "WeddingPlaces",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "WeddingPlaces");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
