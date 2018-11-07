using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBankRepositiry bankRepositiry;

        public HomeController(IBankRepositiry bankRepositiry)
        {
            this.bankRepositiry = bankRepositiry;
        }

        public IActionResult Index()
        {
            var list = bankRepositiry.Customers;

            return View(list);
        }
    }
}