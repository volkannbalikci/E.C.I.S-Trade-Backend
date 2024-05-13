using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Commands.Delete;

public class DeletedSwapForCategoryAdvertResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}
