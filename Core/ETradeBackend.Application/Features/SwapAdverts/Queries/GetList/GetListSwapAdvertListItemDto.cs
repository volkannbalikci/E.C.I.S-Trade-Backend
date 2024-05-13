using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapAdverts.Queries.GetList;

public class GetListSwapAdvertListItemDto
{
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public Guid AddressId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }

    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid IndividualUserId { get; set; }
    public Guid IndividualUserUserId { get; set; }
    public string IndividualUserFirstName { get; set; }
    public string IndividualUserLastName { get; set; }
    public string IndividualUserUserName { get; set; }
}
