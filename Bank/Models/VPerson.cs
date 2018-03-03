using System.ComponentModel.DataAnnotations;
namespace Bank.Models
{
    public class VGPerson
    {
        [Required]
        [MinLength(2)]
        public string first_name {get;set;}
        [Required]
        [MinLength(2)]
        public string last_name {get;set;}
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm{get;set;}
    }

    public class VLPerson
    {
       
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
       
    }
}