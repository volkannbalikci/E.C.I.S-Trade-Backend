using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IUserAddressRepository : IAsyncRepository<UserAddress, Guid>, IRepository<UserAddress, Guid>
{
}

