using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BankAccountV2
{
    class Program
    {
        public enum MenuOptions
        {
            SignIn = 1,
            Create,
            GetList,
            Exit           
        }

        static void Main(string[] args)
        {
    
        List<BankAccount> BankAccountsList = new List<BankAccount>();
            MenuOptions MainMenuChoosedOption;
            int MainMenuChoosedOption2;

            while (true)
            {
                Console.Clear();

                Menu.MainMenuDisplay();
                MainMenuChoosedOption2 = int.Parse(Console.ReadLine());
                MainMenuChoosedOption = (MenuOptions)MainMenuChoosedOption2;
                if (MenuOptions.Exit) 
                {
                    break;
                }

                Menu.MainMenuOptions(MainMenuChoosedOption, BankAccountsList, MainMenuChoosedOption);
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
