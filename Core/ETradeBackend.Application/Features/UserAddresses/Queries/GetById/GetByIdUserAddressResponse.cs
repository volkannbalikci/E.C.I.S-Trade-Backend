using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Queries.GetById;

public class GetByIdUserAddressResponse
{
    public Guid UserAddressId { get; set; }
    public Guid UserId { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressPostalCode { get; set; }
    public string AddressDetails { get; set; }
    public bool UserAddressIsMain { get; set; }
}
