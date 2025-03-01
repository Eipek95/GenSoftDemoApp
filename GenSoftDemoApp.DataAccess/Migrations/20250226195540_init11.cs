using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GenSoftDemoApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "DATETIME2(0)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2(0)");
        }
    }
}
