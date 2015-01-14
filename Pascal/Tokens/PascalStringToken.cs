using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalStringToken : PascalToken
    {

        public PascalStringToken(Source source) : base(source) { }

        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char ch = PeekCurrentChar();
            do
            {
                builder.Append(ch);
                ch = NextChar();

                if (ch == '\'')
                {
                    while (ch == '\'' && PeekNextChar() == '\'')
                    {
                        builder.Append("''");
                        ch = NextChar();
                        ch = NextChar();
                    }
                }
            } while (ch != '\'' && ch != Source.EOF);
            builder.Append(ch);
            NextChar();
            this.text = builder.ToString();
        }
    }
}
