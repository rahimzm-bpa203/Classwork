using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Classwork.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Describe",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "SignatureImageUrl",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title1",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "Title4",
                table: "Sliders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SignatureImageUrl",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title1",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title4",
                table: "Sliders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
