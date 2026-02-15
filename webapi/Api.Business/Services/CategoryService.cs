using Api.Business.Interfaces;
using Api.Data.Interfaces;
using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Services;

public class CategoryService : ICategoryService
{
  private readonly ICategoryRepository _catRepo;
  private readonly ISpendRepository _spendeRepo;

  public CategoryService(ICategoryRepository catRepo, ISpendRepository spendRepo)
  {
    _catRepo = catRepo;
    _spendeRepo = spendRepo;
  }

  public async Task<IEnumerable<Category>> GetAll() =>
      await _catRepo.GetAll();


  public async Task<Category?> GetById(int id)
  {
    var cat = await _catRepo.GetById(id);
    if (cat == null)
      throw new Exception("Category not found");

    return cat;
  }


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