﻿using CurrencyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Models.Authentication
{
    public class RegistrationResponse : BaseResponse
    {
        public string UserId { get; set; }
    }
}
