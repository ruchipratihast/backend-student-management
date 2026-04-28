using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentMgmtSystem.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "StudentModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentModel_CourseId",
                table: "StudentModel",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentModel_CourseModel_CourseId",
                table: "StudentModel",
                column: "CourseId",
                principalTable: "CourseModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentModel_CourseModel_CourseId",
                table: "StudentModel");

            migrationBuilder.DropIndex(
                name: "IX_StudentModel_CourseId",
                table: "StudentModel");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentModel");
        }
    }
}
