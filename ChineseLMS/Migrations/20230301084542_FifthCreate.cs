using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseLMS.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ResourceFile_SchoolAssignmentID",
                table: "ResourceFile",
                column: "SchoolAssignmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_ResourceFile_SchoolAssignment_SchoolAssignmentID",
                table: "ResourceFile",
                column: "SchoolAssignmentID",
                principalTable: "SchoolAssignment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResourceFile_SchoolAssignment_SchoolAssignmentID",
                table: "ResourceFile");

            migrationBuilder.DropIndex(
                name: "IX_ResourceFile_SchoolAssignmentID",
                table: "ResourceFile");
        }
    }
}
