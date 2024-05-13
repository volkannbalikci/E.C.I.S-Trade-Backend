using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class IndividualUser : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<IndividualAdvert> IndividualAdverts { get; set; }
    public virtual ICollection<SwapAdvert> SwapAdverts { get; set; }
    public virtual ICollection<Advert> Adverts { get; set; }
    public virtual ICollection<CorporateAdvertOrder> CorporateAdvertOrders { get; set; }
}
