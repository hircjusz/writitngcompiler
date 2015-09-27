using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Compiler.Messages;
using Intermediate.Code;
using Intermediate.Symbols;
using Pascal.Listeners;
using Pascal.Parsers;
using Pascal.Tokens;


namespace Pascal
{
    public class PascalParserTD : Parser
    {
        public PascalParserTD(Scanner scanner)
            : base(scanner)
        {
            var pascalMessageListener = new PascalParserMessageListener();
            this.MessageEvents += pascalMessageListener.HandleMessage;
        }

        public override Token Synchronize(IList<TokenType> syncSet)
        {
            var listOfSyncSet = syncSet.Select(t => t.GetTokenName().ToLower()).ToArray();
            var token = this.currentToken();

            if (!listOfSyncSet.Contains(token.Type.GetTokenName().ToLower()))
            {
                exceptionHandler.Register(token, ParserExceptionEnum.UNEXPECTED_TOKEN);
                do
                {
                    token = this.NextToken();
                } while (!(token.Type.GetType() == typeof(EofToken)) &&
                         !listOfSyncSet.Contains(token.Type.GetTokenName().ToLower()));
            }
            return token;
        }



        public override void Parse()
        {

            ICode code = CodeFactory.CreateICode();

            try
            {
                var token = NextToken();
                ICodeNode root = null;

                var stopWatch = new Stopwatch();
                stopWatch.Start();

                if (token.Type.GetType() == typeof(ReservedWordToken) &&
                    token.Type.GetTokenName() == PascalTokenReservedEnum.BEGIN.ToString())
                {
                    var statementParser = new StatementParser(this);
                    root = statementParser.Parse(token);
                    token = currentToken();
                }
                else
                {
                    exceptionHandler.Register(token, ParserExceptionEnum.UNEXPECTED_TOKEN);
                }
                stopWatch.Stop();
                token = currentToken();
                if (root != null)
                {
                    iCode.SetRoot(root);
                }

                OnMessage(new Message(token.LineNum.ToString(), MessageType.PARSER_SUMMARY, new double[]
                {
                    token.LineNum,
                    GetErrorCount(),
                    stopWatch.ElapsedMilliseconds
                }));

            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

    }
}
