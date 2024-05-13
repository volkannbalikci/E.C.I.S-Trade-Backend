using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class DistrictRepository : EfRepositoryBase<District, Guid, ETradeBackendContext>, IDistrictRepository
{
    public DistrictRepository(ETradeBackendContext context) : base(context)
    {
    }
}

