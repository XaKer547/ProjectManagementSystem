using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStage_ProjectStageMark_MarkId",
                table: "ProjectStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStage_Student_StudentId",
                table: "ProjectStage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageAnswer_Student_StudentId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropTable(
                name: "ProjectStageMark");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStage_MarkId",
                table: "ProjectStage");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStage_StudentId",
                table: "ProjectStage");

            migrationBuilder.DropColumn(
                name: "Files",
                table: "ProjectStageAnswer");

            migrationBuilder.DropColumn(
                name: "MarkId",
                table: "ProjectStage");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ProjectStage");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ProjectStageAnswer",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectStageAnswer_StudentId",
                table: "ProjectStageAnswer",
                newName: "IX_ProjectStageAnswer_AnswerId");

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "StudentProject",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "AdditionalResponseFilesId",
                table: "ProjectStageAnswer",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProjectStageId",
                table: "ProjectStageAnswer",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStageAnswer_AdditionalResponseFilesId",
                table: "ProjectStageAnswer",
                column: "AdditionalResponseFilesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStageAnswer_StudentProjectStageId",
                table: "ProjectStageAnswer",
                column: "StudentProjectStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageAnswer_PinnedFile_AdditionalResponseFilesId",
                table: "ProjectStageAnswer",
                column: "AdditionalResponseFilesId",
                principalTable: "PinnedFile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageAnswer_PinnedFile_AnswerId",
                table: "ProjectStageAnswer",
                column: "AnswerId",
                principalTable: "PinnedFile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageAnswer_StudentProjectStage_StudentProjectStageId",
                table: "ProjectStageAnswer",
                column: "StudentProjectStageId",
                principalTable: "StudentProject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageAnswer_PinnedFile_AdditionalResponseFilesId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageAnswer_PinnedFile_AnswerId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStageAnswer_StudentProjectStage_StudentProjectStageId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStageAnswer_AdditionalResponseFilesId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStageAnswer_StudentProjectStageId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentProject");

            migrationBuilder.DropColumn(
                name: "AdditionalResponseFilesId",
                table: "ProjectStageAnswer");

            migrationBuilder.DropColumn(
                name: "StudentProjectStageId",
                table: "ProjectStageAnswer");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "ProjectStageAnswer",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectStageAnswer_AnswerId",
                table: "ProjectStageAnswer",
                newName: "IX_ProjectStageAnswer_StudentId");

            migrationBuilder.AddColumn<string[]>(
                name: "Files",
                table: "ProjectStageAnswer",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "MarkId",
                table: "ProjectStage",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "ProjectStage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProjectStageMark",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    Mark = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStageMark", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_MarkId",
                table: "ProjectStage",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStage_StudentId",
                table: "ProjectStage",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStage_ProjectStageMark_MarkId",
                table: "ProjectStage",
                column: "MarkId",
                principalTable: "ProjectStageMark",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStage_Student_StudentId",
                table: "ProjectStage",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStageAnswer_Student_StudentId",
                table: "ProjectStageAnswer",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
