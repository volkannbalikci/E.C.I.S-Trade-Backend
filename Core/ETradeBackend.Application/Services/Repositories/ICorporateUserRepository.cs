using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICorporateUserRepository : IAsyncRepository<CorporateUser, Guid>, IRepository<CorporateUser, Guid>
{
}

