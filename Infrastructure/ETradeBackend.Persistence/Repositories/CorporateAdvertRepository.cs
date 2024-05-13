using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CorporateAdvertRepository : EfRepositoryBase<CorporateAdvert, Guid, ETradeBackendContext>, ICorporateAdvertRepository
{
    public CorporateAdvertRepository(ETradeBackendContext context) : base(context)
    {
    }
}

