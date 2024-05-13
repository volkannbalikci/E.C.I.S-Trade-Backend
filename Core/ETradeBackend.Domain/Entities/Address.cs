using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Address : EntityBase<Guid>
{
    public Guid CountryId { get; set; }
    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }
    public Guid NeighbourhoodId { get; set; }
    public string PostalCode { get; set; }
    public string AddressDetails { get; set; }

    public virtual ICollection<Advert>? Adverts { get; set; }
    public virtual ICollection<UserAddress>? UserAddresses { get; set; }
    public virtual Country Country { get; set; }
    public virtual City? City { get; set; }
    public virtual District? District { get; set; }
    public virtual Neighbourhood? Neighbourhood { get; set; }
}
