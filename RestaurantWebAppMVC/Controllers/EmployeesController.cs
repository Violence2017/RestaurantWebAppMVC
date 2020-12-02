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
    public class EmployeesController : Controller
    {
        private readonly RestaurantContext _context;

        public EmployeesController(RestaurantContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.Take(20).ToListAsync());
        }
    }
}
