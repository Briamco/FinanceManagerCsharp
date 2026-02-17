using System.ComponentModel;
using System.Data.SqlTypes;
using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;
using Microsoft.VisualBasic;

namespace Api.Data.Repositories;

/// <summary>
/// Repositorio para gestionar reportes mensuales.
/// Implementa <see cref="IMonthReportRepository"/>.
/// Proporciona funcionalidad de serialización de reportes a formato JSON.
/// </summary>
public class MonthReportRepository : IMonthReportRepository
{
  private readonly JsonSerializerOptions _options;

  /// <summary>
  /// Constructor que inicializa las opciones de serialización JSON.
  /// </summary>
  public MonthReportRepository()
  {
    _options = new JsonSerializerOptions
    {
      WriteIndented = true,
      Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
  }

  /// <summary>
  /// Serializa un reporte mensual a un arreglo de bytes en formato JSON.
  /// </summary>
  /// <param name="report">Reporte mensual a serializar.</param>
  /// <returns>Arreglo de bytes con el contenido JSON.</returns>
  public byte[] SerializeReportInBytes(MonthReport report) =>
    JsonSerializer.SerializeToUtf8Bytes(report, _options);
}