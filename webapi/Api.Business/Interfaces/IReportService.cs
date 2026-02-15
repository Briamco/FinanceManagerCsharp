using Api.Entities.DTOs;

namespace Api.Business.Interfaces;

public interface IReportService
{
  Task<GeneralReportDTO> GetGeneralReport();
  Task<byte[]> ExportMonthReport(int year, int month);
}