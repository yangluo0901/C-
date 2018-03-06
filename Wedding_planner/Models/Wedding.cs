using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_planner.Models
{
    public class Wedding
    {
        [Key]
        public int wedding_id {get;set;}
        public int holder_id {get;set;}
        public Person holder {get;set;}
        public string wedder_one {get;set;}
        public string wedder_two {get;set;}
        public string address {get;set;}
        
        public List<Join> guests {get;set;}
        public DateTime date {get;set;}
        public DateTime created_at {get;set;}
        public Wedding(){
            created_at =   DateTime.Now;
        }
    }
}