using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class AdvertPhotoPathRepository : EfRepositoryBase<AdvertPhotoPath, Guid, ETradeBackendContext>, IAdvertPhotoPathRepository
{
    public AdvertPhotoPathRepository(ETradeBackendContext context) : base(context)
    {
    }
}
