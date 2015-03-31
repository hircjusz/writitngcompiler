using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class TokenType
    {
        private readonly string _tokenTypeName ;

        public string TokenTypeName
        {
            get { return _tokenTypeName; }
        }

        public TokenType()
        {
        }

        public TokenType(string name)
        {
            _tokenTypeName = name;
        }

        public virtual string GetTokenName()
        {
            return _tokenTypeName;
        }
    }
}
