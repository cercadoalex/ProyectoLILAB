﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Error
{
    public class CodeErrorException : CodeErrorResponse
    {
        public CodeErrorException(int statusCode, string message =null,string details = null ) : base(statusCode,message)
        {
            Details = details;
        }
        public string Details { get; set; }
    }
}
