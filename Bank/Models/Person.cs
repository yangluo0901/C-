using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Bank.Models
{
    public class Person
    {
        
        [Key]
        public int user_id{get;set;}
        public string first_name {get;set;}
        
        public string last_name {get;set;}
    
        public string email{get;set;}
    
        public string password{get;set;}

        public int balance {get;set;}

        public List<Action> actions {get;set;}

        public Person(){
            List<Action> actions =  new List<Action>();
        }
    }
}