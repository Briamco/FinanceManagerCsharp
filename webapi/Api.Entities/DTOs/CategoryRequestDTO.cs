namespace Api.Entities.DTOs;

/// <summary>
/// DTO para la creación y actualización de categorías.
/// Utilizado en <see cref="Api.Business.Interfaces.ICategoryService"/>.
/// </summary>
public class CategoryRequestDTO
{
  /// <summary>
  /// Nombre de la categoría. Debe ser único en el sistema.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Presupuesto mensual asignado a la categoría.
  /// </summary>
  public decimal MonthBudget { get; set; }
}