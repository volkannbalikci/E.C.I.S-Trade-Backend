using Framework.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETradeBackend.Domain.Entities;

public class Admin : EntityBase<Guid>
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ContactNumber { get; set; }
    public string RegisterNumber { get; }

    public virtual User User { get; set; }

    public Admin(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
       RegisterNumber = this.FirstName[0] + this.LastName[0] + this.FirstName.Length.ToString();
    }
}
