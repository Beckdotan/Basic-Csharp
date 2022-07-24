using System;

namespace MySuperBank
{

    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Dotan", 1000);
            Console.WriteLine($"Welcome {account.Owner}. Your account {account.Number} have now {account.Balance}$ ");

            account.MakeWithdrawal(120, DateTime.Now, "Hammock");

            //TIP!! cw tab tab is shortcut for Console.WriteLine();
            Console.WriteLine(account.Balance);


            account.MakeWithdrawal(120, DateTime.Now, "Food");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());

            /*
            // Test that the initial balances must be positive.
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
            */

        }
    }
}


    
