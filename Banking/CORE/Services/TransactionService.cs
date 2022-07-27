using Banking.Commons;
using Banking.CORE.Interface;
using Banking.MODEL;
using Banking.MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking.CORE.Services
{
    class TransactionService : ITransactionService
    {
        private readonly Customer customer;
        private IServiceProvider _serviceProvider;

        public TransactionService(Customer customer)
        {
            this.customer = customer;
        }
        public TransactionService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }
        public bool Deposit(TransactionDto transactionDto)
        {
            var transaction = new Transactions()
            {
                Amount = transactionDto.Amount,
                Description = "Desposit",
                Date = transactionDto.Date,
                AccountNumber = transactionDto.AccountNumber,
            };

            foreach (var account in customer.Accounts)
            {
                if (account.AccountNumber == transaction.AccountNumber)
                {
                    account.AccountBalance += transaction.Amount;
                    transaction.Balance = account.AccountBalance;
                    account.Transactions.Add(transaction);
                    return true;
                }
            }
            return false;
        }
        public void WithDrawal(TransactionDto transactionDto)
        {

            var transaction = new Transactions()
            {
                Amount = transactionDto.Amount,
                Description = "Withdrawal",
                Date = transactionDto.Date,
                AccountNumber = transactionDto.AccountNumber
            };

            foreach (var account in customer.Accounts)
            {
                if (account.AccountNumber == transaction.AccountNumber)
                {
                    decimal minBalance = account.AccountType.Equals((AccountType)1) ? 1000 : 0;
                    if (account.AccountBalance - minBalance >= transaction.Amount)
                    {
                        account.AccountBalance -= transaction.Amount;
                        transaction.Balance = account.AccountBalance;
                        account.Transactions.Add(transaction);
                        Console.WriteLine("Transaction Successful.");
                        break;
                    }
                    else if (account.AccountBalance - minBalance < transaction.Amount)
                    {
                        Console.WriteLine("Insufficient Fund.");
                        break;
                    }
                }
                Console.WriteLine("Incorrect Account details");
                break;
            }
        }
        public bool Transfer(TransactionDto transactionDto)
        {
            var Sendtransaction = new Transactions()
            {
                Amount = transactionDto.Amount,
                //Description = transactionDto.Description,
                Description = $"Transfer to {transactionDto.ReceivingAccountNumber}",
                Date = transactionDto.Date,
                AccountNumber = transactionDto.AccountNumber
            };
            var Receivetransaction = new Transactions()
            {
                Amount = transactionDto.Amount,
                //Description = transactionDto.Description,
                Description = $"Received fund from {transactionDto.AccountNumber}",
                Date = transactionDto.Date,
                AccountNumber = transactionDto.ReceivingAccountNumber
            };
            var isSend = false;
            var isReceive = false;
            foreach (var account in customer.Accounts)
            {
                if (account.AccountNumber == transactionDto.AccountNumber)
                {
                    decimal minBalance = account.AccountType.Equals((AccountType)1) ? 1000 : 0;
                    if (account.AccountBalance - minBalance >= transactionDto.Amount)
                    {
                        account.AccountBalance -= transactionDto.Amount;
                        Sendtransaction.Balance = account.AccountBalance;
                        account.Transactions.Add(Sendtransaction);
                        isSend = true;
                    }
                }
                if (account.AccountNumber == transactionDto.ReceivingAccountNumber)
                {
                    account.AccountBalance += transactionDto.Amount;
                    Receivetransaction.Balance = account.AccountBalance;
                    account.Transactions.Add(Receivetransaction);
                    isReceive = true;
                }
                if (isSend && isReceive)
                {
                    return true;
                }
            }
            return false;
        }
        public List<AccountDetails> GetAccountDetails()
        {
            var accountDetails = new List<AccountDetails>();
            foreach (var acc in customer.Accounts)
            {
                accountDetails.Add(new AccountDetails
                {
                    FullName = customer.FirstName + " " + customer.LastName,
                    AccountNumber = acc.AccountNumber,
                    AccountType = acc.AccountType.ToString(),
                    Balance = acc.AccountBalance
                });
            }
            return accountDetails;
        }

        public List<AccountStatment> GetStatement(string accNumber)
        {
            var accountStatement = new List<AccountStatment>();
            foreach (var acc in customer.Accounts)
            {
                if (acc.AccountNumber == accNumber)
                {
                    foreach (var trasnsaction in acc.Transactions)
                    {
                        accountStatement.Add(new AccountStatment
                        {
                            Amount = trasnsaction.Amount,
                            Description = trasnsaction.Description,
                            Date = trasnsaction.Date,
                            Balance = trasnsaction.Balance,
                        });
                    }
                    break;
                }
            }
            return accountStatement;
        }

        public decimal? GetBalance(string accNum)
        {
            foreach (var acc in customer.Accounts)
            {
                if (acc.AccountNumber.Equals(accNum))
                {
                    return acc.AccountBalance;
                }
            }
            return null;
        }
        public bool AccountVerification(string accNum)
        {
            foreach (var acc in customer.Accounts)
            {
                if (acc.AccountNumber == accNum)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
