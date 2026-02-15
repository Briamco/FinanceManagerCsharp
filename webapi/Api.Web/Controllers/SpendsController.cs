using Api.Business.Interfaces;
using Api.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpendsController : ControllerBase
{
  private readonly ISpendService _service;

  public SpendsController(ISpendService service) => _service = service;

  [HttpGet]
  public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

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

  [HttpGet("search/category/{id}")]
  public async Task<IActionResult> GetByCat(int id) => Ok(await _service.GetByCategory(id));


  [HttpGet("search/date")]
  public async Task<IActionResult> GetByDate([FromQuery] DateTime init, [FromQuery] DateTime last)
    => Ok(await _service.GetByDateRange(init, last));
}