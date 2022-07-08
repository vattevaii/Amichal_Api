using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amichal.Domain.Entities.UserRoles
{
    public class GroupAdmin : User
    {
        public string groups { get; set; } = null!;
    }
}
