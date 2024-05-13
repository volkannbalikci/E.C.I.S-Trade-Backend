using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Commands.Delete;

public class DeletedAdminResponse
{
    public Guid AdminId { get; set; }
    public Guid UserId { get; set; }
    public DateTime DeletedDate { get; set; }
}
