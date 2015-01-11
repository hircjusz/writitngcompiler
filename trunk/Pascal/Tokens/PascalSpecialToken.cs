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

        public static HashSet<char> RESERVED_SYMBOLS = new HashSet<char>() { '+', '=', ':', '<', '>', '.' };

        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char ch=PeekCurrentChar();
            text+=ch;
            bool move = false;
            switch (ch) {
                case '+':
                    move = true;
                    break;
                case ':':
                case '<':
                case '>':
                case '.':
                    {
                    ch = NextChar();
                    if (ch == '=')
                    {
                        text += ch;
                        move = true;
                    }
                    break;
                }

            }

            if (move)
            {
                NextChar();
            }
        }
    }
}
