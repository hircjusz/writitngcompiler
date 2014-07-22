using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Core;
using Compiler.Messages;

namespace Compiler
{
    public class Parser
    {

        protected ICode iCode;
        protected SymTab symTab;
        protected Scanner scanner = null;
        //protected LoggerEventHandler logger = new LoggerEventHandler();



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
            this.symTab = new SymTab();
           // scanner.MessageEvents += logger.HandleMessage;
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
