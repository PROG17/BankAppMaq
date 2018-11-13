using BankApp.Models;
using BankApp.Repositories;
using BankApp.ViewModels;
using System;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        private readonly BankRepository bank;
        private readonly Account account;

        public UnitTest1()
        {
            account = new Account() { AccountNumber = 900, Balance = 200 };
            bank = new BankRepository();
            bank.Accounts.Add(account);
        }

        [Theory]
        [InlineData(900, false)]
        [InlineData(-100, false)]
        [InlineData(100, true)]
        public void Withdrawl_Amount_ReturnTrueOrFalse(decimal amount, bool expected) 
        {
            // arrange
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };

            // act
            var actual = bank.Withdrawl(vm);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(900, 200)]
        [InlineData(100, 100)]
        [InlineData(-100, 200)]
        public void Withdrawl_Amount_CheckBalance(decimal amount, decimal expected)
        {
            // arrange
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };

            // act
            bank.Withdrawl(vm);

            var actual = vm.Account.Balance; 

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(900, 1100)]
        [InlineData(100, 300)]
        [InlineData(-100, 200)]
        public void Contribution_Amount_CheckBalance(decimal amount, decimal expected)
        {
            // arrange
            var vm = new BankViewModel() { Account = account, AmountToTransfer = amount };

            // act
            bank.Contribution(vm);
            var actual = vm.Account.Balance;

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
