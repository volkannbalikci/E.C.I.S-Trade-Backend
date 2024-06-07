using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateUsers.Queries.GetList;

public class GetListCorporateUserListItemDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string CompanyName { get; set; }
    public string TaxIdentityNumber { get; set; }
    public string Email { get; set; }
}
