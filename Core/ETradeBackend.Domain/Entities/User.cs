using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class User : EntityBase<Guid>
{
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; } = true;

    public virtual ICollection<UserOperationClaim>? UserOperationClaims { get; set; }
    public virtual CorporateUser? CorporateUser { get; set; }
    public virtual IndividualUser? IndividualUser { get; set; }
    public virtual Admin? Admin { get; set; }
    public virtual ICollection<UserAddress>? UserAddresses { get; set; }
}
