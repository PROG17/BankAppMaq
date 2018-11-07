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
        private readonly IBankRepository bankRepository;

        public HomeController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var list = bankRepository.Customers;

            return View(list);
        }
    }
}