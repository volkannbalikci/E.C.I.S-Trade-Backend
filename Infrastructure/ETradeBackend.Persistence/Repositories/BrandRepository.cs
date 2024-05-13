using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class BrandRepository : EfRepositoryBase<Brand, Guid, ETradeBackendContext>, IBrandRepository
{
    public BrandRepository(ETradeBackendContext context) : base(context)
    {
    }
}
