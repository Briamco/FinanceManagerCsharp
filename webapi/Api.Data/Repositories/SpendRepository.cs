using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;

namespace Api.Data.Repositories;

public class SpendRepository : ISpendRepository
{
  private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "spends.json");

  public async Task<IEnumerable<Spend>> GetAll()
  {
    if (!File.Exists(_path))
      return [];

    string json = await File.ReadAllTextAsync(_path);
    return JsonSerializer.Deserialize<List<Spend>>(json) ?? [];
  }

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

  public async Task SaveList(List<Spend> spends)
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(spends, options);
    await File.WriteAllTextAsync(_path, json);
  }
}