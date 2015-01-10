using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class TokenType
    {

        public virtual string GetTokenName()
        {
            return "Undefined";
        }
    }
}
