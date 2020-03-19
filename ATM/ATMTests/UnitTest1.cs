using System;
using Xunit;
using ATM;

namespace ATMTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestViewBalanceDoesNotChangeBalance()
        {
            Program.balance = 1000;
            Program.ViewBalance();
            Assert.True(Program.balance == 1000);
        }

        [Fact]
        public void TestWithdrawingChangesBalance()
        {
            Program.balance = 2000;
            Program.WithdrawMoney(450);
            Assert.Equal(1550, Program.balance);
        }
           
        [Fact]
        public void TestWithdrawNegativeValueDoesNotChangeBalance()
        {
            Program.balance = 3000;
            Program.WithdrawMoney(-380);
            Assert.Equal(3000, Program.balance);
        }

        [Fact]
        public void TestAddingChangesBalance()
        {
            Program.balance = 4000;
            Program.AddMoney(180);
            Assert.Equal(4180, Program.balance);
        }

        [Fact]
        public void TestAddNegativeValueDoesNotChangeBalance()
        {
            Program.balance = 3000;
            Program.AddMoney(-380);
            Assert.Equal(3000, Program.balance);
        }
    }
}
