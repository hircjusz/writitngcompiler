using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;
using Intermediate.Symbols;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class AssignmentStatementParser : IParserStatement
    {
        private Parser _parser;

        public AssignmentStatementParser(Parser parser)
        {
            this._parser = parser;
        }

        public Intermediate.Code.ICodeNode Parse(Compiler.Token token)
        {
            var assigngnNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.ASSIGN);

            string targetName = token.Text.ToLower();
            ISymTabEntry targetId = _parser.SymTabStack.Lookup(targetName);
            if (targetId == null)
            {
                targetId = _parser.SymTabStack.EnterLocal(targetName);
            }
            targetId.AppendLineNumber(token.LineNum);

            token = _parser.NextToken();
            ICodeNode variableNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.VARIABLE);
            variableNode.SetAttribute(CodeKeyEnum.ID, targetId);
            assigngnNode.AddChild(variableNode);

            if (token.Type.GetType() == typeof(SpecialToken) && token.Text == TokenConst.Colon_Equlas)
            {
                token = _parser.NextToken();
            }
            else
            {

            }
            
            var expressionParser = new ExpressionParser(_parser);
            assigngnNode.AddChild(expressionParser.Parse(token));

            
            
            return assigngnNode;

        }
    }
}
