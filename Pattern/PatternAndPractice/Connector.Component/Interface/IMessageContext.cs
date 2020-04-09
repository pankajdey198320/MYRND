﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component.Interface
{
    public interface IMessageContext
    {
        string Message { get; set; }
        string GetPropertyvalye(string propertyName);
    }
}
