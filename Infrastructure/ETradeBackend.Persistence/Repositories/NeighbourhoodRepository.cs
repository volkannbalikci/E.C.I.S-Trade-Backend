using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class NeighbourhoodRepository : EfRepositoryBase<Neighbourhood, Guid, ETradeBackendContext>, INeighbourhoodRepository
{
    public NeighbourhoodRepository(ETradeBackendContext context) : base(context)
    {
    }
}

