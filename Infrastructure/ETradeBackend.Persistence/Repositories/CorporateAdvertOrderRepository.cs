using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CorporateAdvertOrderRepository : EfRepositoryBase<CorporateAdvertOrder, Guid, ETradeBackendContext>, ICorporateAdvertOrderRepository
{
    public CorporateAdvertOrderRepository(ETradeBackendContext context) : base(context)
    {
    }
}

