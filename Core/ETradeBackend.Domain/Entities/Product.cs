using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Product : EntityBase<Guid>
{
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Advert>? Adverts { get; }
    public virtual ICollection<SwapForProductAdvert>? SwapForProductAdverts{ get; }
    public virtual Brand? Brand { get; set; }
    public virtual Category? Category { get; set; }
}
