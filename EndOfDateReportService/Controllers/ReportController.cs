using AutoMapper;
using EndOfDateReportService.Domain;
using EndOfDateReportService.Models.Out;
using EndOfDateReportService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EndOfDateReportService.Controllers;
[ApiController]
[Route("api/reports")]
public class ReportController:ControllerBase
{
    private readonly BranchService _branchService;
    private readonly IMapper _mapper;
    public ReportController(BranchService branchService, IMapper mapper)
    {
        _branchService = branchService;
        _mapper = mapper;
    }

    [HttpGet()]
    public async Task<IActionResult> GetReport(DateTime startDate, DateTime endDate)
    {
        var result = await _branchService.GenerateReport(startDate, endDate);
        var response = await _branchService.AddFees(result, startDate);
         return Ok(response);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateReport([FromQuery] DateTime updateDate, [FromBody] IEnumerable<Branch> branches)
    {
        await _branchService.UpdatePaymentMethods(branches, updateDate);
        return Ok();
    }

    [HttpGet("get-summary")]
    public async Task<IActionResult> CreateSummary([FromQuery] DateTime date, [FromQuery] int branchId)
    {
        byte[] pdf = await _branchService.PdfGenerator(date, branchId);

        return File(pdf, "application/pdf", date + " summary.pdf");
    }

    [HttpGet("get")]
    public async Task<IActionResult> CreateSummary([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        var file = await _branchService.ExcelGenerator(fromDate, toDate);
        return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sample.xlsx");
    }
}

