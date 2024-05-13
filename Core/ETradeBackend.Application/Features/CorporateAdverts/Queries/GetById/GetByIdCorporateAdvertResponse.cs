using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Queries.GetById;

public class GetByIdCorporateAdvertResponse
{
    public Guid CorporateAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public Guid AddressId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }


    public string ProductName { get; set; }
    public string BrandName { get; set; }
    public string CategoryName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Guid CorporateUserId { get; set; }
    public Guid CorporateUserUserId { get; set; }
    public string CorporateUserCompanyName { get; set; }
    public string CorporateUserTaxIdentityNumber { get; set; }

    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }
}
