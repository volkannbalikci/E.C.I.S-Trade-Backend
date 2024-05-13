using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Commands.Delete;

public class DeletedOperationClaimResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}
