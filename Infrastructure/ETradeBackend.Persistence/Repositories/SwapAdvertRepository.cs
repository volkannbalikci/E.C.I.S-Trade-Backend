using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class SwapAdvertRepository : EfRepositoryBase<SwapAdvert, Guid, ETradeBackendContext>, ISwapAdvertRepository
{
    public SwapAdvertRepository(ETradeBackendContext context) : base(context)
    {
    }
}

