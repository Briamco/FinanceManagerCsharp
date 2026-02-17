namespace Api.Entities.DTOs;

/// <summary>
/// DTO de reporte para una categoría.
/// Utilizado en <see cref="GeneralReportDTO"/> para mostrar el resumen de gastos.
/// </summary>
public class CategoryReportDTO
{
  /// <summary>
  /// Nombre de la categoría.
  /// </summary>
  public string? CategoryName { get; set; }

  /// <summary>
  /// Total gastado en esta categoría.
  /// </summary>
  public decimal Total { get; set; }

  /// <summary>
  /// Presupuesto asignado a la categoría.
  /// </summary>
  public decimal Budget { get; set; }

  /// <summary>
  /// Porcentaje del total general que representa esta categoría.
  /// </summary>
  public double Percent { get; set; }
}