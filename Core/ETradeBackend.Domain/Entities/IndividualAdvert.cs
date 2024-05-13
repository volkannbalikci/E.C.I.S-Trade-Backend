using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class IndividualAdvert : EntityBase<Guid>
{
    public Guid AdvertId { get; set; }
    public Guid IndividualUserId { get; set; }
    public decimal Price { get; set; }
    public bool Bargain { get; set; }

    public virtual Advert? Advert { get; set; }
    public virtual IndividualUser? IndividualUser { get; set; }
}
