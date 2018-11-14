using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Account
    {
        public int CustomerNumber { get; set; }

        public int AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public bool Transfer(Account account, decimal amount)
        {
            if (amount > 0 && account != null && Balance >= amount)
            {
                Balance -= amount;
                account.Balance += amount;
                return true;
            }

            return false;
        }
    }
}
