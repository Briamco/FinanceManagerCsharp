using Api.Entities.Models;

namespace Api.Data.Interfaces;

/// <summary>
/// Interfaz para el repositorio de gastos.
/// Proporciona operaciones para gestionar las entidades <see cref="Spend"/>.
/// </summary>
public interface ISpendRepository
{
  /// <summary>
  /// Obtiene todos los gastos.
  /// </summary>
  /// <returns>Colección de todos los gastos.</returns>
  Task<IEnumerable<Spend>> GetAll();

  /// <summary>
  /// Guarda un nuevo gasto.
  /// </summary>
  /// <param name="spend">El gasto a guardar.</param>
  /// <returns>True si se guardó correctamente, false en caso contrario.</returns>
  Task<bool> Save(Spend spend);

  /// <summary>
  /// Guarda una lista completa de gastos, sobrescribiendo el almacenamiento.
  /// </summary>
  /// <param name="spends">Lista de gastos a guardar.</param>
  Task SaveList(List<Spend> spends);
}