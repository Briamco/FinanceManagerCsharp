using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;

namespace Api.Data.Repositories;

public class MonthReportRepository : IMonthReportRepository
{

  public async Task<bool> ExportReport(MonthReport report, string fileName)
  {
    try
    {
      if (!fileName.EndsWith(".json")) fileName += ".json";

      string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Exports/{fileName}");

      var options = new JsonSerializerOptions { WriteIndented = true };
      string json = JsonSerializer.Serialize(report, options);

      await File.WriteAllTextAsync(path, json);
      return true;
    }
    catch
    {
      return false;
    }
  }

  public IEnumerable<string> GetExportedReportsNames()
  {
    string basePath = AppDomain.CurrentDomain.BaseDirectory + "Exports";
    return Directory.GetFiles(basePath, "report_*.json")
                    .Select(Path.GetFileName)!;
  }
}