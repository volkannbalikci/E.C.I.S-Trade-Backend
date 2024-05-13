using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.SwapForCategoryAdverts.Queries.GetList;

public class GetListSwapForCategoryAdvertListItemDto
{
    public Guid SwapForCategoryAdvertId { get; set; }
    public Guid SwapAdvertId { get; set; }
    public Guid AdvertId { get; set; }

    public Guid AddressId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

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

    public Guid DesiredCategoryId { get; set; }
    public string DesiredCategoryName { get; set; }
    public string DesiredCategoryDescription { get; set; }
}
