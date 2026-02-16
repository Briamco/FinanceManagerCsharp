using System.Text.Json;
using Api.Data.Interfaces;
using Api.Entities.Models;

namespace Api.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
  private readonly string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "categories.json");
  public async Task<IEnumerable<Category>> GetAll()
  {
    if (!File.Exists(_path))
      return [];

    string json = await File.ReadAllTextAsync(_path);
    return JsonSerializer.Deserialize<List<Category>>(json) ?? [];
  }

  public async Task<Category> GetById(int id) =>
    (await GetAll()).FirstOrDefault(c => c.Id == id)!;

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

  public async Task SaveList(List<Category> cats)
  {
    var options = new JsonSerializerOptions { WriteIndented = true };
    string json = JsonSerializer.Serialize(cats, options);
    await File.WriteAllTextAsync(_path, json);
  }
}