using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Create;

public class CreatedSwapAdvertResponse
{
    public Guid SwapAdverId { get; set; }
    public Guid AdvertId { get; set; }
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid IndividualUserId { get; set; }
    public DateTime CreatedDate { get; set; }
}
