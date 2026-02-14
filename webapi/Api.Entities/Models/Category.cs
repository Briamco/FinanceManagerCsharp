using Api.Entities.Interfaces;

namespace Api.Entities.Models;

public class Category : IEntity
{
  public int Id { get; set; }
  public string? Name { get; set; }
  public decimal MonthBudget { get; set; }
}