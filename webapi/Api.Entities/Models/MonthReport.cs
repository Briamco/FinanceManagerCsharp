namespace Api.Entities.Models;

/// <summary>
/// Modelo de reporte mensual de gastos.
/// Contiene el resumen de gastos por mes con desglose por categorías.
/// Relacionado con <see cref="CategoryReport"/> para el detalle por categoría.
/// </summary>
public class MonthReport
{
  /// <summary>
  /// Mes y año del reporte en formato MM-YYYY.
  /// </summary>
  public string? MY { get; set; }

  /// <summary>
  /// Total de gastos del mes.
  /// </summary>
  public decimal Total { get; set; }

  /// <summary>
  /// Lista de reportes por categoría.
  /// </summary>
  public List<CategoryReport>? CategoriesReport { get; set; }

  /// <summary>
  /// Lista de advertencias generadas (por ejemplo, cuando se excede el presupuesto).
  /// </summary>
  public List<string>? Warning { get; set; }
}