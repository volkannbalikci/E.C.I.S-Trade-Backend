using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Queries.GetList;

public class GetListNeighbourhoodListItemDto
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string Name { get; set; }
}
