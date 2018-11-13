using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApp.ViewModels
{
    public class TransferViewModel
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }
}
