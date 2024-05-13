using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Products.Commands.Update;

public class UpdatedProductResponse
{
    public Guid Id { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
