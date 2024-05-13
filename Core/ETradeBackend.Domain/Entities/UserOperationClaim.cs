using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class UserOperationClaim : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    public virtual User? User { get; set; }
    public virtual OperationClaim? OperationClaim { get; set; }
}
