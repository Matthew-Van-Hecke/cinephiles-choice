using System.ComponentModel.DataAnnotations;

namespace CinephilesChoice.Models
{
    public class Moviegoer
    {
        public int Id { get; set; }
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name="Security Challenge")]
        public string AnswerToSecurityQuestion { get; set; }
        [Display(Name="User Id")]
        public string IdentityUserId { get; set; }
    }
}
