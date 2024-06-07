using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Commands.Delete;

public class DeletedSwapAdvertResponse
{
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime DeletedDate { get; set; }
}
