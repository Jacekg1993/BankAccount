using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int MainMenuChoosedOption;

            while (true)
            {
                Console.Clear();

                Menu.MainMenuDisplay();
                MainMenuChoosedOption = int.Parse(Console.ReadLine());
                if (MainMenuChoosedOption == 4)
                {
                    break;
                }

                Menu.MainMenuOptions(MainMenuChoosedOption);
            }

            /*
            try
            {
                BankAccount InvalidAccount = new BankAccount("Invalid", -100);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }
            

            try
            {
                myAccount.MakeWithdrawal(40000, DateTime.Now, "For a car");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
            */
            Console.ReadKey();
        }
    }
}
