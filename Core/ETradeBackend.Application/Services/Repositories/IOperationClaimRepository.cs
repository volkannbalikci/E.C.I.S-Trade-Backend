using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, Guid>, IRepository<OperationClaim, Guid>
{
}

