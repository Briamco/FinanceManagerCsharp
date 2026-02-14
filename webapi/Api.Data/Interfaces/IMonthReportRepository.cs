using Api.Entities.Models;

namespace Api.Data.Interfaces;

public interface IMonthReportRepository
{
  Task<bool> ExportReport(MonthReport report, string fileName);

  IEnumerable<string> GetExportedReportsNames();
}