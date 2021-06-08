using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Utils.Enums
{
    public  enum Roles
    {
        Elite,
        Noob,
        Admin
    }

    enum TransactionType
    {
        credit,
        debit
    }

    enum TransactionStatus
    {
        approved,
        pending,
        declined

    }
}
