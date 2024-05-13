using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualUsers.Commands.Delete;

public class DeletedIndividualUserResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}
