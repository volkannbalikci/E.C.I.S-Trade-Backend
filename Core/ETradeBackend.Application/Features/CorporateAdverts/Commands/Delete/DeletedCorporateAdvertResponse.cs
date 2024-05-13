using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Commands.Delete;

public class DeletedCorporateAdvertResponse
{
    public Guid CorporateAdvertId { get; set; }
    public Guid AdvertId { get; set; }
    public DateTime DeletedDate { get; set; }
}
