using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class District : EntityBase<Guid>
{
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Address>? Addresses { get; set; }
    public virtual ICollection<Neighbourhood>? Neighbourhoods { get; set; }
    public virtual City? City { get; set; }
}
