using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Banking.Commons
{
    public class Utility
    {
        public static bool ValidateName(string name)
        {
            Regex regex = new Regex(@"^[A-Z]");
            return regex.IsMatch(name);
        }
        public static bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(email);
        }
        public static  bool ValidatePawword(string password)
        {
            Regex regex = new Regex(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W])(?!.* ).{8,}");
            return regex.IsMatch(password);
        }
        public static void EndPrompt()
        {
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }
    }
}
