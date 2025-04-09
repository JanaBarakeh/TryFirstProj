using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryFirstProj.Migrations
{
    /// <inheritdoc />
    public partial class catogreyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "catogreyId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "catogreyId",
                table: "Items");
        }
    }
}
