using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Brands",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Discoverable",
                table: "Brands",
                newName: "discoverable");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Brands",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brands",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TimeZone",
                table: "Brands",
                newName: "time_zone");

            migrationBuilder.RenameColumn(
                name: "SortingOrder",
                table: "Brands",
                newName: "sorting_order");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Brands",
                newName: "launch_date");

            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Brands",
                newName: "cover_image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "Brands",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Brands",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "discoverable",
                table: "Brands",
                newName: "Discoverable");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Brands",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Brands",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "time_zone",
                table: "Brands",
                newName: "TimeZone");

            migrationBuilder.RenameColumn(
                name: "sorting_order",
                table: "Brands",
                newName: "SortingOrder");

            migrationBuilder.RenameColumn(
                name: "launch_date",
                table: "Brands",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "cover_image",
                table: "Brands",
                newName: "CoverImage");
        }
    }
}
