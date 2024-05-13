using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ISwapForCategoryAdvertRepository : IAsyncRepository<SwapForCategoryAdvert, Guid>, IRepository<SwapForCategoryAdvert, Guid>
{
}
