using BankApp.Models;
using BankApp.Repositories;
using BankApp.ViewModels;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(900, false)]
        [InlineData(100, true)]
        public void Withdrawl_Amount_ReturnTrueOrFalse(decimal amount, bool expected) 
        {
            // arrange
            var account = new Account() { Balance = 200 };
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };
            var bank = new BankRepository();
            
            // act
            var actual = bank.Withdrawl(vm);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
