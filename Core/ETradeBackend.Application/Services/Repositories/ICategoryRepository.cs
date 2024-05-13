using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICategoryRepository : IAsyncRepository<Category, Guid>, IRepository<Category, Guid>
{
}

