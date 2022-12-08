using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateEntityTables3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "placePhotos",
                table: "WeddingPlaces");

            migrationBuilder.RenameColumn(
                name: "isWeddingPlaceOwner",
                table: "Users",
                newName: "IsWeddingPlaceOwner");

            migrationBuilder.AddColumn<int>(
                name: "PlacePhotoId",
                table: "WeddingPlaces",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlacePhotoId",
                table: "WeddingPlaces");

            migrationBuilder.RenameColumn(
                name: "IsWeddingPlaceOwner",
                table: "Users",
                newName: "isWeddingPlaceOwner");

            migrationBuilder.AddColumn<string>(
                name: "placePhotos",
                table: "WeddingPlaces",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
