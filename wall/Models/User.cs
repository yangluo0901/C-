using System.ComponentModel.DataAnnotations;

namespace wall.Models
{
    public class RegUser
    {
        [Required]
        [MinLength(2, ErrorMessage="Name should be at least 2 characters !")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name should be all letters !")]
        public string first_name {get;set;}

        [Required]
        [MinLength(2, ErrorMessage="Name should be at least 2 characters !")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage="Name should be all letters !")]
        public string last_name {get;set;}

        [EmailAddress]
        [Required]
        public string email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters !")]
        public string password {get;set;}

    }
    public class LoginUser
    {
        [EmailAddress]
        [Required]
        public string loginemail {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password should be at least 8 characters !")]
        public string loginpassword {get;set;}
    }
}