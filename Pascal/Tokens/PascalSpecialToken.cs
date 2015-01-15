using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalSpecialToken : PascalToken
    {
        public PascalSpecialToken(Source source) : base(source) { }

        public static HashSet<char> RESERVED_SYMBOLS = new HashSet<char>() { '+', '-', '*', '/', '=', ':', '<', '>', '.' };

        protected override void Extract()
        {
            StringBuilder builder = new StringBuilder();
            char currentChar = PeekCurrentChar();
            text += currentChar;
            bool move = false;
            switch (currentChar)
            {
                case '^':
                case '}':
                case '{':
                case ']':
                case '[':
                case ')':
                case '(':
                case '=':
                case '\\':
                case ';':
                case ',':
                case '/':
                case '*':
                case '-':
                case '+':
                    builder.Append(currentChar);
                    NextChar();
                    break;
                case ':':
                    currentChar = NextChar();
                    if (currentChar == '=')
                    {
                        builder.Append('=');
                        NextChar();

                    }
                    break;
                case '<':
                    builder.Append(currentChar);
                    currentChar = NextChar();
                    if (currentChar == '=' || currentChar == '>')
                    {
                        builder.Append(currentChar);
                        NextChar();

                    }
                    break;
                case '>':
                    builder.Append(currentChar);
                    currentChar = NextChar();
                    if (currentChar == '=')
                    {

                        builder.Append(currentChar);
                        NextChar();

                    }
                    break;
                case '.':

                    builder.Append(currentChar);
                    currentChar = NextChar();
                    if (currentChar == '.')
                    {
                        builder.Append(currentChar);
                        NextChar();
                    }
                    break;

                default:
                    {
                        Type = new ErrorToken();
                        Value = null;


                    }
                    break;

            }
            if (Type.GetType() == typeof(SpecialToken))
            {
                this.Type = new SpecialToken();

            }


            //builder.Append(currentChar);
            this.Value = builder.ToString();
            this.Text = builder.ToString();

            //if (move)
            //{
            //    NextChar();
            //}
        }
    }
}
