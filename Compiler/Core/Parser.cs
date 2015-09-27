using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler.Exception;
using Compiler.Messages;
using Intermediate.Code;
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

        protected Token _currentToken;

        public Token CurrentToken
        {
            get { return _currentToken; }
        }

        protected ISymTabStack symTabStack;

        public ISymTabStack SymTabStack
        {
            get { return symTabStack; }
        }
        protected Scanner scanner = null;

        protected readonly ExceptionHandler exceptionHandler= new ExceptionHandler();

        public virtual Token Synchronize(IList<TokenType> syncSet)
        {
            throw new System.NotImplementedException();
        }

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

        public void RegisterException(Token token,ParserExceptionEnum ex)
        {
            exceptionHandler.Register(token,ex);
        }

        public virtual int  GetErrorCount()
        {
            return exceptionHandler.GetErrorCount();
        }

        public virtual Token currentToken()
        {
            return CurrentToken;
            //return scanner.currentToken();
        }

        public virtual Token NextToken()
        {
            _currentToken= scanner.extractToken();
            return _currentToken;
        }


    }
}
