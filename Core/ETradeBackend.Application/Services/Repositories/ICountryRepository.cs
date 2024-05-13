using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICountryRepository : IAsyncRepository<Country, Guid>, IRepository<Country, Guid>
{
}

