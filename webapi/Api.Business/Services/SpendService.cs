using Api.Business.Interfaces;
using Api.Data.Interfaces;
using Api.Entities.DTOs;
using Api.Entities.Models;

namespace Api.Business.Services;

/// <summary>
/// Servicio para gestionar gastos.
/// Implementa <see cref="ISpendService"/>.
/// Utiliza <see cref="ISpendRepository"/> y <see cref="ICategoryRepository"/>.
/// </summary>
public class SpendService : ISpendService
{
  private readonly ISpendRepository _spendRepo;
  private readonly ICategoryRepository _catRepo;

  /// <summary>
  /// Constructor que recibe las dependencias necesarias.
  /// </summary>
  /// <param name="spendRepo">Repositorio de gastos.</param>
  /// <param name="catRepo">Repositorio de categorías.</param>
  public SpendService(ISpendRepository spendRepo, ICategoryRepository catRepo)
  {
    _spendRepo = spendRepo;
    _catRepo = catRepo;
  }

  /// <summary>
  /// Agrega un nuevo gasto validando el monto y la categoría.
  /// </summary>
  /// <param name="dto">Datos del gasto.</param>
  /// <returns>True si se guardó exitosamente.</returns>
  /// <exception cref="Exception">Si el monto no es positivo o la categoría no existe.</exception>
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

  /// <summary>
  /// Obtiene todos los gastos con el nombre de la categoría.
  /// Los gastos se ordenan por fecha descendente.
  /// </summary>
  /// <returns>Colección de gastos con detalles.</returns>
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

  /// <summary>
  /// Obtiene los gastos filtrados por categoría.
  /// </summary>
  /// <param name="catId">Identificador de la categoría.</param>
  /// <returns>Colección de gastos de la categoría.</returns>
  public async Task<IEnumerable<SpendResponseDTO>> GetByCategory(int catId)
  {
    var allSpends = await GetAll();
    var cats = await _catRepo.GetAll();
    return allSpends.Where(s => s.Category != "N/A" && cats.Any(c => c.Id == catId && c.Name == s.Category));
  }

  /// <summary>
  /// Obtiene los gastos en un rango de fechas.
  /// </summary>
  /// <param name="init">Fecha inicial.</param>
  /// <param name="last">Fecha final.</param>
  /// <returns>Colección de gastos dentro del rango.</returns>
  public async Task<IEnumerable<SpendResponseDTO>> GetByDateRange(DateTime init, DateTime last) =>
    (await GetAll()).Where(s => s.Date.Date >= init.Date && s.Date.Date <= last.Date);
}