using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class CorporateAdvertOrder : EntityBase<Guid>
{
    public Guid IndividualUserId { get; set; }
    public Guid UserAddressId { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public decimal TotalPrice { get; set; }

    public virtual UserAddress? UserAddress { get; set; }
    public virtual IndividualUser? IndividualUser { get; set; }
    public virtual ICollection<CorporateAdvertOrderItem> CorporateAdvertOrderItems { get; set; }
}
