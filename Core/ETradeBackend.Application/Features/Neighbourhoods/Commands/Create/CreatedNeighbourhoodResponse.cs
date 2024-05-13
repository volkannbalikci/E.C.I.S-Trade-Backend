using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Neighbourhoods.Commands.Create;

public class CreatedNeighbourhoodResponse
{
    public Guid Id { get; set; }
    public Guid DistrictId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
