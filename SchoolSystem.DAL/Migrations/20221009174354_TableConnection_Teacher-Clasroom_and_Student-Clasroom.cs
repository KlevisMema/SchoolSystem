using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.DAL.Migrations
{
    public partial class TableConnection_TeacherClasroom_and_StudentClasroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clasrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clasrooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasrooms",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClasroomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasrooms", x => new { x.StudentId, x.ClasroomId });
                    table.ForeignKey(
                        name: "FK_StudentClasrooms_Clasrooms_ClasroomId",
                        column: x => x.ClasroomId,
                        principalTable: "Clasrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasrooms_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasrooms_TeacherId",
                table: "Clasrooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasrooms_ClasroomId",
                table: "StudentClasrooms",
                column: "ClasroomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClasrooms");

            migrationBuilder.DropTable(
                name: "Clasrooms");
        }
    }
}