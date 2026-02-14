using Api.Entities.Models;

namespace Api.Data.Interfaces;

public interface ICategoryRepository
{
  Task<IEnumerable<Category>> GetAll();
  Task<Category> GetById(int id);
  Task<bool> Save(Category cat);
  Task<bool> Edit(Category cat);
  Task<bool> Delete(int id);
  Task SaveList(List<Category> cats);
}