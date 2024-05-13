using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class City : EntityBase<Guid>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Address>? Addresses { get; }
    public virtual ICollection<District>? Districts { get; }
    public virtual Country? Country { get; set; }

}
