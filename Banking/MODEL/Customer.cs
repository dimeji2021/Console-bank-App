using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.MODEL
{
    public class Customer 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();

    }
}
