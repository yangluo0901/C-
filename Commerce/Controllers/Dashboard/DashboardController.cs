using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Commerce.Controllers
{
    public class DashboardContoller : Controller
    {
        private Customer _loggedin
        {
            get{return _ccontext.customers.SingleOrDefault(c => c.customer_id  == HttpContext.Session.GetInt32("log_id"));}
        }
        private CommerceContext _ccontext;
        public DashboardContoller(CommerceContext ccontext)
        {
            _ccontext = ccontext;
        }
        [HttpGet("home")]
        public IActionResult Index()
        {
            List<Product>products = _ccontext.products.ToList();
            List<Order>orders = _ccontext.orders.Include(o => o.product)
                                                .Include(o => o.customer)
                                                .OrderByDescending(o => o.created_at)
                                                .ToList();
            List<Customer>customers = _ccontext.customers.Include(c => c.products)
                                                            .ThenInclude(p => p.product)
                                                        .OrderByDescending(c => c.created_at).ToList();
            DashboardModel model = new DashboardModel()
            {
                products = products,
                orders = orders,
                customers = customers
            };
            return View();
        }
        [HttpGet("products")]
        public IActionResult Products()
        {
            List<Product>products = _ccontext.products.ToList();
             DashboardModel model = new DashboardModel()
            {
                products = products,
            };
            return View(model);
        }
        [HttpPost("product/add")]
        public IActionResult AddProduct(DashboardModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _ccontext.products.SingleOrDefault(p => p.name == model.product.name);
                //check if product exist, if yes, just update it
                if( check == null)
                {
                    Product product = model.product;
                    _ccontext.Add(product);
                    _ccontext.SaveChanges();
                    
                }
                else
                {
                    check.quantity = model.product.quantity;
                    check.price = model.product.price;
                    check.updated_at = DateTime.Now;
                    _ccontext.SaveChanges();
                }
                return RedirectToAction("Products");
            }
            return View("Products",model);
        }
        [HttpGet("orders")]
        public IActionResult Orders()
        {
            List<Order>orders = _ccontext.orders.Include(o => o.product)
                                                .Include(o => o.customer)
                                                .OrderByDescending(o => o.created_at)
                                                .ToList();
            List<Customer>customers = _ccontext.customers.Include(c => c.products)
                                                            .ThenInclude(p => p.product)
                                                        .OrderByDescending(c => c.created_at).ToList();
            List<Product>products = _ccontext.products.ToList();
            DashboardModel model = new DashboardModel()
            {
                products = products,
                orders = orders,
                customers = customers
            };
            return View(model);
        }
        [HttpPost("order/add")]
        public IActionResult AddOrder(DashboardModel model)
        {
            Order order = model.order;
            _ccontext.Add(order);
            _ccontext.SaveChanges();
            return RedirectToAction("Orders");
        }
        [HttpGet("customers")]
        public IActionResult Customers()
        {
            List<Customer>customers = _ccontext.customers.Include(c => c.products)
                                                            .ThenInclude(p => p.product)
                                                        .OrderByDescending(c => c.created_at).ToList();
            DashboardModel model = new DashboardModel()
            {
                customers = customers
            };
            return View(model);
        }
        [HttpPost("customers/add")]
        public IActionResult AddCustomer(DashboardModel model)
        {
            if (_loggedin != null)
            {
                if(ModelState.IsValid)
                {
                     Customer newcustomer = model.customer;
                     _ccontext.Add(newcustomer);
                     _ccontext.SaveChanges();
                }
               
                    return View("Customers",model);
                
            }
            else
            {
                return RedirectToAction("Home");
            }
            
        }
       
    }
}
