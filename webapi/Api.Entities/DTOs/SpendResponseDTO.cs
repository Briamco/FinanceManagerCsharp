using Api.Entities.Interfaces;

namespace Api.Entities.DTOs;

public class SpendRespondeDTO : IEntity
{
  public int Id { get; set; }
  public string? Description { get; set; }
  public decimal Amount { get; set; }
  public DateTime Date { get; set; }

  public string? CategoryId { get; set; }
}