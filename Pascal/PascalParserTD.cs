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
