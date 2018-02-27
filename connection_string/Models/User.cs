using System.ComponentModel.DataAnnotations;

namespace connection_string.Models {
    public class User {
    
         [Required]
        public int id { get; set; }

        [Required]
        [MinLength (2)]
        public string first_name { get; set; }

        [Required]
        [MinLength (2)]
        public string last_name { get; set; }

        [EmailAddress]
        [Required]
        public string email { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string password { get; set; }

        [Compare ("password")]
        [DataType (DataType.Password)]
        [Required]
        public string confirm { get; set; }
    }
}