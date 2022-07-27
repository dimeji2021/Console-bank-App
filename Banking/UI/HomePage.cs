using Banking.Commons;
using Banking.CORE.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.UI
{
    static class HomePage
    {
        public static void DisplayHome()
        {
            Main main = new Main();
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("----------Welcome----------");
                Console.ResetColor();
                Console.WriteLine("Select an option to continue.\n" +
                    "1. To Login\n" +
                    "2. To Register an Account with us\n" +
                    "3. To Exit application.");
                Console.Write(">");
                string Option = Console.ReadLine();

                if (Option.Trim().Equals("1"))
                {
                    main.DisplayLogin();
                }
                else if (Option.Trim().Equals("2"))
                {
                    main.DisplayRegister();
                }
                else if (Option.ToLower().Equals("3"))
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Command not recognise! Press enter to continue");
                    Utility.EndPrompt();
                    continue;
                }

                Console.Write(">");
                Option = Console.ReadLine();
            }
        }
    }
}
