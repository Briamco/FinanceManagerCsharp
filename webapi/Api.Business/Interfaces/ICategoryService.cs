using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Interfaces;

public interface ICategoryService
{
  Task<IEnumerable<Category>> GetAll();
  Task<Category?> GetById(int id);
  Task<bool> AddCategory(CategoryRequestDTO dto);
  Task<bool> UpdateCategory(int id, CategoryRequestDTO dto);
  Task<bool> DeleteCategory(int id);
}