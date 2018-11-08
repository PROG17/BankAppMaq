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

        [Theory]
        [InlineData(900, 200)]
        [InlineData(100, 100)]
        public void Withdrawl_Amount_CheckBalance(decimal amount, decimal expected)
        {
            // arrange
            var account = new Account() { Balance = 200 };
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };
            var bank = new BankRepository();

            // act
            bank.Withdrawl(vm);

            var actual = vm.Account.Balance; 

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(900, 1100)]
        [InlineData(100, 300)]
        public void Contribution_Amount_CheckBalance(decimal amount, decimal expected)
        {
            // arrange
            var account = new Account() { Balance = 200 };
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };
            var bank = new BankRepository();

            // act
            bank.Contribution(vm);
            var actual = vm.Account.Balance;

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
