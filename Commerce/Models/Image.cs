using System.ComponentModel.DataAnnotations;

namespace Commerce.Models
{
    public class Image
    {
        [Key]
        public int id {get;set;}
        public byte[] pic {get;set;}
    }
}