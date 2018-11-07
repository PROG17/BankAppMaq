using BankApp.Models;
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
            Customers = new List<Customer>()
            {
                new Customer()
                {
                    Name ="Markus",
                    CustomerNumber = 1,
                    Accounts = new List<Account>()
                    {
                        new Account() {AccountNumber = 11, Balance = 1500},
                        new Account() {AccountNumber = 12, Balance = 9500}
                    }
                },
                new Customer()
                {
                    Name ="Jocke",
                    CustomerNumber = 2,
                    Accounts = new List<Account>()
                    {
                        new Account() {AccountNumber = 21, Balance = 150000},
                        new Account() {AccountNumber = 22, Balance = 50000}
                    }
                }

            };

        }

        public List<Customer> Customers { get; set; }

        public bool Contribution(int to, decimal amount)
        {
            throw new NotImplementedException();
        }

        public bool Withdrawl(int from, decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public interface IBankRepository
    {
        List<Customer> Customers { get; set; }
        bool Contribution(int to, decimal amount);
        bool Withdrawl(int from, decimal amount);
    }


}
