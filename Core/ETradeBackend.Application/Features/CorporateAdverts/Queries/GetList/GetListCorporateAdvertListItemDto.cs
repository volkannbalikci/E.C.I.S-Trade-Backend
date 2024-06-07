using ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;
using ETradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Queries.GetList;

public class GetListCorporateAdvertListItemDto
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

    public List<GetListAdvertImageFileListItemDto> Images { get; set; }  
}
