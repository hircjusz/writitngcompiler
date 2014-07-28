using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalWordToken:PascalToken
    {

        public PascalWordToken(Source source) : base(source) { }

        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char ch=PeekChar();
            //builder.Append(ch);
            while (Char.IsLetterOrDigit(ch)) {
                builder.Append(ch);
               ch= CurrentChar();
            }
            this.text = builder.ToString();


        }
    }
}
