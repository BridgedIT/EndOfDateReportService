namespace EndOfDateReportService.Models.Out;

public class LaneModelOut
{
    public int LaneId { get; set; }
    public int BranchId { get; set; }
    public string? Note { get; set; }
    public double? Adjustment { get; set; }
    public ICollection<PaymentMethodModelOut> PaymentMethods { get; set; }
}