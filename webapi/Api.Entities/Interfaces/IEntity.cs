namespace Api.Entities.Interfaces;

/// <summary>
/// Interfaz base para todas las entidades del sistema.
/// </summary>
public interface IEntity
{
  /// <summary>
  /// Identificador único de la entidad.
  /// </summary>
  int Id { get; set; }
}