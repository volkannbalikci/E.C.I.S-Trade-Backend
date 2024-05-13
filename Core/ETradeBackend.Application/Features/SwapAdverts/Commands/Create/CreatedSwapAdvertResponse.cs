using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Create;

public class CreatedSwapAdvertResponse
{
    public Guid AdvertId { get; set; }
    public Guid IndividualUserId { get; set; }
    public DateTime CreatedDate { get; set; }
}
