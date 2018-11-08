using BankApp.Models;
using BankApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Repositories
{
    public class BankRepository: IBankRepository
    {

        public BankRepository()
        {

            var acc1 = new Account() { AccountNumber = 11, Balance = 1500 };
            var acc2 = new Account() { AccountNumber = 12, Balance = 9500 };
            var acc3 = new Account() { AccountNumber = 21, Balance = 150000 };
            var acc4 = new Account() { AccountNumber = 22, Balance = 50000 };

            Accounts = new List<Account>()
            {
                acc1, acc2, acc3, acc4
            };

            Customers = new List<Customer>()
            {
                new Customer()
                {
                    Name ="Markus",
                    CustomerNumber = 1,
                    Accounts = new List<Account>()
                    {
                        acc1, acc2
                    }
                },
                new Customer()
                {
                    Name ="Jocke",
                    CustomerNumber = 2,
                    Accounts = new List<Account>()
                    {
                        acc3, acc4
                    }
                }

            };

        }

        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }


        public bool Contribution(BankViewModel vm)
        {

            throw new NotImplementedException();
        }

        public Account GetSingleAccount(int accountNumber)
        {
            return Accounts.SingleOrDefault(x => x.AccountNumber == accountNumber);
        }

        public bool Withdrawl(BankViewModel vm)
        {
            if(vm.Account.Balance - vm.AmountToTransfer < 0)
            {
                vm.Message = "To big amount";
                return false;
            } 

            vm.Account.Balance = vm.Account.Balance - vm.AmountToTransfer;
            vm.Message = $"Withdrawl succesful! New balance = {vm.Account.Balance}";
            return true;
        }
    }

    public interface IBankRepository
    {
        List<Customer> Customers { get; set; }
        List<Account> Accounts { get; set; }
        Account GetSingleAccount(int accountNumber);
        bool Contribution(BankViewModel vm);
        bool Withdrawl(BankViewModel vm);
    }


}
