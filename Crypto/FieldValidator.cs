﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    interface IFieldValidator
    {
        Boolean ValidateInputData(String inputText, String key);
    }
}
