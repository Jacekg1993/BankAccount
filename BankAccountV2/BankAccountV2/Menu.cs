using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountV2
{
    class Menu
    {
        public static void MainMenuDisplay()
        {
            Console.WriteLine("Bank Account MENU:\n1: Sing in\n2: Create account\n3: Accounts list\n4: Exit");
            Console.Write("____________________");
            Console.Write("\nSelect option: ");
        }

        public static void MainMenuOptions(int mainMenuChoice, List<BankAccount> BankAccountsList)
        {
            switch (mainMenuChoice)
            {
                case 1:
                    SigningIntoAccount(BankAccountsList);
                    break;
                case 2:
                    CreateAccountMenuDisplay(BankAccountsList);
                    break;
                case 3:
                    Console.WriteLine(GetAccountsList(BankAccountsList));
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }

        public static void SigningIntoAccount(List<BankAccount> BankAccountsList)
        {
            Console.Clear();

            string login;
            string password;
            int accountIndex;
            char loopContinue;
            bool loopExit = false;

            while(loopExit == false)
            {
                Console.Clear();

                Console.Write("Login (Account number): ");
                login = Console.ReadLine();

                Console.Write("Password: ");
                password = Console.ReadLine();

                Console.WriteLine("__________________");

                accountIndex = GetAccountIndexByNumber(BankAccountsList, login);
                if(accountIndex == -1)
                {
                    Console.WriteLine("Wrong Login!");
                    Console.ReadKey();
                }
                else if(BankAccountsList[accountIndex].AccountPassword != password)
                {
                    Console.WriteLine("Wrong Password!");
                    Console.ReadKey();
                }
                else
                {
                    AccountOptionsMenu(BankAccountsList[accountIndex], BankAccountsList, accountIndex);
                }

                Console.Write("Do you want to repeat signing in? [y/n]: ");
                loopContinue = Console.ReadKey().KeyChar;
                if((loopContinue != 'Y') && (loopContinue != 'y'))
                {
                    loopExit = true;
                }

            }

        }

        public static void CreateAccountMenuDisplay(List<BankAccount> BankAccountsList)
        {
            string OwnerName;
            string AccountPassword;
            decimal InitialBalance;

            Console.Clear();
            Console.WriteLine("Create Account:\n________________");

            Console.Write("Owner name: ");
            OwnerName = Console.ReadLine();

            Console.Write("Password: ");
            AccountPassword = Console.ReadLine();

            Console.Write("Initial balance: ");
            InitialBalance = decimal.Parse(Console.ReadLine());

            BankAccountsList.Add(new BankAccount(OwnerName, InitialBalance, AccountPassword));

            Console.ReadKey();
        }

        public static string GetAccountsList(List<BankAccount> BankAccountsList)
        {
            Console.Clear();

            StringBuilder AccountsList = new System.Text.StringBuilder();
            AccountsList.AppendLine("Owner name\tAccount NR");   
            
            foreach (BankAccount bankAccount in BankAccountsList)
            {
                AccountsList.AppendLine($"{bankAccount.OwnerName}\t{bankAccount.Number}");
            }

            return AccountsList.ToString();
        }

        public static void AccountOptionsMenu(BankAccount BankAccount, List<BankAccount> BankAccountsList, int accountIndex)
        {
            int depositAmount;
            int withdrawalAmount;
            string depositNote;
            string withdrawalNote;

            int accountMenuChoice;
            Console.WriteLine("You are logged in...Press any button");
            Console.ReadKey();
            Console.Clear();
            bool loopExit = false;

            while (loopExit == false)
            {
                Console.Clear();
                Console.WriteLine("Options:\n1: Balance\n2: Deposit\n3: Withdrawal\n4: Account history\n5: Delete account\n6: Exit");
                Console.Write("____________________");
                Console.Write("\nSelect option: ");
                accountMenuChoice = int.Parse(Console.ReadLine());

                switch (accountMenuChoice)
                {
                    case 1:
                        Console.WriteLine($"Balance: {BankAccount.Balance}");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Deposit amount: ");
                        depositAmount = int.Parse(Console.ReadLine());
                        Console.Write("Additional information: ");
                        depositNote = Console.ReadLine();
                        BankAccount.MakeDeposit(depositAmount, DateTime.Now, depositNote);
                        break;
                    case 3:
                        Console.Write("Withdrawal amount: ");
                        withdrawalAmount = int.Parse(Console.ReadLine());
                        Console.Write("Additional information: ");
                        withdrawalNote = Console.ReadLine();
                        BankAccount.MakeWithdrawal(withdrawalAmount, DateTime.Now, withdrawalNote);
                        break;
                    case 4:
                        Console.WriteLine("Account history: ");
                        Console.WriteLine(BankAccount.GetAccountHistory());
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Write("Deleting account... ");
                        BankAccount = new BankAccount();
                        BankAccountsList.RemoveAt(accountIndex);
                        loopExit = true;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        loopExit = true;
                        Console.Clear();
                        break;                   
                }

            }

            Console.ReadKey();
        }

        public static int GetAccountIndexByNumber(List<BankAccount> BankAccountsList, string searchedAccountNumber)
        {
            return BankAccountsList.FindIndex(x => x.Number == searchedAccountNumber);
        }
    }
}
