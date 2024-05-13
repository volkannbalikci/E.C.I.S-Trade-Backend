using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForProductAdverts.Queries.GetList;

public class GetListSwapForProductAdvertListItemDto
{
    public Guid SwapForProductAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public Guid AddressId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }

    public Guid AdvertProductId { get; set; }
    public string AdvertProductName { get; set; }
    public Guid AdvertsProductBrandId { get; set; }
    public string AdvertsProductBrandName { get; set; }
    public Guid AdvertsProductCategoryId { get; set; }
    public string AdvertsProductCategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid IndividualUserId { get; set; }
    public Guid IndividualUserUserId { get; set; }
    public string IndividualUserFirstName { get; set; }
    public string IndividualUserLastName { get; set; }
    public string IndividualUserUserName { get; set; }

    public Guid DesiredProductId { get; set; }
    public string DesiredProductName { get; set; }
    public Guid DesiredProductBrandId { get; set; }
    public string DesiredProductBrandName { get; set; }
    public Guid DesiredProductCategoryId { get; set; }
    public string DesiredProductCategoryName { get; set; }
}
