using System.Collections.Generic;

namespace Commerce.Models
{
    public class DashboardModel
    {
        public List<Product> products {get;set;}
        public List<Customer> customers {get;set;}
        public List<Order> orders {get;set;}
        public Product product{get;set;}
        public Order order {get;set;}
        public Customer customer {get;set;}
        
    }
}