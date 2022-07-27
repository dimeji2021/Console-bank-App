using Banking.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.MODEL
{
    public class Account 
    {
        public string AccountNumber { get; set; }
        public AccountType AccountType { get; set; }
        public decimal AccountBalance { get; set; }
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();
    }
}
