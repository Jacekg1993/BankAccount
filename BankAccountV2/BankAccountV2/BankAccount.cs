using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountV2
{
    class BankAccount
    {
        public string Number { get; }
        public string OwnerName { get; set; }
        private static int accountNumberSeed = 1234567890;
        public List<Transaction> allTransactions = new List<Transaction>();
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (Transaction item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }

        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            Transaction deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new ArgumentOutOfRangeException("Not sufficient funds for this withdrawal");
            }
            Transaction Withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(Withdrawal);
        }

        public string GetAccountHistory()
        {
            StringBuilder report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.OwnerName = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

        }
    }
}
