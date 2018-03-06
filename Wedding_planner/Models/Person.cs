using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Wedding_planner.Models
{
    public class Person
    {
        [Key]
        public int user_id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
    
        public string email{get;set;}
    
        public string password{get;set;}

        public DateTime created_at {get;set;}
        public List<Join> joinweddings {get;set;}
        public Person()
        {
            created_at = DateTime.Now;
        }

    }
    public class RegUser
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
    public class LogUser
    {
        [Required]
        [EmailAddress]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string password{get;set;}
       
    }
}