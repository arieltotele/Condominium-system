using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Condominium_System.Migrations
{
    /// <inheritdoc />
    public partial class StatusFieldAddedInReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Receipts");
        }
    }
}
