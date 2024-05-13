using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Neighbourhood : EntityBase<Guid>
{
    public Guid DistrictId { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Address>? Addresses { get; }
    public virtual District? District{ get; set; }
}
