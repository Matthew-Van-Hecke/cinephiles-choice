using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoiceAPI.Models
{
    public class Moviegoer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AnswerToSecurityQuestion { get; set; }
        public string IdentityUserId { get; set; }
    }
}
