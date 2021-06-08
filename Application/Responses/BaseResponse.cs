using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = false;
        }
        public BaseResponse(string message = null)
        {
            Success = false;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
