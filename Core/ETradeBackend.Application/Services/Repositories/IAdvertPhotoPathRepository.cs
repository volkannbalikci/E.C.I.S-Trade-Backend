using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IAdvertPhotoPathRepository : IAsyncRepository<AdvertPhotoPath, Guid>, IRepository<AdvertPhotoPath, Guid>
{
}

