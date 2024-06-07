using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Advert : EntityBase<Guid>
{
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public virtual ICollection<AdvertImageFile>? AdvertImageFiles { get; set; }
    public virtual IndividualAdvert? IndividualAdvert { get; set; }
    public virtual CorporateAdvert? CorporateAdvert { get; set; }
    public virtual SwapAdvert? SwapAdvert { get; set; }
    public virtual Address? Address { get; set; }
    public virtual Product? Product { get; set; }
}
