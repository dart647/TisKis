using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TisKis.Models
{
    public class User : IdentityUser
    {
        public List<UserHistory> UserHistories { get; set; }
    }
}
