using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class UserAddress : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public bool IsMain { get; set; }

    public virtual User? User { get; set; }
    public virtual Address? Address { get; set; }
    public virtual ICollection<CorporateAdvertOrder>? CorporateAdvertOrders  {get; set; }
}
