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

        public bool CheckIfAccountExists(int accountNumber)
        {
            return Accounts.Any(x => x.AccountNumber == accountNumber);
        }

        public bool Contribution(BankViewModel vm)
        {
            if(!CheckIfAccountExists(vm.Account.AccountNumber))
            {
                vm.Message = "Account number does not exist, please try again!";
                return false;
            }

            vm.Account = Accounts.SingleOrDefault(x => x.AccountNumber == vm.Account.AccountNumber);

            vm.Account.Balance = vm.Account.Balance + vm.AmountToTransfer;
            vm.Message = $"Contribution succesful! New balance = {vm.Account.Balance}";
            return true;
        }

        public bool Withdrawl(BankViewModel vm)
        {
            if (!CheckIfAccountExists(vm.Account.AccountNumber))
            {
                vm.Message = "Account number does not exist, please try again!";
                return false;
            }

            vm.Account = Accounts.SingleOrDefault(x => x.AccountNumber == vm.Account.AccountNumber);

            if (vm.Account.Balance - vm.AmountToTransfer < 0)
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
        bool CheckIfAccountExists(int accountNumber);
        bool Contribution(BankViewModel vm);
        bool Withdrawl(BankViewModel vm);
    }


}
