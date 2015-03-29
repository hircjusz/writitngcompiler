using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Core;
using Compiler.Messages;
using Intermediate.Symbols;

namespace Compiler
{
    public class Parser
    {
        protected ICode iCode;

        public  ICode Code
        {
            get { return iCode; }
            set { iCode = value; }
        }
        protected ISymTab symTab;

        public ISymTab SymTab
        {
            get { return symTab; }
            set { symTab = value; }
        }

        protected ISymTabStack symTabStack;

        public ISymTabStack SymTabStack
        {
            get { return symTabStack; }
        }
        protected Scanner scanner = null;

        #region Events

        public event EventHandler<Message> MessageEvents;

        protected void OnMessage(Message message)
        {
            if (MessageEvents != null)
            {
                MessageEvents(this, message);
            }
        }

        #endregion


        public Parser(Scanner scanner)
        {
            this.scanner = scanner;
            this.iCode = new Code();
            this.symTab = null;
            this.symTabStack = SymTabFactory.CreateSymTabStack(0);
        }

        public  virtual void Parse()
        {

        }

        public virtual int  getErrorCount()
        {
            //returns number of tokens
            return 0;
        }

        public virtual Token currentToken()
        {
            return scanner.currentToken();
        }

        public virtual Token NextToken() {
            return new Token();
        }


    }
}
