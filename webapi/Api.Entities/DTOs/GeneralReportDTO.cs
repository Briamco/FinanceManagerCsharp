namespace Api.Entities.DTOs;

/// <summary>
/// DTO de reporte general de gastos.
/// Contiene el resumen total y el desglose por categorías.
/// Relacionado con <see cref="CategoryReportDTO"/> para el detalle.
/// </summary>
public class GeneralReportDTO
{
  /// <summary>
  /// Total de todos los gastos.
  /// </summary>
  public decimal Total { get; set; }

  /// <summary>
  /// Lista de reportes por categoría.
  /// </summary>
  public List<CategoryReportDTO>? CategoriesReport { get; set; }

  /// <summary>
  /// Lista de advertencias (por ejemplo, presupuestos excedidos).
  /// </summary>
  public List<string>? Warnings { get; set; }
}