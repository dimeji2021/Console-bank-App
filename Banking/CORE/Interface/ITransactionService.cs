using Banking.Commons;
using Banking.MODEL;
using Banking.MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CORE.Interface
{
    interface ITransactionService
    {
        public bool Deposit(TransactionDto transactionDto);
        public void WithDrawal(TransactionDto transactionDto);
        public bool Transfer(TransactionDto transactionDto);
        public List<AccountDetails> GetAccountDetails();
        public List<AccountStatment> GetStatement(string accNumber);
        public decimal? GetBalance(string accNum);
        public bool AccountVerification(string accNum);

    }
}
