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
        private static int AccountNumberSeed = 1111;
        public string AccountPassword;
        public List<Transaction> AllTransactions = new List<Transaction>();
        private List<BankAccountCard> AllCards = new List<BankAccountCard>();

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (Transaction item in AllTransactions)
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
            AllTransactions.Add(deposit);
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
            AllTransactions.Add(Withdrawal);
        }

        public string GetAccountHistory()
        {
            StringBuilder report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (Transaction item in AllTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public BankAccount(string name, decimal initialBalance, string accountPassword)
        {
            this.OwnerName = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");

            this.AccountPassword = accountPassword;

            this.Number = AccountNumberSeed.ToString();
            AccountNumberSeed++;

        }

        public void AddCard(string cardType, decimal funds, BankAccount bankAccount)
        {
            BankAccountCard NewCard = new BankAccountCard(cardType, funds, bankAccount);
            AllCards.Add(NewCard);
        }

        public string GetBankAccountCardList()
        {
            StringBuilder cardList = new System.Text.StringBuilder();

            cardList.AppendLine("Type\tNumber\tBalance");
            foreach(BankAccountCard card in AllCards)
            {
                cardList.AppendLine($"{card.CardType}\t{card.CardNumber}\t{card.CardBalance}");
            }

            return cardList.ToString();
        }

        public BankAccount()
        {
            this.OwnerName = null;
            this.AccountPassword = null;
            this.Number = null;
        }

        private class BankAccountCard
        {
            public string CardType { get; }
            public int CardNumber { get;  }
            public decimal CardBalance { get; private set; }

            private static int CardNumberSeed = 00;

            public void GetFunds(decimal funds, BankAccount bankAccount)
            {
                this.CardBalance += funds;
                bankAccount.MakeWithdrawal(funds, DateTime.Now, "New bank account card");
            }
            
            public BankAccountCard(string cardType, decimal funds, BankAccount bankAccount)
            {
                this.CardType = cardType;
                this.CardNumber = CardNumberSeed++;
                GetFunds(funds, bankAccount);
            }
        }
    }
}
