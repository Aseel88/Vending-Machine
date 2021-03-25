using System;
namespace VendingMachine
{
    public class BankAccount
    {
        public int balance = 1000;

        public int Withdraw(int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                return balance;
            }

            return 0;
        }
    }
}