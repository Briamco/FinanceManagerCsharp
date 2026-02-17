namespace Api.Entities.Enums;

/// <summary>
/// Enumeración que representa el estado del presupuesto.
/// </summary>
public enum BudgetState
{
  /// <summary>
  /// Estado normal: El gasto está dentro del presupuesto.
  /// </summary>
  Normal,

  /// <summary>
  /// Advertencia: El gasto se acerca al límite del presupuesto.
  /// </summary>
  Warning,

  /// <summary>
  /// Exceso: El gasto ha superado el presupuesto asignado.
  /// </summary>
  Excess
}