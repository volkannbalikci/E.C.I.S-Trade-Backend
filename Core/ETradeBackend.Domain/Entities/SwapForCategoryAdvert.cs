using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class SwapForCategoryAdvert : EntityBase<Guid>
{
    public Guid SwapAdvertId { get; set; }
    public Guid DesiredCategoryId { get; set; }

    public virtual SwapAdvert? SwapAdvert { get; set; }
    public virtual Category? DesiredCategory { get; set; }
}
