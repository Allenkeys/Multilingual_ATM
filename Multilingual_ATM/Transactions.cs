using System;

namespace Multilingual_ATM
{
    internal class Transactions
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public string Statement { get; set; }

        public Transactions(double amount, DateTime date, string statement)
        {
            Amount = amount;
            Date = date;
            Statement = statement;
        }
    }
}
