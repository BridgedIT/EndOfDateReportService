using EndOfDateReportService.Domain;
using Microsoft.EntityFrameworkCore;

namespace EndOfDateReportService.DataAccess;

public class Repository
{
    private readonly ReportContext context;
    public Repository(ReportContext reportContent)
    {
        context = reportContent;
    }



    public async Task<IEnumerable<Branch>> Get(DateTime reportDate)
    {
        var branches = await context.Branches
        .Include(branch => branch.Lanes)
            .ThenInclude(lane => lane.NoteAdjustments.Where(n => n.Date == reportDate))
                .Include(branch => branch.Lanes)
                    .ThenInclude(lane => lane.PaymentMethods.Where(pm => pm.ReportDate == reportDate))
        .ToListAsync();

        foreach (var branch in branches)
        {
            foreach (var lane in branch.Lanes)
            {
                var relevantNoteAdjustment = context.NotesAdjustments.FirstOrDefault(x => x.BranchId == lane.BranchId && x.LaneId == lane.LaneId
                && x.Date == reportDate);

                if (relevantNoteAdjustment != null)
                {
                    lane.Note = relevantNoteAdjustment.Comments;
                    lane.Adjustment = relevantNoteAdjustment.CallAdjustments;
                }
            }
        }

        return branches;
    }

    public async Task CreatePaymentMethodReport(PaymentMethod paymentMethod)
    {
       var id = await context.PaymentMethods.OrderByDescending(e => e.Id)
                                   .Select(e => e.Id)
                                   .FirstOrDefaultAsync();   
        paymentMethod.Id = id + 1;
        await context.PaymentMethods.AddAsync(paymentMethod);
        await context.SaveChangesAsync();

    }

    public async Task<Lane> CreateLane(Lane entity)
    {
        var lane = await  context.Lanes.AddAsync(entity);
        await context.SaveChangesAsync();
        return lane.Entity;
    }

    public async Task<Lane> GetLaneByBranchId(int laneId, int branchId)
    {
        return await context.Lanes.FirstOrDefaultAsync(x => x.LaneId == laneId && x.BranchId == branchId);
    }

    public async Task<bool> TryGetReport(DateTime reportDate)
    {
        return await context.PaymentMethods.AnyAsync(x => x.ReportDate == new DateTime(reportDate.Year, reportDate.Month,
            reportDate.Day, reportDate.Hour, reportDate.Minute, reportDate.Second, DateTimeKind.Utc));
    }

    public async Task<PaymentMethod> UpdatePaymentMethod(PaymentMethod paymentMethod)
    {
        try
        {
            var pm = context.PaymentMethods.Update(paymentMethod);
            await context.SaveChangesAsync();
            return pm.Entity;
        }catch (Exception ex)
        {
            var e =ex.Message;
            return paymentMethod;
        }
    }

    public async Task CreateNoteAdjustments(NoteAdjustments noteAdjustments)
    {
        var id = await context.NotesAdjustments.OrderByDescending(e => e.Id)
                                    .Select(e => e.Id)
                                    .FirstOrDefaultAsync();
        noteAdjustments.Id = id + 1;
        await context.NotesAdjustments.AddAsync(noteAdjustments);
        await context.SaveChangesAsync();
    }

    public async Task<NoteAdjustments> UpdateNoteAdjustments(NoteAdjustments noteAdjustments)
    {
        try
        {
            var na = context.NotesAdjustments.Update(noteAdjustments);
            await context.SaveChangesAsync();
            return na.Entity;
        }
        catch (Exception ex)
        {
            var e = ex.Message;
            return noteAdjustments;
        }
    }
}