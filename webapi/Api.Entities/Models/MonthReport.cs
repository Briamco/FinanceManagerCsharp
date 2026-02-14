namespace Api.Entities.Models;

public class MonthReport
{
  public string? MY { get; set; }
  public decimal Total { get; set; }
  public List<CategoryReport>? CategoriesReport { get; set; }
  public List<string>? Warning { get; set; }
}