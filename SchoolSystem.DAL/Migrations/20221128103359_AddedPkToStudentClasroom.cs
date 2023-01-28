using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedPkToStudentClasroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "StudentClasrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentClasrooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb48d22b-5246-4c11-8dcc-70ecb259f655", null, "Teacher", "TEACHER" },
                    { "ddc4f462-40a0-4331-b111-2bd2c97430ab", null, "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb48d22b-5246-4c11-8dcc-70ecb259f655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc4f462-40a0-4331-b111-2bd2c97430ab");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StudentClasrooms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentClasrooms");
        }
    }
}
