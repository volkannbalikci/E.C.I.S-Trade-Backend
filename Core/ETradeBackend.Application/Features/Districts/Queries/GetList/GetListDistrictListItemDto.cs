using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Districts.Queries.GetList;

public class GetListDistrictListItemDto
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
}
