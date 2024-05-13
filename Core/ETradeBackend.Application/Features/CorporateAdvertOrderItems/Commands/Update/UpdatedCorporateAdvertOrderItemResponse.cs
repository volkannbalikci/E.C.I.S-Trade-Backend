namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Update;

public class UpdatedCorporateAdvertOrderItemResponse
{
    public Guid Id { get; set; }
    public Guid CorporateAdvertOrderId { get; set; }
    public Guid CorporateAdvertId { get; set; }
    public int Amount { get; set; }
    public decimal BoughtPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}