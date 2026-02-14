using Api.Entities.Models;

namespace Api.Data.Interfaces;

public interface ISpendRepository
{
  Task<IEnumerable<Spend>> GetAll();
  Task<bool> Save(Spend spend);
  Task SaveList(List<Spend> spends);
}