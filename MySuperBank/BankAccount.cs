using System;
using System.Text;

namespace MySuperBank
{
    public class BankAccount
    {
        
        //the get and set determine wethere the "user" can get the
        // value or also set it.
        // - TIP! can use prop for snippit. 
        public string Number { get; }

        public string Owner { get; set; }

        public decimal Balance {
            //thats how to write getters. 
            get
            {
                //we "conected" the transections with the balance. 
                //everyone starts with 0 in the bank.
                decimal balance = 0;
                foreach (var transaction in transactions)
                {
                    balance += transaction.Amount;
                }
                return balance;

            }
        }


        private static int accountNumberSeed = 1234567890;

        //constracting empty list of transactions. 
        private List<Transaction> transactions = new List<Transaction>();


        // **   constractor    **//   
        public BankAccount(string ownerName, decimal initBalance)
        {
            //can work with or without this. 
            Owner = ownerName;
            MakeDeposit(initBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }



        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            transactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
                //if got to here, we will not continue the finction. after exception the method stops!!!
            }
            var withdrawal = new Transaction(-amount, date, note);
            transactions.Add(withdrawal);

        }

        public string GetAccountHistory()
        {

            //more afficiant then concatenating string a lot. from System.text  
            var report = new StringBuilder();

            decimal balance = 0;

            //printing columns headers. 
            report.AppendLine("Date\t\tAmount\t\tBalance\t\tNote");
            report.AppendLine("---------------------------------------------------------");
            foreach (var item in transactions)
            {
                balance += item.Amount;
                //Adding every transection as a row. 
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}$\t\t{balance}\t\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}

