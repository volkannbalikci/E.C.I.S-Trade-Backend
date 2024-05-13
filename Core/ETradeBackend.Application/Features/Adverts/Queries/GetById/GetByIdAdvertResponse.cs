using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Adverts.Queries.GetById;

public class GetByIdAdvertResponse
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }
    public string ProductName { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
