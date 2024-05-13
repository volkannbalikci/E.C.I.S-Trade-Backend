using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class SwapForCategoryAdvertRepository : EfRepositoryBase<SwapForCategoryAdvert, Guid, ETradeBackendContext>, ISwapForCategoryAdvertRepository
{
    public SwapForCategoryAdvertRepository(ETradeBackendContext context) : base(context)
    {
    }
}

