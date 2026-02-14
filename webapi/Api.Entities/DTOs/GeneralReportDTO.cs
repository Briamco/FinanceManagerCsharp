namespace Api.Entities.DTOs;

public class GeneralReportDTO
{
  public decimal Total { get; set; }
  public List<CategoryReportDTO>? CategoriesReport { get; set; }
  public List<string>? Warning { get; set; }
}