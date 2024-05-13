using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ISwapForProductAdvertRepository : IAsyncRepository<SwapForProductAdvert, Guid>, IRepository<SwapForProductAdvert, Guid>
{
}
