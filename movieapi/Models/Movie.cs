using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace movieapi.Models
{
    public class Movie
    {
        public string Name {get;set;}
        public float Rate {get;set;}
        public string Released_date{get;set;}
    }
}