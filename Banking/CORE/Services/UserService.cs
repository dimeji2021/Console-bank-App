using Banking.Commons;
using Banking.CORE.Interface;
using Banking.MODEL;
using Banking.MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CORE.Services
{
    public class UserService : IUserService
    {

        public static List<Customer> customers { get; set; }
        public UserService()
        {
            customers = new List<Customer>();
        }
        public Account CreateAccount(AccountType accountType)
        {
            var account = new Account();
            account.AccountType = accountType;
            Random generator = new Random();
            var randomDigit = generator.Next(1000000, 9999999).ToString();
            account.AccountNumber = accountType == AccountType.Savings ? $"032" + randomDigit : $"053" + randomDigit;
            return account;
        }

        public bool CreateCustomer(CustomerDto customer)
        {
            var newCustomer = new Customer();   
            newCustomer.FirstName = customer.FirstName;
            newCustomer.LastName = customer.LastName;
            newCustomer.UserName = customer.UserName;
            newCustomer.Password = customer.Password;
            newCustomer.Email = customer.Email;
            newCustomer.Accounts.Add(CreateAccount(customer.AccountType));
            customers.Add(newCustomer);
            return true;

        }
    }
}
