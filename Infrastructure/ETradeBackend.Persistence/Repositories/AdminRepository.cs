using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class AdminRepository : EfRepositoryBase<Admin, Guid, ETradeBackendContext>, IAdminRepository
{
    public AdminRepository(ETradeBackendContext context) : base(context)
    {
    }
}
