using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayMart.Infrastructure.Login.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Tb_User");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Tb_User",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tb_User",
                newName: "UpdatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tb_User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tb_User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Tb_User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Tb_User");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Tb_User");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Tb_User",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Tb_User",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Enabled",
                table: "Tb_User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
