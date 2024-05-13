using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class CorporateUserRepository : EfRepositoryBase<CorporateUser, Guid, ETradeBackendContext>, ICorporateUserRepository
{
    public CorporateUserRepository(ETradeBackendContext context) : base(context)
    {
    }
}
