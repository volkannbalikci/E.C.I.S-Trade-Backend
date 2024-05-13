namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Delete;

public class DeletedCorporateAdvertOrderItemResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}