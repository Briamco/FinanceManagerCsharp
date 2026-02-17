using Api.Entities.Interfaces;

namespace Api.Entities.DTOs;

/// <summary>
/// DTO de respuesta para gastos.
/// Incluye el nombre de la categoría en lugar del ID para facilitar la visualización.
/// Implementa <see cref="IEntity"/> para tener un identificador.
/// </summary>
public class SpendResponseDTO : IEntity
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
  /// Fecha del gasto.
  /// </summary>
  public DateTime Date { get; set; }

  /// <summary>
  /// Nombre de la categoría asociada al gasto.
  /// </summary>
  public string? Category { get; set; }
}