using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EndOfDateReportService.Migrations
{
    public partial class noteChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NotesAdjustments_LaneId_Date",
                table: "NotesAdjustments",
                columns: new[] { "LaneId", "Date" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotesAdjustments_Lanes_LaneId",
                table: "NotesAdjustments",
                column: "LaneId",
                principalTable: "Lanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesAdjustments_Lanes_LaneId",
                table: "NotesAdjustments");

            migrationBuilder.DropIndex(
                name: "IX_NotesAdjustments_LaneId_Date",
                table: "NotesAdjustments");
        }
    }
}
