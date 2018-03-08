using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Models
{
    public class Customer
    {
         [Key]
        public int customer_id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
    
        public string email{get;set;}
    
        public string password{get;set;}

        public DateTime created_at {get;set;}
        public List<Order> products {get;set;}
        public Customer()
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