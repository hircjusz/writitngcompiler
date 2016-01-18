using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Exception;
using Intermediate.Code;
using Intermediate.Symbols;
using Pascal.Tokens;

namespace Pascal.Parsers
{
    public class ExpressionParser : IParserStatement
    {
        private readonly Parser _parser;
        private readonly TokenCodeMapper _codeMapper = new TokenCodeMapper();
        private readonly IList<string> addOpsSimpleExpression= new List<string>()
        {
            TokenConst.Minus,TokenConst.Plus,TokenConst.Or
        };

        private readonly IList<string> multOpsTermExpression = new List<string>()
        {
            TokenConst.Star,TokenConst.Slash,TokenConst.Div,TokenConst.Mod,TokenConst.And
        };

        private readonly  IList<string> relList= new List<string>()
        {
            TokenConst.Equals,TokenConst.Not_Equals,TokenConst.Less_equals,TokenConst.Less_than,
            TokenConst.Greater_equals,TokenConst.Greater_than
        };

        public ExpressionParser(Parser parser)
        {
            _parser = parser;
        }

        private ICodeNode ParseExpression(Token token)
        {

            ICodeNode rootNode = ParseSmpleExpression(token);
            token = _parser.currentToken();
            if (relList.Contains(token.Text.ToLower()))
            {
                var codeNode = _codeMapper.GetNodeEnumType(token);
                var opNode = CodeFactory.CreateICodeNode(codeNode);
                opNode.AddChild(rootNode);
                token = _parser.NextToken();
                opNode.AddChild(ParseSmpleExpression(token));
                rootNode = opNode;
            }
            return rootNode;
        }

        private ICodeNode ParseSmpleExpression(Token token)
        {
            string signType=string.Empty;
            if (token.Text == TokenConst.Minus|| token.Text == TokenConst.Plus)
            {
                signType = token.Text;
                token = _parser.NextToken();
            }

            var rootNode = ParseTerm(token);
            if (signType == TokenConst.Minus)
            {
                var negateNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.NEGATE);
                negateNode.AddChild(rootNode);
                rootNode = negateNode;
            }

            token = _parser.currentToken();
            while (addOpsSimpleExpression.Contains(token.Text.ToLower()))
            {
                var nodeType = _codeMapper.GetNodeEnumType(token);
                var opNode = CodeFactory.CreateICodeNode(nodeType);
                opNode.AddChild(rootNode);

                token = _parser.NextToken();
                opNode.AddChild(ParseTerm(token));
                rootNode = opNode;
                token = _parser.currentToken();
            }

            return rootNode;
        }

        private ICodeNode ParseTerm(Token token)
        {
            var rootNode = ParseFactor(token);
            token = _parser.currentToken();
            while (multOpsTermExpression.Contains(token.Text.ToLower()))
            {
                var nodeType = _codeMapper.GetNodeEnumType(token);
                var opNode = CodeFactory.CreateICodeNode(nodeType);
                opNode.AddChild(rootNode);
                token = _parser.NextToken();
                opNode.AddChild(ParseFactor(token));
                rootNode = opNode;
            }
            return rootNode;
        }

        private ICodeNode ParseFactor(Token token)
        {
            ICodeNode rootNode = null;

            switch (token.Type.GetTokenName())
            {
                case "Identifier":
                    string name = token.Text.ToLower();
                   ISymTabEntry id= _parser.SymTabStack.Lookup(name);
                    if (id == null)
                    {
                        id = _parser.SymTabStack.EnterLocal(name);
                        _parser.RegisterException(token,ParserExceptionEnum.IDENTIFIER_UNDEFINED);
                    }
                    rootNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.VARIABLE);
                    rootNode.SetAttribute(CodeKeyEnum.ID, id);
                    id.AppendLineNumber(token.LineNum);
                    _parser.NextToken();

                    break;
                case "Integer":
                    rootNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.INTEGER_CONSTANT);
                    rootNode.SetAttribute(CodeKeyEnum.VALUE, token.Value);
                    _parser.NextToken();
                    break;
                case "String":
                    rootNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.STRING_CONSTANT);
                    rootNode.SetAttribute(CodeKeyEnum.VALUE, token.Value);
                     _parser.NextToken();
                    break;

                case "Real":
                     rootNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.REAL_CONSTANT);
                    rootNode.SetAttribute(CodeKeyEnum.VALUE, token.Value);
                     _parser.NextToken();
                    break;
                case "NOT":
                    token = _parser.NextToken();
                    rootNode = CodeFactory.CreateICodeNode(CodeNodeTypeEnum.NOT);
                    rootNode.AddChild(ParseFactor(token));
                    break;
                case "Special":
                {
                    if (token.Text == "(")
                    {
                        token = _parser.NextToken();
                        rootNode = ParseExpression(token);
                        token = _parser.currentToken();
                        if (token.Text == ")")
                        {
                            token = _parser.NextToken();
                        }
                        else
                        {
                            _parser.RegisterException(token,ParserExceptionEnum.MISSING_RIGHT_PARENT);
                        }
                    }
                    else
                    {
                        _parser.RegisterException(token, ParserExceptionEnum.UNEXPECTED_TOKEN);
                    }
                }
                break;
                     default:
                {
                    _parser.RegisterException(token, ParserExceptionEnum.UNEXPECTED_TOKEN);
                }
                    break;
            }

            return rootNode;

        }

        public ICodeNode Parse(Token token)
        {
            return ParseExpression(token);
        }
    }
}
