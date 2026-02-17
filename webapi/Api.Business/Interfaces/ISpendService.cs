using Api.Entities.DTOs;

namespace Api.Business.Interfaces;

/// <summary>
/// Interfaz para el servicio de gastos.
/// Proporciona lógica de negocio para gestionar gastos.
/// Utiliza <see cref="Api.Data.Interfaces.ISpendRepository"/> para el acceso a datos.
/// </summary>
public interface ISpendService
{
  /// <summary>
  /// Agrega un nuevo gasto.
  /// Valida que el monto sea positivo y que la categoría exista.
  /// </summary>
  /// <param name="dto">Datos del gasto a crear.</param>
  /// <returns>True si se creó exitosamente.</returns>
  Task<bool> AddSpend(SpendRequestDTO dto);

  /// <summary>
  /// Obtiene todos los gastos con información de su categoría.
  /// Los gastos se ordenan por fecha descendente.
  /// </summary>
  /// <returns>Colección de gastos con detalles.</returns>
  Task<IEnumerable<SpendResponseDTO>> GetAll();

  /// <summary>
  /// Obtiene los gastos filtrados por categoría.
  /// </summary>
  /// <param name="catId">Identificador de la categoría.</param>
  /// <returns>Colección de gastos de la categoría especificada.</returns>
  Task<IEnumerable<SpendResponseDTO>> GetByCategory(int catId);

  /// <summary>
  /// Obtiene los gastos en un rango de fechas.
  /// </summary>
  /// <param name="init">Fecha inicial del rango.</param>
  /// <param name="last">Fecha final del rango.</param>
  /// <returns>Colección de gastos dentro del rango especificado.</returns>
  Task<IEnumerable<SpendResponseDTO>> GetByDateRange(DateTime init, DateTime last);
}