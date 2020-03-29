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

        public static void MainMenuOptions(int choice, List<BankAccount> BankAccounts)
        {
            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    CreateAccountMenuDisplay(BankAccounts);
                    break;
                case 3:
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
    }
}
