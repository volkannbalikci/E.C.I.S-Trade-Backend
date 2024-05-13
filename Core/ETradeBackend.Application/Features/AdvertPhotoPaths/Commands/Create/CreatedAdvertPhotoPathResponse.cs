using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Application.Features.AdvertPhotoPaths.Commands.Create;

public class CreatedAdvertPhotoPathResponse
{
    public Guid Id { get; set; }
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }
    public DateTime CreatedDate { get; set; }
}
