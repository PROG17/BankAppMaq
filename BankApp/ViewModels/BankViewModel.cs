using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels
{
    public class BankViewModel
    {
        public Customer Customer { get; set; }

        public Account Account { get; set; }

        public string Message { get; set; }

        public decimal AmountToTransfer { get; set; }

        public bool TransferOk { get; set; }
    }
}
