using Api.Entities.Models;

namespace Api.Data.Interfaces;

/// <summary>
/// Interfaz para el repositorio de reportes mensuales.
/// Proporciona operaciones para serializar reportes de tipo <see cref="MonthReport"/>.
/// </summary>
public interface IMonthReportRepository
{
  /// <summary>
  /// Serializa un reporte mensual en un arreglo de bytes en formato JSON.
  /// </summary>
  /// <param name="report">El reporte mensual a serializar.</param>
  /// <returns>Arreglo de bytes con el JSON del reporte.</returns>
  byte[] SerializeReportInBytes(MonthReport report);
}