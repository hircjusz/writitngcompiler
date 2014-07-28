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
                    ch = CurrentChar();
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
                CurrentChar();
            }
        }
    }
}
