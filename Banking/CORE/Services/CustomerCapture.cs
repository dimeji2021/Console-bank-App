using Banking.Commons;
using Banking.MODEL.DTOs;
using System;


namespace Banking.CORE.Services
{
    class CustomerCapture
    {
        public static CustomerDto CaptureData()
        {
            CustomerDto customerDto = new CustomerDto();
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter Your First Name");
                Console.ResetColor();
                Console.Write(">");
                string firstName = Console.ReadLine();
                if (Utility.ValidateName(firstName))
                {
                    customerDto.FirstName = firstName[0] + firstName.Substring(1).ToLower();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Enter a valid name\n" +
                    "First Name must start with Uppercase, and cannot be empty.");
                Console.ResetColor();
            }
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter Your Last Name");
                Console.ResetColor();
                Console.Write(">");
                string lastName = Console.ReadLine();
                if (Utility.ValidateName(lastName))
                {
                    customerDto.LastName = lastName[0] + lastName.Substring(1).ToLower();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Last Name must start with Uppercase, and cannot be empty.");
                Console.ResetColor();
            }


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Enter a Valid Email Address");
                Console.ResetColor();
                Console.Write(">");
                string email = Console.ReadLine();
                if (Utility.ValidateEmail(email))
                {
                    customerDto.Email = email;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid email");
                Console.WriteLine("Example abcd@xyzhelp.com");
                Console.ResetColor();
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Create a UserName");
            Console.ResetColor();
            Console.Write(">");
            string userName = Console.ReadLine();
            customerDto.UserName = userName;


            while (true)
            {
                string password;
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Create Password:");
                    Console.ResetColor();
                    Console.Write(">");
                    password = Console.ReadLine();
                    if (Utility.ValidatePawword(password))
                    {
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a valid password");
                    Console.WriteLine("Hint:\n" +
                        "Password must contain one digit from 1 to 9,\n" +
                        "One lowercase letter, one uppercase letter,\n" +
                        "One special character, no space,\n" +
                        "It must be at least 8 characters long.");
                    Console.ResetColor();

                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Confirm your password:");
                Console.ResetColor();
                Console.Write(">");
                if (Console.ReadLine().Equals(password))
                {
                    customerDto.Password = password;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Password must match");
                Console.ResetColor();
            }
            while (true)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Select desired Account Type");
                Console.ResetColor();
                Console.WriteLine("Select\n"+
                    "1. Savings\n" +
                    "2. Current.");
                Console.Write(">");
                Console.ResetColor();
                if (AccountType.TryParse(Console.ReadLine(), out AccountType accountType) && accountType.Equals(AccountType.Savings) || accountType.Equals(AccountType.Current))
                {
                    customerDto.AccountType = accountType;
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong input; Enter 1 or 2.");
                Console.ResetColor();
                Utility.EndPrompt();
            }
            return customerDto;
        }
    }
}
