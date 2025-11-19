using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp_backend.Migrations
{
    /// <inheritdoc />
    public partial class emailField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "Email",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "Email",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "Email",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "Email",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "Email",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
