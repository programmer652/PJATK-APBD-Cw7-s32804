using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCore.Migrations
{
    /// <inheritdoc />
    public partial class changedTypesPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "PCs",
                type: "float(5)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PCs",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Weight",
                table: "PCs",
                type: "real",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "float(5)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PCs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
