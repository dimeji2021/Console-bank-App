using Banking.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.MODEL.DTOs
{
    public class TransactionDto
    {
        public decimal Amount { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        public string AccountNumber { get; set; }
        public string ReceivingAccountNumber { get; set; }
    }
}
