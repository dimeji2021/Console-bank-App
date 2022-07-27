using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.MODEL
{
    public class Transactions 
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
