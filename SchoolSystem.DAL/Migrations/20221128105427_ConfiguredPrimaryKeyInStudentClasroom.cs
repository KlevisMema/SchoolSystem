using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredPrimaryKeyInStudentClasroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904d25a7-4b5e-4f7a-ae95-19344f2168bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f2f880-8d34-4b6e-86bd-ca2ea3074cdf");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentClasrooms",
                table: "StudentClasrooms",
                columns: new[] { "StudentId", "ClasroomId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "904d25a7-4b5e-4f7a-ae95-19344f2168bd", null, "Student", "Student" },
                    { "98f2f880-8d34-4b6e-86bd-ca2ea3074cdf", null, "Teacher", "TEACHER" }
                });
        }
    }
}
