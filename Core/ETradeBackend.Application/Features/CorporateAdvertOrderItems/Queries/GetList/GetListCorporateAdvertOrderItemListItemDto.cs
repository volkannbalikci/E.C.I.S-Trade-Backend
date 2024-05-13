using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.CorporateAdvertOrderItems.Queries.GetList;

public class GetListCorporateAdvertOrderItemListItemDto
{
    public Guid CorporateAdvertOrderItemId { get; set; }
    public Guid CorporateAdvertOrderId { get; set; }
    public string AdvertTitle { get; set; }
    public string AdvertMainPhotoPath { get; set; }
    public int Amount { get; set; }
    public decimal TotalPrice { get; set; }
}
