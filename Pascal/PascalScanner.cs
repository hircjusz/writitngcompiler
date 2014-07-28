using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Pascal.Tokens;

namespace Pascal
{
    public class PascalScanner : Scanner
    {

        public PascalScanner(Source source)
            : base(source)
        {
        }

        public override Token extractToken()
        {
            SkipWhiteSpace();
            char currentChar = base.peekChar();
            Token token = null;
            if (currentChar == Source.EOF)
            {
                token = new EofToken(source);
            }
            else if (currentChar == Source.EOL)
            {
                token = new EolToken(source);
            }
            else if (Char.IsLetter(currentChar))
            {
                token = new PascalWordToken(source);
            }
            else if (Char.IsDigit(currentChar))
            {
                token = new PascalNumberToken(source);
            }
            else if (currentChar == '\'')
            {
                token = new PascalStringToken(source);
            }
            else if (PascalSpecialToken.RESERVED_SYMBOLS.Contains(currentChar))
            {
                token = new PascalSpecialToken(source);
            }
            else
            {
                token = new PascalErrorToken(source);
            }
            return token;
        }


        private void SkipWhiteSpace()
        {

            char currentChar = base.peekChar();
            while (Char.IsWhiteSpace(currentChar) || (currentChar == '{'))
            {
                if (currentChar == '{')
                {
                    do
                    {
                        currentChar = base.currentChar();
                    } while (currentChar != '}' && currentChar != Source.EOF);

                    if (currentChar == '}')
                    {

                        currentChar = base.currentChar();
                    }
                }
                else
                {
                    currentChar = base.currentChar();
                }

            }


        }

        //public override Token extractToken()
        //{
        //    char currentChar = source.CurrentChar();
        //    Token token = null;
        //    if (currentChar == Source.EOF)
        //    {
        //        token = new EofToken(source);
        //    }
        //    else
        //    {
        //        token = new Token(source);
        //    }
        //    return token;
        //}

    }
}
