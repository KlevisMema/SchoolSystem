using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPrimaryKeyFromStudentClasroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClasrooms_StudentId",
                table: "StudentClasrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b5e82f6-b243-48b4-a680-dc6d55bf1249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4269868a-8dc3-4d12-b949-d074662befe9");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentClasrooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms",
                columns: new[] { "StudentId", "ClasroomId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0959abb2-f29b-4eb1-bd66-3c4d5c16959c", null, "Teacher", "TEACHER" },
                    { "eace406f-41ed-4112-879d-7d79542895cb", null, "Student", "Student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0959abb2-f29b-4eb1-bd66-3c4d5c16959c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eace406f-41ed-4112-879d-7d79542895cb");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StudentClasrooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b5e82f6-b243-48b4-a680-dc6d55bf1249", null, "Student", "Student" },
                    { "4269868a-8dc3-4d12-b949-d074662befe9", null, "Teacher", "TEACHER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasrooms_StudentId",
                table: "StudentClasrooms",
                column: "StudentId");
        }
    }
}
