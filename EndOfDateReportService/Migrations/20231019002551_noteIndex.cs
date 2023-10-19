using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EndOfDateReportService.Migrations
{
    public partial class noteIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotesAdjustments_LaneId_Date",
                table: "NotesAdjustments");

            migrationBuilder.CreateIndex(
                name: "IX_NotesAdjustments_LaneId_Date_BranchId",
                table: "NotesAdjustments",
                columns: new[] { "LaneId", "Date", "BranchId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NotesAdjustments_LaneId_Date_BranchId",
                table: "NotesAdjustments");

            migrationBuilder.CreateIndex(
                name: "IX_NotesAdjustments_LaneId_Date",
                table: "NotesAdjustments",
                columns: new[] { "LaneId", "Date" },
                unique: true);
        }
    }
}
