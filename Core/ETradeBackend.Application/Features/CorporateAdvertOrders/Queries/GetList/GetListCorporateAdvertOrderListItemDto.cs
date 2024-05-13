using ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;
using ETradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrders.Queries.GetList;

public class GetListCorporateAdvertOrderListItemDto
{
    public Guid CorporateAdvertOrderId { get; set; }

    public Guid IndividualUserId { get; set; }
    public Guid IndividualUserUserId { get; set; }
    public string IndividualUserFirstName { get; set; }
    public string IndividualUserLastName { get; set; }
    public string IndividualUserUserName { get; set; }

    public Guid UserAddressId { get; set; }
    public Guid UserAddressUserId { get; set; }
    public Guid UserAddressAddressId { get; set; }
    public Guid UserAddressAddressCountryId { get; set; }
    public string UserAddressAddressCountryName { get; set; }
    public Guid UserAddressAddressCityId { get; set; }
    public string UserAddressAddressCityName { get; set; }
    public Guid UserAddressAddressDistrictId { get; set; }
    public string UserAddressAddressDistrictName { get; set; }
    public Guid UserAddressAddressNeighbourhoodId { get; set; }
    public string UserAddressAddressNeighbourhoodName { get; set; }
    public string UserAddressAddressPostalCode { get; set; }
    public string UserAddressAddressAddressDetails { get; set; }
    public bool UserAddressIsMain { get; set; }

    public List<GetListCorporateAdvertOrderItemListItemDto> OrderItems { get; set; }

    public string Description { get; set; }
    public string Code { get; set; }
    public decimal TotalPrice { get; set; }
}
