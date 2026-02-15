using Api.Business.Interfaces;
using Api.Data.Interfaces;
using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Services;

public class SpendService : ISpendService
{
  private readonly ISpendRepository _spendRepo;
  private readonly ICategoryRepository _catRepo;

  public SpendService(ISpendRepository spendRepo, ICategoryRepository catRepo)
  {
    _spendRepo = spendRepo;
    _catRepo = catRepo;
  }
  public async Task<bool> AddSpend(SpendRequestDTO dto)
  {
    if (dto.Amount <= 0)
      throw new Exception("Amount have to be a positive value.");

    var cat = await _catRepo.GetById(dto.CategoryId);
    if (cat == null)
      throw new Exception("Selected category didnt exists.");

    var spends = await _spendRepo.GetAll();
    var monthAmount = spends
      .Where(s => s.CategoryId == dto.CategoryId &&
                  s.Date.Month == dto.Date.Month &&
                  s.Date.Year == dto.Date.Year)
      .Sum(s => s.Amount);

    var spend = new Spend
    {
      Description = dto.Description,
      Amount = dto.Amount,
      Date = dto.Date,
      CategoryId = dto.CategoryId
    };

    return await _spendRepo.Save(spend);
  }

  public async Task<IEnumerable<SpendResponseDTO>> GetAll()
  {
    var spends = await _spendRepo.GetAll();
    var cats = await _catRepo.GetAll();

    return spends.Select(s => new SpendResponseDTO
    {
      Id = s.Id,
      Description = s.Description,
      Amount = s.Amount,
      Date = s.Date,
      Category = cats.FirstOrDefault(c => c.Id == s.CategoryId)?.Name ?? "N/A"
    }).OrderByDescending(s => s.Date);
  }

  public async Task<IEnumerable<SpendResponseDTO>> GetByCategory(int catId)
  {
    var allSpends = await GetAll();
    var cats = await _catRepo.GetAll();
    return allSpends.Where(s => s.Category != "N/A" && cats.Any(c => c.Id == catId && c.Name == s.Category));
  }

  public async Task<IEnumerable<SpendResponseDTO>> GetByDateRange(DateTime init, DateTime last) =>
    (await GetAll()).Where(s => s.Date.Date >= init.Date && s.Date.Date <= last.Date);
}