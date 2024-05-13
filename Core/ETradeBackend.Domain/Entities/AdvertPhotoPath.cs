using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class AdvertPhotoPath : EntityBase<Guid>
{
    public Guid AdvertId { get; set; }
    public string PhotoPath { get; set; }
    public bool IsMain { get; set; }

    public virtual Advert? Advert { get; set; }
}
