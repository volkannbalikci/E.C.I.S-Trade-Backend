namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Create;

public class CreatedSwapForCategoryAdvertResponse
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredCategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
}