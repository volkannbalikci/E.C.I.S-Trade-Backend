using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IBrandRepository : IAsyncRepository<Brand, Guid>, IRepository<Brand, Guid>
{
}

