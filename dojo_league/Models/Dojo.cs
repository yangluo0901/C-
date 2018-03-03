using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace dojo_league.Models
{
    public class Dojo
    {
        [Key]
        public int dojo_id {get;set;}
        [Required]
        public string name{get;set;}
        [Required]
        public string location {get;set;}
        public string info {get;set;}
        public List<Ninja> ninjas {get;set;}
         public Dojo()
        {
            ninjas = new List<Ninja>();
        }
    }
}