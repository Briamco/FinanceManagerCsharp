using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Interfaces;

/// <summary>
/// Interfaz para el servicio de categorías.
/// Proporciona lógica de negocio para gestionar <see cref="Category"/>.
/// Utiliza <see cref="Api.Data.Interfaces.ICategoryRepository"/> para el acceso a datos.
/// </summary>
public interface ICategoryService
{
  /// <summary>
  /// Obtiene todas las categorías.
  /// </summary>
  /// <returns>Colección de categorías.</returns>
  Task<IEnumerable<Category>> GetAll();

  /// <summary>
  /// Obtiene una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>La categoría encontrada o null.</returns>
  Task<Category?> GetById(int id);

  /// <summary>
  /// Agrega una nueva categoría.
  /// Valida que no exista una categoría con el mismo nombre.
  /// </summary>
  /// <param name="dto">Datos de la categoría a crear.</param>
  /// <returns>True si se creó exitosamente.</returns>
  Task<bool> AddCategory(CategoryRequestDTO dto);

  /// <summary>
  /// Actualiza una categoría existente.
  /// Valida que no exista otra categoría con el mismo nombre.
  /// </summary>
  /// <param name="id">Identificador de la categoría a actualizar.</param>
  /// <param name="dto">Nuevos datos de la categoría.</param>
  /// <returns>True si se actualizó exitosamente.</returns>
  Task<bool> UpdateCategory(int id, CategoryRequestDTO dto);

  /// <summary>
  /// Elimina una categoría.
  /// Valida que no existan gastos asociados a la categoría.
  /// </summary>
  /// <param name="id">Identificador de la categoría a eliminar.</param>
  /// <returns>True si se eliminó exitosamente.</returns>
  Task<bool> DeleteCategory(int id);
}