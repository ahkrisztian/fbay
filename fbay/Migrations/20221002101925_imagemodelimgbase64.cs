using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fbay.Migrations
{
    public partial class imagemodelimgbase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressToTake_AdvertisementId",
                table: "AddressToTake");

            migrationBuilder.AddColumn<string>(
                name: "base64data",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressToTake_AdvertisementId",
                table: "AddressToTake",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AddressToTake_AdvertisementId",
                table: "AddressToTake");

            migrationBuilder.DropColumn(
                name: "base64data",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_AddressToTake_AdvertisementId",
                table: "AddressToTake",
                column: "AdvertisementId",
                unique: true);
        }
    }
}
