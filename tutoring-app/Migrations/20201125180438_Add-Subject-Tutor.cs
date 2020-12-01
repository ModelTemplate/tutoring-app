using Microsoft.EntityFrameworkCore.Migrations;

namespace tutoring_app.Migrations
{
    public partial class AddSubjectTutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Tutors",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SubjectID",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectID",
                table: "Schedules",
                column: "SubjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Subjects_SubjectID",
                table: "Schedules",
                column: "SubjectID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Subjects_SubjectID",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_SubjectID",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SubjectID",
                table: "Schedules");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Tutors",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
