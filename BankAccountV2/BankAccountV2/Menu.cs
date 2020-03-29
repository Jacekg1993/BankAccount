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
            Console.WriteLine("Bank Account MENU:\n1: Sing in\n2: Create account\n3: Delete account\n4: Exit");
            Console.Write("\nChoose an option: ");
        }

        public static void MainMenuOptions(int choice)
        {
            switch (choice)
            {
                case 1:
                    CreateAccountMenuDisplay();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public static void CreateAccountMenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("Create Account:");
            Console.WriteLine("Create Account2sad:");

            Console.ReadKey();
        }
    }
}
