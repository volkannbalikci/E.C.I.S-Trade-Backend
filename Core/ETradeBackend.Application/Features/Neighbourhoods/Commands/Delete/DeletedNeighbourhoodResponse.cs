using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Commands.Delete;

public class DeletedNeighbourhoodResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}
