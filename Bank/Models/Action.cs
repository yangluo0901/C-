using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Action
    {
        [Key]
        public int action_id {get;set;}
        [Required]
        public int amount {get;set;}
        public Person user{get;set;}
    }
}