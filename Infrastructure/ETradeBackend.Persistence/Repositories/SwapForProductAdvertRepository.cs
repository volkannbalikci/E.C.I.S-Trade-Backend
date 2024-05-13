using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class SwapForProductAdvertRepository : EfRepositoryBase<SwapForProductAdvert, Guid, ETradeBackendContext>, ISwapForProductAdvertRepository
{
    public SwapForProductAdvertRepository(ETradeBackendContext context) : base(context)
    {
    }
}

