namespace Api.Entities.DTOs;

public class CategoryReportDTO
{
  public string? CategoryName { get; set; }
  public decimal Total { get; set; }
  public double Percent { get; set; }
}