using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class EofToken :Token
    {

        public EofToken(Source source) : base(source) { 
        
        }
    }
}
