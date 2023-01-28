using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedGenerateIdFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb48d22b-5246-4c11-8dcc-70ecb259f655");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc4f462-40a0-4331-b111-2bd2c97430ab");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "904d25a7-4b5e-4f7a-ae95-19344f2168bd", null, "Student", "Student" },
                    { "98f2f880-8d34-4b6e-86bd-ca2ea3074cdf", null, "Teacher", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904d25a7-4b5e-4f7a-ae95-19344f2168bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98f2f880-8d34-4b6e-86bd-ca2ea3074cdf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cb48d22b-5246-4c11-8dcc-70ecb259f655", null, "Teacher", "TEACHER" },
                    { "ddc4f462-40a0-4331-b111-2bd2c97430ab", null, "Student", "Student" }
                });
        }
    }
}
