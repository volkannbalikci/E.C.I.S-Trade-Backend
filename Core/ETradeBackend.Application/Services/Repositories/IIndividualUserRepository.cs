using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Application.Services.Repositories;

public interface IIndividualUserRepository : IAsyncRepository<IndividualUser, Guid>, IRepository<IndividualUser, Guid>
{
}

