using Api.Business.Interfaces;
using Api.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

/// <summary>
/// Controlador para gestionar categorías.
/// Expone endpoints REST para operaciones CRUD sobre categorías.
/// Utiliza <see cref="ICategoryService"/> para la lógica de negocio.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _service;

  /// <summary>
  /// Constructor que recibe el servicio de categorías.
  /// </summary>
  /// <param name="service">Servicio de categorías.</param>
  public CategoryController(ICategoryService service) => _service = service;

  /// <summary>
  /// Obtiene todas las categorías.
  /// </summary>
  /// <returns>Lista de todas las categorías.</returns>
  /// <response code="200">Retorna la lista de categorías.</response>
  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

  /// <summary>
  /// Crea una nueva categoría.
  /// </summary>
  /// <param name="dto">Datos de la categoría a crear.</param>
  /// <returns>Mensaje de confirmación.</returns>
  /// <response code="200">Categoría creada exitosamente.</response>
  /// <response code="400">Error en la validación (nombre duplicado, etc.).</response>
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CategoryRequestDTO dto)
  {
    try
    {
      await _service.AddCategory(dto);
      return Ok("Sucessful Category Created");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  /// <summary>
  /// Obtiene una categoría por su ID.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <returns>La categoría encontrada.</returns>
  /// <response code="200">Retorna la categoría.</response>
  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));

  /// <summary>
  /// Actualiza una categoría existente.
  /// </summary>
  /// <param name="id">Identificador de la categoría.</param>
  /// <param name="dto">Nuevos datos de la categoría.</param>
  /// <returns>Mensaje de confirmación.</returns>
  /// <response code="200">Categoría actualizada exitosamente.</response>
  /// <response code="400">Error en la validación.</response>
  [HttpPatch("{id}")]
  public async Task<IActionResult> Update(int id, [FromBody] CategoryRequestDTO dto)
  {
    try
    {
      await _service.UpdateCategory(id, dto);
      return Ok("Sucessful Category Updated");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }

  /// <summary>
  /// Elimina una categoría.
  /// </summary>
  /// <param name="id">Identificador de la categoría a eliminar.</param>
  /// <returns>Mensaje de confirmación.</returns>
  /// <response code="200">Categoría eliminada exitosamente.</response>
  /// <response code="400">Error (categoría tiene gastos asociados, etc.).</response>
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await _service.DeleteCategory(id);
      return Ok("Sucessful Category Deleted");
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }
  }
}