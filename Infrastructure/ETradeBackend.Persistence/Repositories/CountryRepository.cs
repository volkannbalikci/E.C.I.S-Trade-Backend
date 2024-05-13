using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CountryRepository : EfRepositoryBase<Country, Guid, ETradeBackendContext>, ICountryRepository
{
    public CountryRepository(ETradeBackendContext context) : base(context)
    {
    }
}
