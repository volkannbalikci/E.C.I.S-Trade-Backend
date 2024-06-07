using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertImageFiles.Queries.GetList;

public class GetListAdvertImageFileListItemDto
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string Path { get; set; }
    public string FileName { get; set; }
}
