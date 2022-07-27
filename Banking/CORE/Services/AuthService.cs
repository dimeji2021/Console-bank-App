using Banking.CORE.Interface;
using Banking.MODEL;
using Banking.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CORE.Services
{
    public class AuthService : IAuthService
    {
        private readonly List<Customer> customers;
        public AuthService(List<Customer> customers)
        {
            this.customers = customers;
        }
        public bool Login(string userName, string password)
        {
            bool login = false;
            foreach (var cus in customers)
            {
                if (cus.UserName.Equals(userName) && cus.Password.Equals(password))
                {
                    login = true;
                }
            }
            return login;
        }

        public bool Logout()
        {
            HomePage.DisplayHome();
            return true;
        }
    }
}
