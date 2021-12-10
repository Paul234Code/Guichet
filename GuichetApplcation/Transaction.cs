using System;

namespace Guichet
{
    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        // Le constructeur de la classe Transaction
        public Transaction(decimal Amount, DateTime Date, string Notes)
        {
            this.Amount = Amount;
            this.Date = Date;
            this.Notes = Notes; 
        }
    }
}
