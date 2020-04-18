using System;
using Bank.Entities;
using Bank.Entities.Exceptions;
using System.Globalization;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Holder: ");
                string holder = Console.ReadLine();

                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());

                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine());

                Account account = new Account(number, holder, balance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine());

                account.Withdraw(amount);

                Console.WriteLine(account);
            }

            catch (DomainException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }

            catch (FormatException e)
            {
                Console.WriteLine();
                Console.WriteLine("Format error: " + e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Unexpected error: " + e.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Bye bye!");
            }
        }
    }
}
