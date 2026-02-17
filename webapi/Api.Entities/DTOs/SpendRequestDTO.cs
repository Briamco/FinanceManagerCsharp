namespace Api.Entities.DTOs;

/// <summary>
/// DTO para la creación de un nuevo gasto.
/// Utilizado en <see cref="Api.Business.Interfaces.ISpendService.AddSpend"/>.
/// </summary>
public class SpendRequestDTO
{
  /// <summary>
  /// Descripción del gasto.
  /// </summary>
  public string? Description { get; set; }

  /// <summary>
  /// Monto del gasto. Debe ser un valor positivo.
  /// </summary>
  public decimal Amount { get; set; }

  /// <summary>
  /// Fecha del gasto.
  /// </summary>
  public DateTime Date { get; set; }

  /// <summary>
  /// Identificador de la categoría asociada al gasto.
  /// </summary>
  public int CategoryId { get; set; }
}
