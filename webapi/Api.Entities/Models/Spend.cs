using Api.Entities.Interfaces;

namespace Api.Entities.Models;

/// <summary>
/// Representa un gasto realizado en el sistema.
/// Implementa <see cref="IEntity"/> para tener un identificador único.
/// Relacionado con <see cref="Category"/> mediante la propiedad CategoryId.
/// </summary>
public class Spend : IEntity
{
  /// <summary>
  /// Identificador único del gasto.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Descripción del gasto.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// Monto del gasto.
  /// </summary>
  public decimal Amount { get; set; }

  /// <summary>
  /// Fecha en que se realizó el gasto.
  /// </summary>
  public DateTime Date { get; set; }

  /// <summary>
  /// Identificador de la categoría a la que pertenece este gasto.
  /// Hace referencia a <see cref="Category.Id"/>.
  /// </summary>
  public int CategoryId { get; set; }
}