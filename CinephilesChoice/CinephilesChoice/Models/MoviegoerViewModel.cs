using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Models
{
    public class MoviegoerViewModel
    {
        public Moviegoer Moviegoer { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Dictionary<string, string> RoleManager { get; set; }
    }
}
