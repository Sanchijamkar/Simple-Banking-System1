using System;
using System.Collections.Generic;

namespace SimpleBankingSystem
{
    class Account
    {
        public string AccountHolder { get; set; }
        public int AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public Account(string holder, int accNumber, decimal initialBalance)
        {
            AccountHolder = holder;
            AccountNumber = accNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"✅ Deposited {amount:C}. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("⚠ Deposit amount must be greater than zero.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"✅ Withdrawn {amount:C}. Remaining Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("⚠ Invalid withdrawal amount.");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"💰 Current Balance: {Balance:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 🏦 Simple Banking System ===");

            // Create a sample account
            Account account = new Account("John Doe", 1001, 1000.00m);

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        decimal deposit = Convert.ToDecimal(Console.ReadLine());
                        account.Deposit(deposit);
                        break;

                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        decimal withdraw = Convert.ToDecimal(Console.ReadLine());
                        account.Withdraw(withdraw);
                        break;

                    case "3":
                        account.ShowBalance();
                        break;

                    case "4":
                        Console.WriteLine("👋 Thank you for using Simple Banking System!");
                        return;

                    default:
                        Console.WriteLine("⚠ Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
