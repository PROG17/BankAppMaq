using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class TransferController : Controller
    {
        private readonly IBankRepository bankRepository;

        public TransferController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }
        public IActionResult Index()
        {
            return View(new TransferViewModel());
        }

        public IActionResult Transfer(int from, int to, decimal amount)
        {
            var toAcc = bankRepository.Accounts.FirstOrDefault(x => x.AccountNumber == to);
            var fromAcc = toAcc != null ? bankRepository.Accounts.FirstOrDefault(x => x.AccountNumber == from)?.Transfer(toAcc, amount) : null;
            if (fromAcc == null)
            {
                ViewData["Message"] = "Please enter valid Accountnumbers";
            }
            else if(fromAcc == false)
            {
                ViewData["Message"] = $"There not enough funds in account {from}";
            }
            else
            {
                ViewData["Message"] = $"{amount} was transfered from account {from} to account {to}";

            }
            return View("Index", new TransferViewModel());
        }
    }
}