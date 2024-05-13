using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICorporateAdvertOrderItemRepository : IAsyncRepository<CorporateAdvertOrderItem, Guid>, IRepository<CorporateAdvertOrderItem, Guid>
{
}
