namespace Api.Entities.Models;

public class CategoryReport
{
  public string? CategoryName { get; set; }
  public decimal Total { get; set; }
  public decimal MonthBudget { get; set; }
  public double Percent { get; set; }
  public bool ExcessBudget => Total > MonthBudget;
}