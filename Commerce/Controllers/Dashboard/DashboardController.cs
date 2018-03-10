using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Commerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Commerce.Controllers
{
    public class DashboardController : Controller
    {
        private Customer _loggedin
        {
            get{return _ccontext.customers.SingleOrDefault(c => c.customer_id  == HttpContext.Session.GetInt32("log_id"));}
        }
        private IHostingEnvironment _env;
        private CommerceContext _ccontext;
        public DashboardController(CommerceContext ccontext,IHostingEnvironment env)
        {
            _ccontext = ccontext;
            _env = env;
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
            return View(model);
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
        public async Task<IActionResult> AddProduct(DashboardModel model)
        {
            if (ModelState.IsValid)
            {
                var check = _ccontext.products.SingleOrDefault(p => p.name == model.product.name);
               
            
                using(var stream = new MemoryStream())
                {
                    await model.images.CopyToAsync(stream);
                    model.product.images = stream.ToArray();
                    
                }
                
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
                    check.images = model.product.images;
                    // check.image = model.product.image;  
                    _ccontext.SaveChanges();
                }
                
                return RedirectToAction("Products");
            }
            List<Product>products = _ccontext.products.ToList();
             DashboardModel newmodel = new DashboardModel()
            {
                products = products,
            };
            return View("Products",newmodel);
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
        [HttpPost("customer/add")]
        public IActionResult AddCustomer(DashboardModel model)
        {
            // if (_loggedin != null)
            // {
                if(ModelState.IsValid)
                {
                     Customer newcustomer = new Customer()
                     {
                        first_name = model.customer.first_name,
                        last_name = model.customer.last_name,
                        email = model.customer.email,
                        password = model.customer.password
                     };
                     _ccontext.Add(newcustomer);
                     _ccontext.SaveChanges();
                     return RedirectToAction("Customers");
                }
                List<Customer>customers = _ccontext.customers.Include(c => c.products)
                                                            .ThenInclude(p => p.product)
                                                        .OrderByDescending(c => c.created_at).ToList();
                DashboardModel newmodel = new DashboardModel()
                {
                    customers = customers,
                    customer = model.customer
                };
               
                return View("Customers",newmodel);
                
            // }
            // else
            // {
            //     return RedirectToAction("Home");
            // }


            
        }
        
        [HttpGet("test")]
        public IActionResult Test()
        {
            return View();
        }
        
        [HttpPost("test/image")]
        public async Task<IActionResult> Post(DashboardModel model)
        {
           

            // full path to file in temp location
            string path = Path.Combine(_env.WebRootPath,"images");

         
              
            using (var memoryStream = new MemoryStream())
            {
                await model.images.CopyToAsync(memoryStream);
                var image = new Image()
                {
                    pic = memoryStream.ToArray(),
                };
                _ccontext.images.Add(image);
                _ccontext.SaveChanges();
            }


            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count =  "great!!!!!!!!"});
        }

        [HttpGet("test/show/image")]
        public IActionResult Show()
        {
            var image = _ccontext.images.SingleOrDefault(i => i.id == 1);
            return View(image);
        }
            
    }
            
}
