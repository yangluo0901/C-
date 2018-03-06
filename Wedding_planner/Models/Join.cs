using System;
using System.ComponentModel.DataAnnotations;
using Wedding_planner.Models;

namespace Wedding_planner.Models
{
    public class Join
    {
        [Key]
        public int join_id {get;set;}
        public int wedding_id {get;set;}
        public Wedding wedding {get;set;}
        public int attendantee_id {get;set;}
        public Person attendantee {get;set;}
        public DateTime created_at{get;set;}
        public Join ()
        {
            created_at = DateTime.Now;
        }
    }
}