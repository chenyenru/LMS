using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseLMS.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_SchoolAssignment_SchoolAssignmentID",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Todos");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_SchoolAssignmentID",
                table: "Todos",
                newName: "IX_Todos_SchoolAssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_SchoolAssignment_SchoolAssignmentID",
                table: "Todos",
                column: "SchoolAssignmentID",
                principalTable: "SchoolAssignment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_SchoolAssignment_SchoolAssignmentID",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Todo");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_SchoolAssignmentID",
                table: "Todo",
                newName: "IX_Todo_SchoolAssignmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_SchoolAssignment_SchoolAssignmentID",
                table: "Todo",
                column: "SchoolAssignmentID",
                principalTable: "SchoolAssignment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
