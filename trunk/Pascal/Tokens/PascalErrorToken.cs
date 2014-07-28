using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalErrorToken:PascalToken
    {
        public PascalErrorToken(Source source) : base(source) { }
         
    }
}
