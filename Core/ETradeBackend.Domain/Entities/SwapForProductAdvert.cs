using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class SwapForProductAdvert : EntityBase<Guid>
{
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredProductId { get; set; }

    public virtual Product? DesiredProduct { get; set; }
    public virtual SwapAdvert? SwapAdvert { get; set; }
}
