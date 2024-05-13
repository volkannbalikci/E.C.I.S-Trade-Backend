using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, ETradeBackendContext>, IUserRepository
{
    public UserRepository(ETradeBackendContext context) : base(context)
    {
    }
}

