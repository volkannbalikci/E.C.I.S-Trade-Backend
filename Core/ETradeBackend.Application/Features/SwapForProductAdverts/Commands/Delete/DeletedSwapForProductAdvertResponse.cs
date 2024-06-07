namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Delete;

public class DeletedSwapForProductAdvertResponse
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime DeletedDate { get; set; }
}