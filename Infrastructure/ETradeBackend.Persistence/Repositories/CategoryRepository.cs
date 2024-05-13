using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CategoryRepository : EfRepositoryBase<Category, Guid, ETradeBackendContext>, ICategoryRepository
{
    public CategoryRepository(ETradeBackendContext context) : base(context)
    {
    }
}
