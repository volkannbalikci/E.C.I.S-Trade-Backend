using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class ProductRepository : EfRepositoryBase<Product, Guid, ETradeBackendContext>, IProductRepository
{
    public ProductRepository(ETradeBackendContext context) : base(context)
    {
    }
}

