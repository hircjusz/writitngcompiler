using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public enum TokenType { 
    
    EofToken
    
    }


    public class Token
    {
        protected TokenType type;
        protected string text;

        public  string Text
        {
            get { return text; }
            set { text = value; }
        }
        protected Object value;
        protected Source source;

        protected int lineNum;
        protected int position;



        public Token(Source source) {

            this.source = source;
            this.lineNum = source.LineNum;
            this.position = source.CurrentPosition;
            //this.text = Convert.ToString(source.PeekChar());
            Extract();
        }

        public Token() { }


        protected virtual  void Extract() 
        {
        
        
        }

        protected char CurrentChar()
        {
            return source.CurrentChar();
        }

        protected char PeekChar()
        {

            return source.PeekChar();
        }



    }
}
