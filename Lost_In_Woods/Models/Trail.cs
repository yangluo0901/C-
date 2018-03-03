using System.ComponentModel.DataAnnotations;

namespace Lost_In_Woods.Models
{
    public class Trail
    {
        [Required]
        public int id {get;set;}
        [Required]
        [MinLength(3)]
        public string name {get;set;}
        [Required]
        public string description {get;set;}
        [Required]
        public float length {get;set;}
        [Required]
        public float elevation {get;set;}
    }
    

}