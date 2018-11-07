using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class Customer
    {
        public string CustomerNumber { get; set; }

        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
    }
}
