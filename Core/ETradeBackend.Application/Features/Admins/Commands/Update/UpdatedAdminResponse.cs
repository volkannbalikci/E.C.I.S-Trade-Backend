using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Admins.Commands.Update;

public class UpdatedAdminResponse
{
    public Guid AdminId { get; set; }
    public Guid UserId { get; set; }
    public string AdminFirstName { get; set; }
    public string AdminLastName { get; set; }
    public string AdminContactNumber { get; set; }
    public string AdminRegisterNumber { get; }

    public string UserEmail { get; set; }
    public bool UserStatus { get; set; } = true;

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
