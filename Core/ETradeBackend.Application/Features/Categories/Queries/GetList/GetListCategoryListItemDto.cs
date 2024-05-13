using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.Categories.Queries.GetList;

public class GetListCategoryListItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
