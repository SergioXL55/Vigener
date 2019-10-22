using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    interface Cryptographer:IFieldValidator
    {
        void setKey(String key);
        String encode(String text);
        String decode(String text);
    }
}
