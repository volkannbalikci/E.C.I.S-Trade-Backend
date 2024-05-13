using ETradeBackend.Application.Features.UserAddresses.Queries.GetList;
using ETradeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Queries.GetList;

public class GetListIndividualUserListItemDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<GetListUserAddressListItemDto> UserAddresses { get; set; }
}
