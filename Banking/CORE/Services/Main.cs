using Banking.Commons;
using Banking.CORE.Interface;
using Banking.MODEL;
using Banking.MODEL.DTOs;
using Banking.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Banking.CORE.Services
{
    public class Main 
    {
        UserService userService = new UserService();

        public void DisplayLogin()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter Your UserName");
                Console.ResetColor();
                string userName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter Your Password");
                Console.ResetColor();
                string password = Console.ReadLine();

                Console.Clear();
                AuthService auth = new AuthService(UserService.customers);
                bool login = auth.Login(userName, password);

                if (login)
                {
                    while (true)
                    {
                        foreach (var cus in UserService.customers.Where(x => x.UserName == userName && x.Password == password))
                        {

                            Console.Clear();
                            Console.ForegroundColor =ConsoleColor.Green;
                            Console.WriteLine($"Welcome back {cus.FirstName} {cus.LastName}");
                            Console.ResetColor();
                            Console.WriteLine("What would you like to do today\n" +
                                "Select\n" +
                                "\n" +
                                "1. To Deposit\n" +
                                "2. To Withdraw\n" +
                                "3. To Make Transfer\n" +
                                "4. To Get Account Details\n" +
                                "5. To Get Account Statement\n" +
                                "6. To Get Balance\n" +
                                "7. To Create Account\n" +
                                "8  To Logout of your account.");
                            string response = Console.ReadLine();
                            TransactionService transactionService = new TransactionService(cus);
                            TransactionDto transactionDto = new TransactionDto();
                            if (response.Trim().Equals("1"))
                            {

                                // Account Number to make the deposit
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Enter the Account Number of the account you wish to deposit into");
                                Console.ResetColor();
                                Console.Write(">");
                                transactionDto.AccountNumber = Console.ReadLine();
                                if (transactionService.AccountVerification(transactionDto.AccountNumber))
                                {
                                    // Amount to deposit
                                    while (true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("Enter the amount you wish to deposit");
                                        Console.ResetColor();
                                        Console.Write(">");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal depositedAmount))
                                        {
                                            transactionDto.Amount = depositedAmount;
                                            break;
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Please Enter A Valid Amount");
                                        Console.ResetColor();
                                    }
                                    transactionService.Deposit(transactionDto);
                                    Console.WriteLine("Transaction successful.");
                                    Utility.EndPrompt();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Incorrect account details.");
                                Console.ResetColor();
                                Utility.EndPrompt();
                            }
                            else if (response.Trim().Equals("2"))
                            {
                                Console.Clear();
                                // Account Number to Withdraw from
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Enter the Account Number of the account you wish to withdraw from");
                                Console.ResetColor();
                                Console.Write(">");
                                if (transactionService.AccountVerification(transactionDto.AccountNumber = Console.ReadLine()))
                                {
                                    // Amount to withdraw
                                    while (true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        Console.WriteLine("Enter the amount you wish to withdraw");
                                        Console.ResetColor();
                                        Console.Write(">");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                                        {
                                            transactionDto.Amount = withdrawalAmount;
                                            break;
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Please Enter A Valid Amount");
                                        Console.ResetColor();
                                    }
                                    Console.Clear();
                                    transactionService.WithDrawal(transactionDto);
                                    Utility.EndPrompt();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Incorrect account details.");
                                Console.ResetColor();
                                Utility.EndPrompt();
                            }
                            else if (response.Trim().Equals("3"))
                            {
                                // Account Number to Transfer From
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Enter the Account Number of the account you wish to transfer From");
                                Console.ResetColor();
                                Console.Write(">");
                                if (transactionService.AccountVerification(transactionDto.AccountNumber = Console.ReadLine()))
                                {
                                    // Account Number to Transfer To
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Enter the Account Number of the account you wish to transfer To");
                                    Console.ResetColor();
                                    Console.Write(">");
                                    if (transactionService.AccountVerification(transactionDto.ReceivingAccountNumber = Console.ReadLine()))
                                    {
                                        // Amount to Transfer
                                        while (true)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            Console.WriteLine("Enter the amount you wish to transfer");
                                            Console.ResetColor();
                                            Console.Write(">");
                                            if (decimal.TryParse(Console.ReadLine(), out decimal transferAmount))
                                            {
                                                transactionDto.Amount = transferAmount;
                                                break;
                                            }
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.WriteLine("Please Enter A Valid Amount");
                                            Console.ResetColor();
                                        }
                                        if (transactionService.Transfer(transactionDto))
                                        {
                                            Console.WriteLine("Transaction successful");
                                            Utility.EndPrompt();
                                            break;
                                        }
                                        Console.WriteLine("You do not have a sufficient balance to perform this transaction");
                                        Utility.EndPrompt();
                                        break;
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Incorrect account details.");
                                Console.ResetColor();
                                Utility.EndPrompt();
                            }
                            else if (response.Trim().Equals("4"))
                            {
                                Console.Clear();
                                // Get Details
                                string[] header = new string[] { "FULL NAME", "ACCOUNT NUMBER", "ACCOUNT TYPE", "BALANCE" };
                                PrintTable table = new PrintTable(header);
                                foreach (var details in transactionService.GetAccountDetails())
                                {
                                    string[] row = new string[4];
                                    row[0] = details.FullName;
                                    row[1] = details.AccountNumber;
                                    row[2] = details.AccountType;
                                    row[3] = details.Balance.ToString();
                                    table.AddRow(row);
                                    //Thread.Sleep(2000);
                                }
                                table.Print();
                                Utility.EndPrompt();
                            }
                            else if (response.Trim().Equals("5"))
                            {
                                Console.Clear();
                                // Account Number to Withdraw from
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Enter the Account Number of the account you wish to Get Statement ");
                                Console.ResetColor();
                                Console.Write(">");
                                string accNum = Console.ReadLine();
                                Console.Clear();
                                //var listOfTransaction = transactionService.GetStatement(accNum.Trim());
                                if (transactionService.AccountVerification(accNum))
                                {
                                    if (transactionService.GetStatement(accNum.Trim()).Count > 0)
                                    {
                                        string[] header = new string[] { "DATE", "AMOUNT", "DESCRIPTION", "BALANCE" };
                                        PrintTable table = new PrintTable(header);
                                        foreach (var statement in transactionService.GetStatement(accNum.Trim()))
                                        {


                                            string[] row = new string[4];
                                            row[0] = statement.Date.ToString();
                                            row[1] = statement.Amount.ToString();
                                            row[2] = statement.Description;
                                            row[3] = statement.Balance.ToString();
                                            table.AddRow(row);

                                        }
                                        table.Print();
                                        Utility.EndPrompt();
                                        break;
                                    }
                                    Console.WriteLine("You do not have a transaction history.");
                                    Utility.EndPrompt();
                                    break;
                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Incorrect account details.");
                                Console.ResetColor();
                                Utility.EndPrompt();
                            }
                            else if (response.Trim().Equals("6"))
                            {
                                // Get Balance
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Enter the Account Number of the account you wish to Get Balance");
                                Console.ResetColor();
                                Console.Write(">");
                                string accNum = Console.ReadLine();
                                if (transactionService.AccountVerification(accNum))
                                {
                                    Console.WriteLine($"Your balance is {transactionService.GetBalance(accNum)}");
                                    Utility.EndPrompt();
                                    break;

                                }
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Incorrect account details");
                                Console.ResetColor();
                                Utility.EndPrompt();

                            }
                            else if (response.Trim().Equals("7"))
                            {
                                CustomerDto customerDto = new CustomerDto();
                                while (true)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("Enter the Type of Account you wish to open");
                                    Console.ResetColor();
                                    Console.WriteLine("1. Savings\n" +
                                        "2. Current.");
                                    Console.Write(">");
                                    if (AccountType.TryParse(Console.ReadLine(), out AccountType accType))
                                    {
                                        customerDto.AccountType = accType;
                                        break;
                                    }
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("Wrong input; Enter 1 or 2 ");
                                    Console.ResetColor();
                                }
                                var account = userService.CreateAccount(customerDto.AccountType);
                                cus.Accounts.Add(account);
                                Console.Clear();
                                Console.WriteLine("Account Creation Successful");
                                foreach (var acc in UserService.customers)
                                {
                                    Console.WriteLine($"Account Number {acc.Accounts.Where(x => x.AccountType == customerDto.AccountType).LastOrDefault().AccountNumber} has been created for {acc.FirstName} {acc.LastName}");
                                    Utility.EndPrompt();
                                    break;
                                }
                            }
                            else if (response.Trim().Equals("8"))
                            {
                                Console.Clear();
                                auth.Logout();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Command not recognise!");
                                Utility.EndPrompt();
                            }
                        }

                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("UserName Or Password is incorrect");
                Console.ResetColor();
            }
        }

        public void DisplayRegister()
        {
            CustomerDto customerDto = CustomerCapture.CaptureData();
            if (userService.CreateCustomer(customerDto))
            {
                Console.Clear();
                Console.WriteLine("Account Creation Successful");
                foreach (var acc in UserService.customers)
                {
                    if (acc.Password == customerDto.Password)
                    {
                        Console.WriteLine($"Account Number {acc.Accounts.Where(x => x.AccountType == customerDto.AccountType).LastOrDefault().AccountNumber} has been created for {acc.FirstName} {acc.LastName}");
                        Console.WriteLine("Press Enter to go to the main menue");
                        return;
                    }
                }
            }
        }
    }
}
