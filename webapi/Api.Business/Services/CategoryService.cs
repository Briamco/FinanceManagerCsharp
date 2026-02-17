using Api.Business.Interfaces;
using Api.Data.Interfaces;
using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Services;

/// <summary>
/// Servicio para gestionar categorías.
/// Implementa <see cref="ICategoryService"/>.
/// Utiliza <see cref="ICategoryRepository"/> y <see cref="ISpendRepository"/>.
/// </summary>
public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _catRepo;
  private readonly ISpendRepository _spendeRepo;

  /// <summary>
  /// Constructor que recibe las dependencias necesarias.
  /// </summary>
  /// <param name="catRepo">Repositorio de categorías.</param>
  /// <param name="spendRepo">Repositorio de gastos.</param>
  public CategoryService(ICategoryRepository catRepo, ISpendRepository spendRepo)
  {
    _catRepo = catRepo;
    _spendeRepo = spendRepo;
  }

  /// <summary>
  /// Obtiene todas las categorías.
  /// </summary>
  /// <returns>Colección de categorías.</returns>
  public async Task<IEnumerable<Category>> GetAll() =>
      await _catRepo.GetAll();

  /// <summary>
  /// Obtiene una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>La categoría encontrada.</returns>
  /// <exception cref="Exception">Si la categoría no existe.</exception>
  public async Task<Category?> GetById(int id)
  {
    var cat = await _catRepo.GetById(id);
    if (cat == null)
      throw new Exception("Category not found");

    return cat;
  }

  /// <summary>
  /// Agrega una nueva categoría validando que el nombre sea único.
  /// </summary>
  /// <param name="dto">Datos de la categoría.</param>
  /// <returns>True si se guardó exitosamente.</returns>
  /// <exception cref="Exception">Si ya existe una categoría con el mismo nombre.</exception>
  public async Task<bool> AddCategory(CategoryRequestDTO dto)
  {
    var cats = await _catRepo.GetAll();
    if (cats.Any(c => c.Name!.Trim().ToLower() == dto.Name!.Trim().ToLower()))
      throw new Exception($"There is a Category with the name of '{dto.Name}'.");

    Category newCat = new Category
    {
      Name = dto.Name,
      MonthBudget = dto.MonthBudget
    };

    return await _catRepo.Save(newCat);
  }

  /// <summary>
  /// Actualiza una categoría existente.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <param name="dto">Nuevos datos de la categoría.</param>
  /// <returns>True si se actualizó exitosamente.</returns>
  /// <exception cref="Exception">Si la categoría no existe o el nombre ya está en uso.</exception>
  public async Task<bool> UpdateCategory(int id, CategoryRequestDTO dto)
  {
    var cat = await _catRepo.GetById(id);
    if (cat == null)
      throw new Exception("Category not found");

    var cats = await _catRepo.GetAll();
    if (cats.Any(c => c.Name!.Trim().ToLower() == dto.Name!.Trim().ToLower() && c.Id != id))
      throw new Exception("Ya existe otra categoría con ese nombre.");

    cat.Name = dto.Name;
    cat.MonthBudget = dto.MonthBudget;

    return await _catRepo.Edit(cat);
  }

  /// <summary>
  /// Elimina una categoría si no tiene gastos asociados.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>True si se eliminó exitosamente.</returns>
  /// <exception cref="Exception">Si la categoría no existe o tiene gastos asociados.</exception>
  public async Task<bool> DeleteCategory(int id)
  {
    if ((await _catRepo.GetById(id)) == null)
      throw new Exception("Category not found");

    var spends = await _spendeRepo.GetAll();
    if (spends.Any(s => s.CategoryId == id))
      throw new Exception("Cant delete this category have register spends on it.");

    return await _catRepo.Delete(id);
  }
}