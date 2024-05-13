using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Brand : EntityBase<Guid>
{
    public string Name { get; set; }
    public string WebsiteUrl { get; set; }

    public virtual ICollection<Product>? Products { get; }
}
