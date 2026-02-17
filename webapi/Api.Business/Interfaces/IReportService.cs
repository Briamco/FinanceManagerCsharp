using Api.Entities.DTOs;

namespace Api.Business.Interfaces;

/// <summary>
/// Interfaz para el servicio de reportes.
/// Proporciona funcionalidad para generar reportes de gastos.
/// Utiliza repositorios de <see cref="Api.Data.Interfaces"/> para obtener datos.
/// </summary>
public interface IReportService
{
  /// <summary>
  /// Genera un reporte general con todos los gastos y su distribución por categorías.
  /// Incluye advertencias si se exceden presupuestos.
  /// </summary>
  /// <returns>Reporte general de gastos.</returns>
  Task<GeneralReportDTO> GetGeneralReport();

  /// <summary>
  /// Exporta un reporte mensual en formato JSON como arreglo de bytes.
  /// </summary>
  /// <param name="year">Año del reporte.</param>
  /// <param name="month">Mes del reporte.</param>
  /// <returns>Reporte mensual serializado en bytes.</returns>
  Task<byte[]> ExportMonthReport(int year, int month);
}