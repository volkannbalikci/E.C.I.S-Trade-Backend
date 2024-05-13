using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.UserAddresses.Commands.Update;

public class UpdatedUserAddressResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid AddressId { get; set; }
    public bool IsMain { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
