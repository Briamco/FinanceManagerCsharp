using Api.Business.Interfaces;
using Api.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

/// <summary>
/// Controlador para gestionar gastos.
/// Expone endpoints REST para operaciones sobre gastos.
/// Utiliza <see cref="ISpendService"/> para la lógica de negocio.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SpendsController : ControllerBase
{
  private readonly ISpendService _service;

  /// <summary>
  /// Constructor que recibe el servicio de gastos.
  /// </summary>
  /// <param name="service">Servicio de gastos.</param>
  public SpendsController(ISpendService service) => _service = service;

  /// <summary>
  /// Obtiene todos los gastos.
  /// </summary>
  /// <returns>Lista de todos los gastos con información de categoría.</returns>
  /// <response code="200">Retorna la lista de gastos.</response>
  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

  /// <summary>
  /// Crea un nuevo gasto.
  /// </summary>
  /// <param name="dto">Datos del gasto a crear.</param>
  /// <returns>Mensaje de confirmación.</returns>
  /// <response code="200">Gasto creado exitosamente.</response>
  /// <response code="400">Error en la validación (monto inválido, categoría inexistente, etc.).</response>
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SpendRequestDTO dto)
  {
    try
    {
      await _service.AddSpend(dto);
      return Ok("Sucessful, Spend Created.");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  /// <summary>
  /// Obtiene los gastos filtrados por categoría.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>Lista de gastos de la categoría especificada.</returns>
  /// <response code="200">Retorna la lista de gastos filtrados.</response>
  [HttpGet("search/category/{id}")]
  public async Task<IActionResult> GetByCat(int id) => Ok(await _service.GetByCategory(id));

  /// <summary>
  /// Obtiene los gastos en un rango de fechas.
  /// </summary>
  /// <param name="init">Fecha inicial del rango.</param>
  /// <param name="last">Fecha final del rango.</param>
  /// <returns>Lista de gastos dentro del rango de fechas.</returns>
  /// <response code="200">Retorna la lista de gastos filtrados por fecha.</response>
  [HttpGet("search/date")]
  public async Task<IActionResult> GetByDate([FromQuery] DateTime init, [FromQuery] DateTime last)
    => Ok(await _service.GetByDateRange(init, last));
}