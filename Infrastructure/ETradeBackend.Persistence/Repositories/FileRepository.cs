using ETradeBackend.Application.Services.Repositories;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;
using Framework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Persistence.Repositories
{
    public class FileRepository : EfRepositoryBase<Domain.Entities.File, Guid, ETradeBackendContext>, IFileRepository
    {
        public FileRepository(ETradeBackendContext context) : base(context)
        {
        }
    }
}
