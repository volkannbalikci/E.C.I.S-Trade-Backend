using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Delete;

public class DeletedSwapForCategoryAdvertResponse
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime DeletedDate { get; set; }
}
