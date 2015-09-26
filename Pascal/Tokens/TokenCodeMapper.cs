using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Intermediate.Code;

namespace Pascal.Tokens
{
    public class TokenCodeMapper
    {
        public Dictionary<string, CodeNodeTypeEnum> _mapper = new
            Dictionary<string, CodeNodeTypeEnum>
        {
           {TokenConst.Minus,CodeNodeTypeEnum.SUBTRACT},
           {TokenConst.Plus,CodeNodeTypeEnum.ADD},
           {TokenConst.Div,CodeNodeTypeEnum.INTEGER_DIVIDE},
           {TokenConst.Star, CodeNodeTypeEnum.MULTIPLY},
           {TokenConst.Slash,CodeNodeTypeEnum.FLOAT_DIVIDE},
           {TokenConst.Mod,CodeNodeTypeEnum.MOD},
           {TokenConst.Equals,CodeNodeTypeEnum.EQ},
           {TokenConst.Not_Equals,CodeNodeTypeEnum.NE},
           {TokenConst.Less_equals,CodeNodeTypeEnum.LE},
           {TokenConst.Less_than,CodeNodeTypeEnum.LT},
           {TokenConst.Greater_equals,CodeNodeTypeEnum.GE},
           {TokenConst.Greater_than,CodeNodeTypeEnum.GT},
           {TokenConst.And,CodeNodeTypeEnum.AND},
           {TokenConst.Or,CodeNodeTypeEnum.OR}
        };


        public bool IsCodeNodeTypeEnum(string token)
        {
            return (_mapper.ContainsKey(token));
        }

        public bool IsCodeNodeTypeEnum(Token token)
        {
            return (_mapper.ContainsKey(token.Text));
        }

        public CodeNodeTypeEnum GetNodeEnumType(string token)
        {
            if (_mapper.ContainsKey(token))
            {
                return _mapper[token];
            }
            throw new Exception(string.Format("token {0}  nie posiada mapowania!", token));
        }

        public CodeNodeTypeEnum GetNodeEnumType(Token token)
        {
            var tokenText = token.Text.ToLower();
            return GetNodeEnumType(tokenText);
        }

    }
}
