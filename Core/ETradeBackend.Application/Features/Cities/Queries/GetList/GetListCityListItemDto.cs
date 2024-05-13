using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Queries.GetList;

public class GetListCityListItemDto
{
    public Guid CityId { get; set; }
    public string CityName { get; set; }
    public Guid CountryId { get; set; }
    public string CountryName { get; set; }
    public string CountryShortName { get; set; }
}
