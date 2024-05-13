using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CityRepository : EfRepositoryBase<City, Guid, ETradeBackendContext>, ICityRepository
{
    public CityRepository(ETradeBackendContext context) : base(context)
    {
    }
}
