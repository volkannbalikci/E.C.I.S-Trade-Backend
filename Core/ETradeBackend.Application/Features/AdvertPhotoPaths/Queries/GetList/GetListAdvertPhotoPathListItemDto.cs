using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Queries.GetList;

public class GetListAdvertPhotoPathListItemDto
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }
}
