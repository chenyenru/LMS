using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseLMS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimeBlock_Course_CourseID1",
                table: "CourseTimeBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimeBlock",
                table: "CourseTimeBlock");

            migrationBuilder.DropIndex(
                name: "IX_CourseTimeBlock_CourseID1",
                table: "CourseTimeBlock");

            migrationBuilder.RenameColumn(
                name: "CourseID1",
                table: "CourseTimeBlock",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseTimeBlock",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "CourseTimeBlock",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimeBlock",
                table: "CourseTimeBlock",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeBlock_CourseID",
                table: "CourseTimeBlock",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimeBlock_Course_CourseID",
                table: "CourseTimeBlock",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTimeBlock_Course_CourseID",
                table: "CourseTimeBlock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTimeBlock",
                table: "CourseTimeBlock");

            migrationBuilder.DropIndex(
                name: "IX_CourseTimeBlock_CourseID",
                table: "CourseTimeBlock");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CourseTimeBlock",
                newName: "CourseID1");

            migrationBuilder.AlterColumn<int>(
                name: "CourseID",
                table: "CourseTimeBlock",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseID1",
                table: "CourseTimeBlock",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTimeBlock",
                table: "CourseTimeBlock",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTimeBlock_CourseID1",
                table: "CourseTimeBlock",
                column: "CourseID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTimeBlock_Course_CourseID1",
                table: "CourseTimeBlock",
                column: "CourseID1",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
