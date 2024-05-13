using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICityRepository : IAsyncRepository<City, Guid>, IRepository<City, Guid>
{
}

