using Banking.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.MODEL.DTOs
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
