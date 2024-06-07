using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class File : EntityBase<Guid>
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
}
