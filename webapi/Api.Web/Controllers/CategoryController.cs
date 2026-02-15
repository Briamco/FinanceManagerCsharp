using Api.Business.Interfaces;
using Api.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
  private readonly ICategoryService _service;

  public CategoryController(ICategoryService service) => _service = service;

  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

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

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id) => Ok(await _service.GetById(id));

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