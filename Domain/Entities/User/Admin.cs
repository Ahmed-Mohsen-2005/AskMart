using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class Admin : ApplicationUser

    {
        public AdminType newRole;
    }
}
//editor or CEO