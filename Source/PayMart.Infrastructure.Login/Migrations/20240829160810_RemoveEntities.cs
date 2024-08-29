using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayMart.Infrastructure.Login.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tb_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tb_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Tb_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Tb_User",
                type: "datetime2",
                nullable: true);
        }
    }
}
