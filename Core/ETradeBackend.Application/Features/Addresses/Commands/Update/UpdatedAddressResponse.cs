using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Addresses.Commands.Update;

public class UpdatedAddressResponse
{
    public Guid Id { get; set; }
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }
    public DateTime UpdatedDate { get; set; }
}
