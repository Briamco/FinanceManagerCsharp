using Api.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

/// <summary>
/// Controlador para generar reportes de gastos.
/// Expone endpoints para obtener reportes generales y exportar reportes mensuales.
/// Utiliza <see cref="IReportService"/> para la lógica de negocio.
/// </summary>
[Controller]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
  private readonly IReportService _service;

  /// <summary>
  /// Constructor que recibe el servicio de reportes.
  /// </summary>
  /// <param name="service">Servicio de reportes.</param>
  public ReportController(IReportService service) => _service = service;

  /// <summary>
  /// Obtiene el reporte general de gastos.
  /// Incluye el total y la distribución por categorías con advertencias de presupuesto.
  /// </summary>
  /// <returns>Reporte general con desglose por categoría.</returns>
  /// <response code="200">Retorna el reporte general.</response>
  [HttpGet("general")]
  public async Task<IActionResult> GetGeneral() => Ok(await _service.GetGeneralReport());

  /// <summary>
  /// Exporta un reporte mensual en formato JSON.
  /// </summary>
  /// <param name="year">Año del reporte.</param>
  /// <param name="month">Mes del reporte.</param>
  /// <returns>Archivo JSON con el reporte mensual.</returns>
  /// <response code="200">Retorna el archivo JSON del reporte.</response>
  /// <response code="400">Error al generar el reporte.</response>
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