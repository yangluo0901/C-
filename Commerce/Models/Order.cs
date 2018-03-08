using System;
using System.ComponentModel.DataAnnotations;
using Commerce.Models;

namespace Commerce
{
    public class Order
    {
        [Key]
        public int order_id{get;set;}
        public int customer_id {get;set;}
        public Customer customer {get;set;}
        public int product_id {get;set;}

        public Product product{get;set;}
        public DateTime created_at {get;set;}
        public int quantity {get;set;}
        public Order()
        {
            created_at = DateTime.Now;
        }
    }
}