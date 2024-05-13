using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class CorporateUser : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string CompanyName { get; set; }
    public string TaxIdentityNumber { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<CorporateAdvert> CorporateAdverts { get; set; }

}