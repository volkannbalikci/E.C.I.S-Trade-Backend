using ETradeBackend.Domain.Entities;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Commands.Create;

public class CreatedCorporateAdvertOrderResponse
{
    public Guid CorporateAdvertOrderId { get; set; }
    public Guid IndividualUserId { get; set; }
    public Guid UserAddressId { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public decimal TotalPrice { get; set; }
}