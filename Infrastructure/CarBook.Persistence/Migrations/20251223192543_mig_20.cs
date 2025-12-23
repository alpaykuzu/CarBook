using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DropOffDescription",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "PickUpDescription",
                table: "Rentals",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Rentals",
                newName: "PickUpDescription");

            migrationBuilder.AddColumn<string>(
                name: "DropOffDescription",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
