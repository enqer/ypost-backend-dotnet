using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ypost_backend_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class InitUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPost",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 7, 17, 6, 20, 568, DateTimeKind.Utc).AddTicks(8099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 7, 16, 44, 15, 257, DateTimeKind.Utc).AddTicks(3673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 7, 17, 6, 20, 569, DateTimeKind.Utc).AddTicks(217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 7, 16, 44, 15, 257, DateTimeKind.Utc).AddTicks(7562));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinedOn",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 7, 16, 44, 15, 257, DateTimeKind.Utc).AddTicks(3673),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 7, 17, 6, 20, 568, DateTimeKind.Utc).AddTicks(8099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 3, 7, 16, 44, 15, 257, DateTimeKind.Utc).AddTicks(7562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 3, 7, 17, 6, 20, 569, DateTimeKind.Utc).AddTicks(217));

            migrationBuilder.AddColumn<bool>(
                name: "IsPost",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
