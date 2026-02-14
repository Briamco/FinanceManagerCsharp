using Api.Entities.Models;

namespace Api.Data.Interfaces;

public interface IMonthReportRepository
{
  byte[] SerializeReportInBytes(MonthReport report);
}