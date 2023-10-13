using System.ComponentModel.DataAnnotations;

namespace EndOfDateReportService.Domain
{
    public class NoteAdjustments
    {
        [Key]
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int LaneId { get; set; }
        public DateTime Date { get; set; }  
        public string? Comments { get; set; }
        public double? CallAdjustments { get; set; }
    }
}
