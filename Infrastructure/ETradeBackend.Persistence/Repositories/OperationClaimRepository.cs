using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, Guid, ETradeBackendContext>, IOperationClaimRepository
{
    public OperationClaimRepository(ETradeBackendContext context) : base(context)
    {
    }
}

