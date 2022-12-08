using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateEntityTables4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WeddingPlaces",
                newName: "WeddingPlaceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.AddColumn<int>(
                name: "WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WeddingPlaceImage",
                columns: table => new
                {
                    PlacePhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingPlaceImage", x => x.PlacePhotoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeddingPlaces_WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces",
                column: "WeddingPlaceImagePlacePhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WeddingPlaceId",
                table: "Orders",
                column: "WeddingPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_WeddingPlaces_WeddingPlaceId",
                table: "Orders",
                column: "WeddingPlaceId",
                principalTable: "WeddingPlaces",
                principalColumn: "WeddingPlaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeddingPlaces_WeddingPlaceImage_WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces",
                column: "WeddingPlaceImagePlacePhotoId",
                principalTable: "WeddingPlaceImage",
                principalColumn: "PlacePhotoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_WeddingPlaces_WeddingPlaceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_WeddingPlaces_WeddingPlaceImage_WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces");

            migrationBuilder.DropTable(
                name: "WeddingPlaceImage");

            migrationBuilder.DropIndex(
                name: "IX_WeddingPlaces_WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Orders_WeddingPlaceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WeddingPlaceImagePlacePhotoId",
                table: "WeddingPlaces");

            migrationBuilder.RenameColumn(
                name: "WeddingPlaceId",
                table: "WeddingPlaces",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");
        }
    }
}
