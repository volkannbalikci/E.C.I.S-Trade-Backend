using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserOperationClaims.Queries.GetById;

public class GetByIdUserOperationClaimResponse
{
    public Guid UserId { get; set; }
    public string OperationClaimName { get; set; }
}
