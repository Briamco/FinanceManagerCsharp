namespace Api.Entities.Models;

/// <summary>
/// Modelo de reporte para una categoría específica.
/// Utilizado en <see cref="MonthReport"/> para mostrar estadísticas por categoría.
/// </summary>
public class CategoryReport
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
  /// Presupuesto mensual de la categoría.
  /// </summary>
  public decimal MonthBudget { get; set; }

  /// <summary>
  /// Porcentaje del total general que representa esta categoría.
  /// </summary>
  public double Percent { get; set; }

  /// <summary>
  /// Indica si el gasto total de la categoría ha excedido el presupuesto mensual.
  /// </summary>
  public bool ExcessBudget => Total > MonthBudget;
}