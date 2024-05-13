using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ISwapAdvertRepository : IAsyncRepository<SwapAdvert, Guid>, IRepository<SwapAdvert, Guid>
{
}
