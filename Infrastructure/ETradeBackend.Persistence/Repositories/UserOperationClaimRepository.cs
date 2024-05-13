using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, Guid, ETradeBackendContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(ETradeBackendContext context) : base(context)
    {
    }
}

