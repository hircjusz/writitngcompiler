using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    //public enum TokenType { 
    
    //EofToken
    
    //}


    public class Token
    {
        private TokenType type;

        public TokenType Type
        {
            get { return type; }
            set { type = value; }
        }
        protected string text;

        public  string Text
        {
            get { return text; }
            set { text = value; }
        }
        private Object value;

        public Object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        protected Source source;

        protected int lineNum;
        protected int position;



        public Token(Source source) {

            this.source = source;
            this.lineNum = source.LineNum;
            this.position = source.CurrentPosition;
            this.Type = new TokenType();
            //this.text = Convert.ToString(source.PeekChar());
            Extract();
        }

        public Token() { }


        protected virtual  void Extract() 
        {
        
        
        }

        protected char NextChar()
        {
            return source.NextChar();
        }

        protected char PeekCurrentChar()
        {
            return source.PeekCurrentChar();
        }

        protected char PeekNextChar()
        {
            return source.PeekNextChar();
        }



    }
}
