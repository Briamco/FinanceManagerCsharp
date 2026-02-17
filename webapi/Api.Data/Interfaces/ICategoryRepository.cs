using Api.Entities.Models;

namespace Api.Data.Interfaces;

/// <summary>
/// Interfaz para el repositorio de categorías.
/// Proporciona operaciones CRUD para las entidades <see cref="Category"/>.
/// </summary>
public interface ICategoryRepository
{
  /// <summary>
  /// Obtiene todas las categorías.
  /// </summary>
  /// <returns>Colección de todas las categorías.</returns>
  Task<IEnumerable<Category>> GetAll();

  /// <summary>
  /// Obtiene una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>La categoría encontrada.</returns>
  Task<Category> GetById(int id);

  /// <summary>
  /// Guarda una nueva categoría.
  /// </summary>
  /// <param name="cat">La categoría a guardar.</param>
  /// <returns>True si se guardó correctamente, false en caso contrario.</returns>
  Task<bool> Save(Category cat);

  /// <summary>
  /// Edita una categoría existente.
  /// </summary>
  /// <param name="cat">La categoría con los datos actualizados.</param>
  /// <returns>True si se actualizó correctamente, false en caso contrario.</returns>
  Task<bool> Edit(Category cat);

  /// <summary>
  /// Elimina una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría a eliminar.</param>
  /// <returns>True si se eliminó correctamente, false en caso contrario.</returns>
  Task<bool> Delete(int id);

  /// <summary>
  /// Guarda una lista completa de categorías, sobrescribiendo el almacenamiento.
  /// </summary>
  /// <param name="cats">Lista de categorías a guardar.</param>
  Task SaveList(List<Category> cats);
}