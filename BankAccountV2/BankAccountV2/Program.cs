using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BankAccountV2
{
    public enum MenuOptions
    {
        SignIn = 1,
        Create,
        GetList,
        Exit
    }

    class Program
    {
       
        static void Main(string[] args)
        {
    
        List<BankAccount> BankAccountsList = new List<BankAccount>();
            MenuOptions MainMenuChoosedOption;
            int MainMenuChoosedOptionInt;

            while (true)
            {
                Console.Clear();

                Menu.MainMenuDisplay();
                MainMenuChoosedOptionInt = int.Parse(Console.ReadLine());
                MainMenuChoosedOption = (MenuOptions)MainMenuChoosedOptionInt;

                if (MainMenuChoosedOption == (MenuOptions)4) 
                {
                    break;
                }

                Menu.MainMenuOptions(BankAccountsList, MainMenuChoosedOption);
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
