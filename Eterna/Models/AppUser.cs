using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eterna.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength:25)]
        public string FullName { get; set; }
    }
}
