using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutoring_app.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Students_StudentID",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Tutors_TutorID",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tutors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Subjects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "Schedules",
                newName: "TutorId");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Schedules",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Schedules",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TutorID",
                table: "Schedules",
                newName: "IX_Schedules_TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StudentID",
                table: "Schedules",
                newName: "IX_Schedules_StudentId");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Tutors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Tutors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Tutors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Tutors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Tutors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Tutors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Subjects",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Students",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Schedules",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TutorId",
                table: "Subjects",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedules",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Students_StudentId",
                table: "Schedules",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Subjects_SubjectId",
                table: "Schedules",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Tutors_TutorId",
                table: "Schedules",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Tutors_TutorId",
                table: "Subjects",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Students_StudentId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Subjects_SubjectId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Tutors_TutorId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Tutors_TutorId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TutorId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_SubjectId",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tutors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Subjects",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "Schedules",
                newName: "TutorID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Schedules",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Schedules",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_TutorId",
                table: "Schedules",
                newName: "IX_Schedules_TutorID");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_StudentId",
                table: "Schedules",
                newName: "IX_Schedules_StudentID");

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Tutors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Students_StudentID",
                table: "Schedules",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Tutors_TutorID",
                table: "Schedules",
                column: "TutorID",
                principalTable: "Tutors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
