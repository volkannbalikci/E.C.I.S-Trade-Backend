using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CorporateAdvertOrderItemRepository : EfRepositoryBase<CorporateAdvertOrderItem, Guid, ETradeBackendContext>, ICorporateAdvertOrderItemRepository
{
    public CorporateAdvertOrderItemRepository(ETradeBackendContext context) : base(context)
    {
    }
}

