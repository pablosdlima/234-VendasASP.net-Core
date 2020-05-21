﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Services.Exceptions
{
    public class DBConcurrencyException: ApplicationException
    {
        public DBConcurrencyException(string message) : base(message)
        {

        }
    }
}