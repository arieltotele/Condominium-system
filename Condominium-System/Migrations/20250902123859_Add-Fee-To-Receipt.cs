using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Condominium_System.Migrations
{
    /// <inheritdoc />
    public partial class AddFeeToReceipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LateFee",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "LateFeeApplied",
                table: "Receipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LateFeeAppliedDate",
                table: "Receipts",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LateFee",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "LateFeeApplied",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "LateFeeAppliedDate",
                table: "Receipts");
        }
    }
}
