using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Addresses.Queries.GetListByCityId;

public class GetListByCityIdAddressListItemDto
{
    public Guid AddressId { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string CountryName { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string NeighbourhoodName { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }
}
