using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdverts.Commands.Create;

public class CreatedCorporateAdvertResponse
{
    public Guid CorporateAdvertId { get; set; }

    public Guid AdvertId { get; set; }
    public Guid AddressId { get; set; }
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }


    public Guid CorporateUserId { get; set; }

    public decimal UnitPrice { get; set; }
    public int StockAmount { get; set; }

    public DateTime CreatedDate { get; set; }
}
