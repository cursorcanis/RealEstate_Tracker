using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateTracker.Migrations
{
    /// <inheritdoc />
    public partial class DatabaserebuildfromEstates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Estate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Estate");
        }
    }
}
