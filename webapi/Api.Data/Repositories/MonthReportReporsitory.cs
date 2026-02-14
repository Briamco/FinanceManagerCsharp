using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;
using Microsoft.VisualBasic;

namespace Api.Data.Repositories;

public class MonthReportRepository : IMonthReportRepository
{
  private readonly JsonSerializerOptions _options;
  public MonthReportRepository()
  {
    _options = new JsonSerializerOptions
    {
      WriteIndented = true,
      Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
  }

  public byte[] SerializeReportInBytes(MonthReport report) =>
    JsonSerializer.SerializeToUtf8Bytes(report, _options);
}