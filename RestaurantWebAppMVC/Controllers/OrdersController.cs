using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantWebAppMVC.Data;
using RestaurantWebAppMVC.Models;

namespace RestaurantWebAppMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly RestaurantContext _context;

        public OrdersController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var restaurantContext = _context.Orders.Include(o => o.Employee);
            return View(await restaurantContext.Take(20).ToListAsync());
        }
    }
}
