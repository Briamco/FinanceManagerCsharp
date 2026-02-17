using Api.Entities.Interfaces;

namespace Api.Entities.Models;

/// <summary>
/// Representa una categoría de gasto en el sistema.
/// Implementa <see cref="IEntity"/> para tener un identificador único.
/// Relacionada con <see cref="Spend"/> mediante la propiedad CategoryId.
/// </summary>
public class Category : IEntity
{
  /// <summary>
  /// Identificador único de la categoría.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Nombre de la categoría.
  /// </summary>
  public string? Name { get; set; }

  /// <summary>
  /// Presupuesto mensual asignado a esta categoría.
  /// </summary>
  public decimal MonthBudget { get; set; }
}