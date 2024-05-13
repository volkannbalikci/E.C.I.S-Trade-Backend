using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IAdvertRepository : IAsyncRepository<Advert, Guid>, IRepository<Advert, Guid>
{
}

