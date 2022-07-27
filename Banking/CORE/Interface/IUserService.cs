using Banking.Commons;
using Banking.MODEL;
using Banking.MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.CORE.Interface
{
    public interface IUserService
    {
        bool CreateCustomer(CustomerDto customer);
        Account CreateAccount(AccountType account);
    }
}
