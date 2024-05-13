using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class IndividualUserRepository : EfRepositoryBase<IndividualUser, Guid, ETradeBackendContext>, IIndividualUserRepository
{
    public IndividualUserRepository(ETradeBackendContext context) : base(context)
    {
    }
}

