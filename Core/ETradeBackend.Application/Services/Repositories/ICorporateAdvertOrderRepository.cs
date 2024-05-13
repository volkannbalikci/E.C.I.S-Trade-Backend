using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICorporateAdvertOrderRepository : IAsyncRepository<CorporateAdvertOrder, Guid>, IRepository<CorporateAdvertOrder, Guid>
{
}
