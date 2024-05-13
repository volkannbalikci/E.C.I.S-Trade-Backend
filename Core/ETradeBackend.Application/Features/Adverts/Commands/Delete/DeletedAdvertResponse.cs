using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Commands.Delete;

public class DeletedAdvertResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}
