using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;

namespace Api.Data.Repositories;

/// <summary>
/// Repositorio para gestionar gastos.
/// Implementa <see cref="ISpendRepository"/>.
/// Utiliza almacenamiento en archivo JSON (spends.json).
/// </summary>
public class SpendRepository : ISpendRepository
{
  private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "spends.json");

  /// <summary>
  /// Obtiene todos los gastos desde el archivo JSON.
  /// </summary>
  /// <returns>Colección de gastos.</returns>
  public async Task<IEnumerable<Spend>> GetAll()
  {
    if (!File.Exists(_path))
      return [];

    string json = await File.ReadAllTextAsync(_path);
    return JsonSerializer.Deserialize<List<Spend>>(json) ?? [];
  }

  /// <summary>
  /// Guarda un nuevo gasto asignándole un ID autogenerado.
  /// </summary>
  /// <param name="spend">Gasto a guardar.</param>
  /// <returns>True si se guardó exitosamente.</returns>
  public async Task<bool> Save(Spend spend)
  {
    try
    {
      var spends = (await GetAll()).ToList();

      spend.Id = spends.Count > 0 ? spends.Max(s => s.Id) + 1 : 1;

      spends.Add(spend);

      await SaveList(spends);

      return true;
    }
    catch
    {
      return false;
    }
  }

  /// <summary>
  /// Guarda la lista completa de gastos en el archivo JSON.
  /// </summary>
  /// <param name="spends">Lista de gastos a guardar.</param>
  public async Task SaveList(List<Spend> spends)
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(spends, options);
    await File.WriteAllTextAsync(_path, json);
  }
}