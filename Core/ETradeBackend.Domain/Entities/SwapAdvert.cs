using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class SwapAdvert : EntityBase<Guid>
{
    public Guid AdvertId { get; set; }
    public Guid IndividualUserId { get; set; }

    public virtual Advert? Advert { get; set; }
    public virtual IndividualUser? IndividualUser { get; set; }
    public virtual SwapForCategoryAdvert? SwapForCategoryAdvert { get; set; }
    public virtual SwapForProductAdvert? SwapForProductAdvert { get; set; }
}
