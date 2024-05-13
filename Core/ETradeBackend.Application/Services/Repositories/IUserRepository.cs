using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{
}

