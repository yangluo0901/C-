using System.ComponentModel.DataAnnotations;
using restauranter.Models;
namespace restauranter.Models
{
    public class View
    {
        [Key]
        public int view_id {get;set;}
        [Required]
        [MinLength(10)]
        public string content {get;set;}
        [Required]
        public string rest_name {get;set;}
        [Required]
       
        public int user_name{get;set;}
        // [PastDateAtrribute]
        public string created_at{set;get;}
        public string updated_at{set;get;}

    }
}