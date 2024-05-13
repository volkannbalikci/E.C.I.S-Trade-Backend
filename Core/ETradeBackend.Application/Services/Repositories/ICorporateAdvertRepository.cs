using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface ICorporateAdvertRepository : IAsyncRepository<CorporateAdvert, Guid>, IRepository<CorporateAdvert, Guid>
{
}

