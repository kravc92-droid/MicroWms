using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroWms.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StorageLocations_Code",
                table: "StorageLocations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SorterOutputs_Code",
                table: "SorterOutputs",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Article",
                table: "Products",
                column: "Article",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_Code",
                table: "Parcels",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_Code",
                table: "Boxes",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StorageLocations_Code",
                table: "StorageLocations");

            migrationBuilder.DropIndex(
                name: "IX_SorterOutputs_Code",
                table: "SorterOutputs");

            migrationBuilder.DropIndex(
                name: "IX_Products_Article",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_Code",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Number",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Boxes_Code",
                table: "Boxes");
        }
    }
}
