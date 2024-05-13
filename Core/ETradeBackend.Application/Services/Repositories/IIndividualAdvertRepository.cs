using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IIndividualAdvertRepository : IAsyncRepository<IndividualAdvert, Guid>, IRepository<IndividualAdvert, Guid>
{
}
