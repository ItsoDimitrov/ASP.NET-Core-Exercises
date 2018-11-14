using Microsoft.AspNetCore.Identity;
using System;

namespace Chushka.Models
{
    public class ChushkaUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}
