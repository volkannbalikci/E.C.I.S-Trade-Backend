using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Queries.GetById;

public class GetByIdNeighbourhoodResponse
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string Name { get; set; }
}
