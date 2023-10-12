using System.ComponentModel.DataAnnotations;

namespace EndOfDateReportService.Domain
{
    public class NoteAdjustments
    {
        [Key]
        public int BranchId { get; set; }
        [Key]
        public int LaneId { get; set; }
        public DateTime Date { get; set; }  
        public string? Comments { get; set; }
        public double? CallAdjustments { get; set; }
    }
}
