using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class CorporateAdvertOrderItem : EntityBase<Guid>
{
    public Guid CorporateAdvertOrderId { get; set; }
    public Guid CorporateAdvertId { get; set; }
    public int Amount { get; set; }
    public decimal BoughtPrice { get; set; }
    public decimal TotalPrice => Convert.ToDecimal(Amount) * BoughtPrice;

    public virtual CorporateAdvertOrder CorporateAdvertOrder { get; set; }
    public virtual CorporateAdvert CorporateAdvert { get; set; }

}
