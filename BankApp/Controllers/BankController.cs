using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Repositories;
using BankApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankRepository bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            this.bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            var model = new BankViewModel() { TransferOk = true};

            return View(model);
        }

        public IActionResult Contribution(BankViewModel vm)
        {
            vm.Account = bankRepository
                .Accounts
                .SingleOrDefault(x => x.AccountNumber == vm.Account.AccountNumber);

            vm.TransferOk = bankRepository.Contribution(vm);

            return View(nameof(Index), vm);
        }

        public IActionResult Withdrawl(BankViewModel vm)
        {
            vm.Account = bankRepository
                .Accounts
                .SingleOrDefault(x => x.AccountNumber == vm.Account.AccountNumber);

            vm.TransferOk = bankRepository.Withdrawl(vm);

            return View(nameof(Index), vm);
        }
    }
}