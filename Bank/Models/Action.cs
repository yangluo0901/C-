using System;
using System.ComponentModel.DataAnnotations;

namespace Bank.Models
{
    public class Action
    {
        [Key]
        public int action_id {get;set;}
        [Required]
        public int amount {get;set;}
        
        public int user_id{get;set;}
        public Person user{get;set;}

        public DateTime created_at {get;set;}

        public Action()
        {
            created_at = DateTime.Now;
        }
    }
}   