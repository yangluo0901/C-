using System.ComponentModel.DataAnnotations;
namespace form_submission.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        public string first_name{set;get;}
        [Required]
        [MinLength(2)]
        public string last_name{set;get;}
        [RegularExpression(@"^[0-9]{1,3}$")]
        public int age{set;get;}
        [EmailAddress]
        [Required]
        public string email{set;get;}
        [Required]
        public string password{set;get;}

    }
}