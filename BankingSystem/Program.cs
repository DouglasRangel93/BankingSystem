using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int pin = 2521, option, enteredPin = 0, count = 0, amount = 1;
        float balance = 5850;
        int continueTransaction = 1;

        Console.WriteLine("\n\t\t******************WELCOME BAKING SYSTEM*******************");

        while (pin != enteredPin)
        {
            Console.Write("\nPlease enter your pin: ");
            if (!int.TryParse(Console.ReadLine(), out enteredPin) || enteredPin != pin)
            {
                Console.Beep(500, 450);
                Console.WriteLine("Invalid pin!!!");
            }

            count++;

            if (count == 3 && pin != enteredPin)
            {
                Environment.Exit(0);
            }
        }

        while (continueTransaction != 0)
        {
            Console.WriteLine("\n\t\t\t*************Available Transaction************");
            Console.WriteLine("\n\t\t1. Withdraw");
            Console.WriteLine("\t\t2. Deposit");
            Console.WriteLine("\t\t3. Check Balance");
            Console.Write("\n\t\tPlease select an option: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.Beep(500, 450);
                Console.WriteLine("\nInvalid Option!!!");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("\n\t\tEnter the amount: ");
                    if (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                    {
                        Console.WriteLine("\nInvalid amount!!!");
                        amount = 1;
                        break;
                    }

                    if (balance < amount)
                    {
                        Console.WriteLine("\nSorry, insufficient balance");
                        amount = 1;
                    }
                    else
                    {
                        balance -= amount;
                        Console.WriteLine($"\n\t\tYou have withdrawn R${amount}. Your new balance is {balance:C}");
                        amount = 1;
                    }
                    break;

                case 2:
                    Console.Write("\n\t\tPlease enter the amount: ");
                    if (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                    {
                        Console.WriteLine("\nInvalid amount!!!");
                        amount = 1;
                        break;
                    }

                    balance += amount;
                    Console.WriteLine($"\n\t\tYou have deposited Rs.{amount}. Your new balance is {balance:C}");
                    Console.WriteLine("\n\t\t****************** Thank you for banking system******************");
                    amount = 1;
                    break;

                case 3:
                    Console.WriteLine($"\n\t\tYour balance is {balance:C}");
                    break;

                default:
                    Console.Beep(500, 450);
                    Console.WriteLine("\n\t\tInvalid Option!!!");
                    break;
            }

            Console.Write("\n\t\tDo you wish to perform another transaction? Press 1[Yes], 0[No]: ");
            if (!int.TryParse(Console.ReadLine(), out continueTransaction) || (continueTransaction != 0 && continueTransaction != 1))
            {
                Console.WriteLine("\nInvalid choice! Exiting...");
                Thread.Sleep(1000); // Sleep for a second before exiting
                Environment.Exit(0);
            }
        }
    }
}
