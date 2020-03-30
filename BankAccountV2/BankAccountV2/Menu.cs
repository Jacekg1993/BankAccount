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
            Console.Write("\nChoose an option: ");
        }

        public static void MainMenuOptions(int choice, List<BankAccount> BankAccountsList)
        {
            switch (choice)
            {
                case 1:
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

        public static void CreateAccountMenuDisplay(List<BankAccount> BankAccountsList)
        {
            string OwnerName;
            decimal InitialBalance;

            Console.Clear();
            Console.WriteLine("Create Account:\n________________");

            Console.Write("Owner name: ");
            OwnerName = Console.ReadLine();

            Console.Write("Initial balance: ");
            InitialBalance = decimal.Parse(Console.ReadLine());

            BankAccountsList.Add(new BankAccount(OwnerName, InitialBalance));

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
    }
}
