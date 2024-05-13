using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface INeighbourhoodRepository : IAsyncRepository<Neighbourhood, Guid>, IRepository<Neighbourhood, Guid> 
{
}


