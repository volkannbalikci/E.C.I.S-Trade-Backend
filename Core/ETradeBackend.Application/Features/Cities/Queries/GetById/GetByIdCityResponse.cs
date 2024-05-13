using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Cities.Queries.GetById;

public class GetByIdCityResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }
    public string CountryShortName { get; set; }
}
