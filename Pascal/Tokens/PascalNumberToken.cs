using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalNumberToken : PascalToken
    {
        public PascalNumberToken(Source source) : base(source) { }

        protected int IntValue;
        protected double DoubleValue;
        protected bool IsDouble = false;

        public override object Value {
            get
            {
                if (IsDouble) return DoubleValue;
                return IntValue;
            }
        }

        protected override void Extract()
        {
            var textBuffer = new StringBuilder();

            char ch = PeekCurrentChar();
            while (Char.IsDigit(ch))
            {
                textBuffer.Append(ch);
                ch = NextChar();
            }

            if (ch == '.')
            {
                IsDouble = true;
                textBuffer.Append(',');
                ch = NextChar();
                while (Char.IsDigit(ch))
                {
                    textBuffer.Append(ch);
                    ch = NextChar();
                }

            }

            if (ch == 'e' || ch == 'E')
            {
                IsDouble = true;
                textBuffer.Append(ch);
                ch = NextChar();
                if (ch == '+' || ch == '-')
                {
                    textBuffer.Append(ch);

                    ch = NextChar();
                    while (Char.IsDigit(ch))
                    {
                        textBuffer.Append(ch);
                        ch = NextChar();
                    }
                }
                else if (Char.IsDigit(ch))
                {
                    while (Char.IsDigit(ch))
                    {
                        textBuffer.Append(ch);
                        ch = NextChar();
                    }

                }
            }

            text = textBuffer.ToString();
            if (IsDouble)
            {
                DoubleValue = Convert.ToDouble(text);
                this.Type=new RealToken();
                
            }
            else
            {
                IntValue = Convert.ToInt32(text);
                this.Type=new IntegerToken();
            }
        }

    }
}
