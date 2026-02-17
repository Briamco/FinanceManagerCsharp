using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;

namespace Api.Data.Repositories;

/// <summary>
/// Repositorio para gestionar categorías.
/// Implementa <see cref="ICategoryRepository"/>.
/// Utiliza almacenamiento en archivo JSON (categories.json).
/// </summary>
public class CategoryRepository : ICategoryRepository
{
  private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "categories.json");

  /// <summary>
  /// Obtiene todas las categorías desde el archivo JSON.
  /// </summary>
  /// <returns>Colección de categorías.</returns>
  public async Task<IEnumerable<Category>> GetAll()
  {
    if (!File.Exists(_path))
      return [];

    string json = await File.ReadAllTextAsync(_path);
    return JsonSerializer.Deserialize<List<Category>>(json) ?? [];
  }

  /// <summary>
  /// Obtiene una categoría específica por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>La categoría encontrada o null.</returns>
  public async Task<Category> GetById(int id) =>
    (await GetAll()).FirstOrDefault(c => c.Id == id)!;

  /// <summary>
  /// Guarda una nueva categoría asignándole un ID autogenerado.
  /// </summary>
  /// <param name="cat">Categoría a guardar.</param>
  /// <returns>True si se guardó exitosamente.</returns>
  public async Task<bool> Save(Category cat)
  {
    try
    {
      var cats = (await GetAll()).ToList();

      cat.Id = cats.Count > 0 ? cats.Max(c => c.Id) + 1 : 1;

      cats.Add(cat);
      await SaveList(cats);

      return true;
    }
    catch
    {
      return false;
    }
  }

  /// <summary>
  /// Edita una categoría existente.
  /// </summary>
  /// <param name="cat">Categoría con los datos actualizados.</param>
  /// <returns>True si se actualizó exitosamente.</returns>
  public async Task<bool> Edit(Category cat)
  {
    try
    {
      var cats = (await GetAll()).ToList();

      int index = cats.FindIndex(c => c.Id == cat.Id);
      if (index == -1) return false;

      cats[index] = cat;
      await SaveList(cats);

      return true;
    }
    catch
    {
      return false;
    }
  }

  /// <summary>
  /// Elimina una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría a eliminar.</param>
  /// <returns>True si se eliminó exitosamente.</returns>
  public async Task<bool> Delete(int id)
  {
    try
    {
      Category cat = await GetById(id);
      var cats = (await GetAll()).ToList();

      cats.Remove(cat);
      await SaveList(cats);

      return true;
    }
    catch
    {
      return false;
    }
  }

  /// <summary>
  /// Guarda la lista completa de categorías en el archivo JSON.
  /// </summary>
  /// <param name="cats">Lista de categorías a guardar.</param>
  public async Task SaveList(List<Category> cats)
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(cats, options);
    await File.WriteAllTextAsync(_path, json);
  }
}