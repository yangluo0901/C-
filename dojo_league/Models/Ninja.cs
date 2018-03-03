using System.ComponentModel.DataAnnotations;
namespace dojo_league.Models
{
    public class Ninja
    {
        [Key]
        public int ninja_id {get;set;}
        [Required]
        public string name {get;set;}
        [Range(1,11, ErrorMessage="Value for {0} must be between {1} and {2}.")]
        [Required]
        public int level {set;get;}
        [Required]
        public int dojo_id {get;set;}
        public Dojo dojo {get;set;}
        public string description{set;get;}

    }
}