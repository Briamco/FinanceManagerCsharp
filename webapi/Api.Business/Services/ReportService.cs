using Api.Business.Interfaces;
using Api.Data.Interfaces;
using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Services;

/// <summary>
/// Servicio para generar reportes de gastos.
/// Implementa <see cref="IReportService"/>.
/// Utiliza varios repositorios para obtener datos y generar reportes.
/// </summary>
public class ReportService : IReportService
{
  private readonly IMonthReportRepository _reportRepo;
  private readonly ISpendRepository _spendRepo;
  private readonly ICategoryRepository _catRepo;

  /// <summary>
  /// Constructor que recibe las dependencias necesarias.
  /// </summary>
  /// <param name="reportRepo">Repositorio de reportes mensuales.</param>
  /// <param name="spendRepo">Repositorio de gastos.</param>
  /// <param name="catRepo">Repositorio de categorías.</param>
  public ReportService(IMonthReportRepository reportRepo, ISpendRepository spendRepo, ICategoryRepository catRepo)
  {
    _reportRepo = reportRepo;
    _spendRepo = spendRepo;
    _catRepo = catRepo;
  }

  /// <summary>
  /// Genera un reporte general con el total de gastos y su distribución por categorías.
  /// Incluye advertencias cuando se exceden los presupuestos.
  /// </summary>
  /// <returns>Reporte general con el detalle de gastos por categoría.</returns>
  public async Task<GeneralReportDTO> GetGeneralReport()
  {
    var spends = await _spendRepo.GetAll();
    var cats = await _catRepo.GetAll();

    var InfoDate = DateTime.Now;
    var monthSpends = spends.Where(s => s.Date.Month == InfoDate.Month && s.Date.Year == InfoDate.Year)
                            .ToList();

    var report = new GeneralReportDTO
    {
      Total = spends.Sum(s => s.Amount),
      CategoriesReport = [],
      Warnings = []
    };

    foreach (var cat in cats)
    {
      var totalCat = monthSpends.Where(s => s.CategoryId == cat.Id).Sum(s => s.Amount);

      double percent = report.Total > 0
        ? (double)(totalCat / report.Total) * 100
        : 0;

      report.CategoriesReport.Add(new CategoryReportDTO
      {
        CategoryName = cat.Name,
        Total = totalCat,
        Budget = cat.MonthBudget,
        Percent = percent
      });

      if (totalCat > cat.MonthBudget)
      {
        report.Warnings.Add($"WARNING: The category '{cat.Name}' has exceeded its budget by ${totalCat - cat.MonthBudget}");
      }
    }

    return report;
  }

  /// <summary>
  /// Exporta un reporte mensual en formato JSON.
  /// Incluye el total del mes, el desglose por categorías y advertencias de presupuesto.
  /// </summary>
  /// <param name="year">Año del reporte.</param>
  /// <param name="month">Mes del reporte.</param>
  /// <returns>Arreglo de bytes con el JSON del reporte mensual.</returns>
  public async Task<byte[]> ExportMonthReport(int year, int month)
  {
    var spends = await _spendRepo.GetAll();
    var cats = await _catRepo.GetAll();

    var monthSpends = spends.Where(s => s.Date.Month == month && s.Date.Year == year)
                            .ToList();

    var monthReport = new MonthReport
    {
      MY = $"{month:D2}-{year}",
      Total = monthSpends.Sum(s => s.Amount),
      CategoriesReport = [],
      Warning = []
    };

    foreach (var cat in cats)
    {
      var totalCat = monthSpends.Where(s => s.CategoryId == cat.Id).Sum(s => s.Amount);
      if (totalCat > 0)
      {
        var catReport = new CategoryReport
        {
          CategoryName = cat.Name,
          Total = totalCat,
          MonthBudget = cat.MonthBudget,
          Percent = Math.Round((double)(totalCat / (monthReport.Total > 0 ? monthReport.Total : 1)) * 100, 2)
        };

        monthReport.CategoriesReport.Add(catReport);
        if (catReport.ExcessBudget)
          monthReport.Warning.Add($"WARNING: The category '{cat.Name}' has exceeded its budget by ${totalCat - cat.MonthBudget}");
      }
    }

    return _reportRepo.SerializeReportInBytes(monthReport);
  }
}