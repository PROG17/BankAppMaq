using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Repositories
{
    public class BankRepository: IBankRepositiry
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

    }

    public interface IBankRepositiry
    {
        List<Customer> Customers { get; set; }
    }
}
