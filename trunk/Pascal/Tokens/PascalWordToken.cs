using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalWordToken : PascalToken
    {

        public PascalWordToken(Source source) : base(source) { }

        //  protected int TokenType;

        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char ch = PeekCurrentChar();
            while (Char.IsLetterOrDigit(ch))
            {
                builder.Append(ch);
                ch = NextChar();
            }
            this.text = builder.ToString();
            if (PascalTokenType.RESERVED_WORDS.Contains(text.ToUpper()))
            {
                this.Type = new IdentifierToken();
            }
            else
            {
                this.Type = new ReservedWordToken();
            }

        }
    }
}
