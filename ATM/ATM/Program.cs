using System;

namespace ATM
{
    public class Program
    {
        public static decimal balance = 0;
        static void Main()
        {
            try
            {
                StartTransaction();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something did not work correctly:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thanks for using the Bank of Andrew.");
            }
        }
        
        static void StartTransaction()
        {
            Console.WriteLine("Welcome to the Bank of Andrew");
            Boolean running = true;
            while (running)
            {

                try
                {
                    // Present options to user
                    Console.WriteLine();
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. View Balance");
                    Console.WriteLine("2. Withdraw Money");
                    Console.WriteLine("3. Add Money");
                    Console.WriteLine("4. Exit");

                    string userOptionInput = Console.ReadLine();

                    if (userOptionInput == "1")
                    {
                        ViewBalance();
                    }
                    else if (userOptionInput == "2")
                    {
                        Console.WriteLine("Enter withdrawal amount:");
                        string userWithdrawlInput = Console.ReadLine();
                        decimal userWithdrawlAmount = Convert.ToDecimal(userWithdrawlInput);
                        WithdrawMoney(userWithdrawlAmount);
                    }
                    else if (userOptionInput == "3")
                    {
                        Console.WriteLine("Enter amount to add:");
                        string userAddInput = Console.ReadLine();
                        decimal userAddAmount = Convert.ToDecimal(userAddInput);
                        AddMoney(userAddAmount);
                    }
                    else if (userOptionInput == "4")
                    {
                        Console.WriteLine("Now Exiting...");
                        running = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please type a number corresponding to one of the options.");
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine("Format exception:");
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Overflow exception:");
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static decimal ViewBalance()
        {
            Console.WriteLine($"Your balance is: ${balance}");
            return balance;
        }
        public static void WithdrawMoney(decimal amount)
        {
            if(balance < 0)
            {
                throw new Exception("Negative balance found, cannot withdraw.");
            }
            else if(amount > balance)
            {
                Console.WriteLine("You have insufficient funds to withdraw that amount.");
            }
            else if(amount < 0)
            {
                Console.WriteLine("Cannot withdraw negative amount. Consider adding money instead");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful");
                ViewBalance();
            }
            
        }
        public static decimal AddMoney(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Cannot add negative amount. Consider doing a withdrawal instead.");
                return balance;
            }
            else
            {
                balance += amount;
                Console.WriteLine("Adding money successful");
                ViewBalance();
                return balance;
            }
        }
    }
}
