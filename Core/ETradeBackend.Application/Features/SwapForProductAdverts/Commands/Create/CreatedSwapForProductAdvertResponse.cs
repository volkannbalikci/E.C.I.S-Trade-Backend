namespace ETradeBackend.Application.Features.SwapForProductAdverts.Commands.Create;

public class CreatedSwapForProductAdvertResponse
{
    public Guid SwapForProductAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredProductId { get; set; }
    public DateTime CreatedDate { get; set; }
}