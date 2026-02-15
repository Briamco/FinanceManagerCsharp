using Api.Entities.DTOs;

namespace Api.Business.Interfaces;

public interface ISpendService
{
  Task<bool> AddSpend(SpendRequestDTO dto);
  Task<IEnumerable<SpendResponseDTO>> GetAll();
  Task<IEnumerable<SpendResponseDTO>> GetByCategory(int catId);
  Task<IEnumerable<SpendResponseDTO>> GetByDateRange(DateTime init, DateTime last);
}