using Api.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[Controller]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
  private readonly IReportService _service;

  public ReportController(IReportService service) => _service = service;

  [HttpGet("general")]
  public async Task<IActionResult> GetGeneral() => Ok(await _service.GetGeneralReport());

  [HttpGet("export")]
  public async Task<IActionResult> Export([FromQuery] int year, [FromQuery] int month)
  {
    try
    {
      byte[] fileBytes = await _service.ExportMonthReport(year, month);
      string fileName = $"report_{year}_{month}.json";

      return File(fileBytes, "application/json", fileName);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}