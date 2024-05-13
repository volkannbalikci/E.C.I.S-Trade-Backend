using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class CorporateAdvert : EntityBase<Guid>
{
    public Guid AdvertId { get; set; }
    public Guid CorporateUserId { get; set; }
    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }

    public virtual ICollection<CorporateAdvertOrderItem>? CorporateAdvertOrderItems { get; set; }
    public virtual Advert? Advert { get; set; }
    public virtual CorporateUser? CorporateUser { get; set; }

}
