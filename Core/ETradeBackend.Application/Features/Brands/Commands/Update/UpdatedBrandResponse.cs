using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Brands.Commands.Update;

public class UpdatedBrandResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string WebsiteUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
