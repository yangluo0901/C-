using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Commerce.Models
{
    public class Product
    {
        [Key]
        public int product_id {get;set;}
        public string name {get;set;}
        public float price {get;set;}
        public int quantity {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at{get;set;}
        public string description {get;set;}
        public byte[] images {get;set;}
       
        public Product ()
        {
            created_at = DateTime.Now;
        }
    }
}
