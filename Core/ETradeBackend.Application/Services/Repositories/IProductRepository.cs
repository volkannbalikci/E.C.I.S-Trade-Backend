using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IProductRepository : IAsyncRepository<Product, Guid>, IRepository<Product, Guid>
{
}

