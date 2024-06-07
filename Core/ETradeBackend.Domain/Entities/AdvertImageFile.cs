using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class AdvertImageFile : File
{
    public Guid AdvertId { get; set; }               
    public bool Showcase { get; set; }

    public virtual Advert Advert { get; set; }
}
