using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IDistrictRepository : IAsyncRepository<District, Guid>, IRepository<District, Guid>
{
}


