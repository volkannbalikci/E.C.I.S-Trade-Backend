using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.IndividualAdverts.Commands.Delete;

public class DeletedIndividualAdvertResponse
{
    public Guid IndividualAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime DeletedDate { get; set; }
}
