namespace Api.Entities.DTOs;

public class SpendRequestDTO
{
  public string? Description { get; set; }
  public decimal Amount { get; set; }
  public DateTime Date { get; set; }
  public int CategoryId { get; set; }
}
