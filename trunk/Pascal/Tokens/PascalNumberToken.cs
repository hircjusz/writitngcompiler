using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;

namespace Pascal.Tokens
{
    public class PascalNumberToken:PascalToken
    {
        public PascalNumberToken(Source source) : base(source) { }

        protected override void Extract()
        {
            //StringBuilder builder = new StringBuilder();
            //char ch=PeekChar();
            ////builder.Append(ch);
            //while (Char.IsLetterOrDigit(ch)) {
            //    builder.Append(ch);
            //   ch= CurrentChar();
            //}
            //this.text = builder.ToString();
            //StringBuilder digits = new StringBuilder();
            //StringBuilder textBuffer = new StringBuilder();

            //char ch=PeekChar();
            //while (Char.IsDigit(ch)) { 
            

            
            //}
            GetUnassignedDigits();
        }


        protected void GetUnassignedDigits() {
            StringBuilder digits = new StringBuilder();
            StringBuilder textBuffer = new StringBuilder();

            char ch = PeekChar();
            while (Char.IsDigit(ch))
            {
                textBuffer.Append(ch);
                digits.Append(ch);
                ch = CurrentChar();
            }
        
        }

    }
}
