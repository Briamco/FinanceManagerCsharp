using Api.Entities.Interfaces;

namespace Api.Entities.Models;

public class Spend : IEntity
{
  public int Id { get; set; }
  public string? Description { get; set; }
  public decimal Amount { get; set; }
  public DateTime Date { get; set; }

  public int CategoryId { get; set; }
}