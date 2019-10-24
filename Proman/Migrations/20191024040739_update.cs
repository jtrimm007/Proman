using Microsoft.EntityFrameworkCore.Migrations;

namespace Proman.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectRole_Project_ProjectId",
                table: "ProjectRole");

            migrationBuilder.DropIndex(
                name: "IX_ProjectRole_ProjectId",
                table: "ProjectRole");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_ProjectId",
                table: "Person",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Project_ProjectId",
                table: "Person",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Project_ProjectId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ProjectId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Person");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRole_ProjectId",
                table: "ProjectRole",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectRole_Project_ProjectId",
                table: "ProjectRole",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
