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

        protected override void Extract()
        {
            StringBuilder textBuffer = new StringBuilder();

            char ch = PeekChar();
            while (Char.IsDigit(ch))
            {
                textBuffer.Append(ch);
                ch = CurrentChar();
            }

            if (ch == '.')
            {
                IsDouble = true;
                textBuffer.Append(',');
                ch = CurrentChar();
                while (Char.IsDigit(ch))
                {
                    textBuffer.Append(ch);
                    ch = CurrentChar();
                }

            }

            if (ch == 'e' || ch == 'E')
            {
                IsDouble = true;
                textBuffer.Append(ch);
                ch = CurrentChar();
                if (ch == '+' || ch == '-')
                {
                    textBuffer.Append(ch);

                    ch = CurrentChar();
                    while (Char.IsDigit(ch))
                    {
                        textBuffer.Append(ch);
                        ch = CurrentChar();
                    }
                }
                else if (Char.IsDigit(ch))
                {
                    while (Char.IsDigit(ch))
                    {
                        textBuffer.Append(ch);
                        ch = CurrentChar();
                    }

                }
            }

            text = textBuffer.ToString();
            if (IsDouble)
            {
                DoubleValue = Convert.ToDouble(text);
            }
            else
            {
                IntValue = Convert.ToInt32(text);
            }
        }

    }
}
