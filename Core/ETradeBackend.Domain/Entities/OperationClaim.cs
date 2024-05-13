using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class OperationClaim : EntityBase<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }
}
