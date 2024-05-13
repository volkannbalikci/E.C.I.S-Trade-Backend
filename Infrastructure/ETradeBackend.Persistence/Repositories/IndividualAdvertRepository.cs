using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;

namespace ETradeBackend.Persistence.Repositories;

public class IndividualAdvertRepository : EfRepositoryBase<IndividualAdvert, Guid, ETradeBackendContext>, IIndividualAdvertRepository
{
    public IndividualAdvertRepository(ETradeBackendContext context) : base(context)
    {
    }
}

