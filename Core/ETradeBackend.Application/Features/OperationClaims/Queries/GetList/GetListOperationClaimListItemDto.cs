using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.OperationClaims.Queries.GetList;

public class GetListOperationClaimListItemDto
{
    public Guid Id { get; set; }
    public string OperationClaimName { get; set; }
}
