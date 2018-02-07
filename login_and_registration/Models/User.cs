using System.ComponentModel.DataAnnotations;
namespace login_and_registration.Models
{
    public class User
    {
        [Required]
        [Display(Name= "First Name" )]
        [MinLength(2, ErrorMessage="Name should be at least 2 characters !")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should be all letters")]
        public string first_name{get;set;}

        [Required]
        [Display(Name= "Last Name" )]
        [MinLength(2, ErrorMessage="Name should be at least 2 characters !")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name should be all letters !")]

        public string last_name{get;set;}

        [EmailAddress]
        [Display(Name= "E-mail" )]
        public string email{get;set;}


        [DataType(DataType.Password)]
        [Display(Name= "Password" )]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters !")]
        public string password{get;set;}
    }
}