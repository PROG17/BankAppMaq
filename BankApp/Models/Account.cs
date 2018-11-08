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
    }
}
