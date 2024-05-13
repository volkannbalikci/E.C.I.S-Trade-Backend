using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Country : EntityBase<Guid>
{
    public string Name { get; set; }
    public string ShortName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<City>? Cities { get; set; }
}
