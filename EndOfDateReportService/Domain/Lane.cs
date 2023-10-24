using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EndOfDateReportService.Domain;

public class Lane
{
    [Key]
    public int Id { get; set; }
    public int LaneId { get; set; }
    public int BranchId { get; set; }
    [JsonIgnore]
    [BindNever]
    public Branch? Branch { get; set; }
    public ICollection<PaymentMethod> PaymentMethods { get; set; }

    [JsonIgnore]
    [BindNever]
    public virtual ICollection<NoteAdjustments>? NoteAdjustments { get; set; }

    [NotMapped]
    public string? Note { get; set; }
    [NotMapped]
    public double? Adjustment { get; set; }
}