using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public  class PascalSpecialToken:PascalToken
    {
        public PascalSpecialToken(Source source) : base(source) { }


        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char ch=PeekChar();
            text+=ch;
            switch (ch) { 
                case '+':
                    CurrentChar();
                    break;
            }
        }
    }
}
