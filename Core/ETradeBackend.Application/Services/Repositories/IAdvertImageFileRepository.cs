using ETradeBackend.Domain.Entities;
using Framework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Services.Repositories;

public interface IAdvertImageFileRepository : IAsyncRepository<AdvertImageFile, Guid>, IRepository<AdvertImageFile, Guid>
{
}
