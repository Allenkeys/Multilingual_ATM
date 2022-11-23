using System.Text;

namespace Multilingual_ATM
{
    internal class Accounts
    {

        public string Number { get; }
        public string Pin { get; }
        public string AccountName { get; }
        private double Balance { 
            get
            {
                double balance = 360.00;
                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int _accountNumberSeed = 1234567890;
        private static int _pin = 1234;
        private List<Transactions> transactions = new List<Transactions>();


        public Accounts(string accountName)
        {
            AccountName = accountName;
            Number = _accountNumberSeed.ToString();
            Pin = _pin.ToString();
            _accountNumberSeed++;
            _pin++;
        }

        public void Withdraw(double amount, DateTime date, string statement)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cannot make a zero amount withdrawal");
            }
            else if(Balance - amount < 0)
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                Transactions withdrawal = new Transactions(-amount, date, statement);
                transactions.Add(withdrawal);
                Console.WriteLine($"Success: sum of {amount} has been withdrawn from your account");
            }
            
        }

        public void Transfer(double amount, DateTime date, string statement, string recieverAccountNumber)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Cannot make a zero amount withdrawal");  
            }
            else if (Balance - amount < 0)
            {
                Console.WriteLine("Insufficient balance...");
            }
            else
            {
                Transactions transfer = new Transactions(-amount, date, $"{statement} - transfer to: {recieverAccountNumber}");
                transactions.Add(transfer);
                Console.WriteLine($"Success: sum of {amount} has been transfered to {recieverAccountNumber}");

            }

        }

        public void Checkbalance()
        {
            Console.WriteLine($"Your current balance is: {Balance}");
        }

        public void AccountStatement()
        {
            var statement = new StringBuilder();
            statement.AppendLine("Date\t\tAmount\t\tStatement");
            foreach (var item in transactions)
            {
                statement.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t\t{item.Statement}");
            }
            Console.WriteLine(statement.ToString());
        }
    }
}
