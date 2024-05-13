using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Commands.Create;

public class CreatedCorporateAdvertOrderItemResponse
{
    public Guid CorporateAdvertOrderId { get; set; }
    public Guid AdvertId { get; set; }
    public int Amount { get; set; }
    public decimal BoughtPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
