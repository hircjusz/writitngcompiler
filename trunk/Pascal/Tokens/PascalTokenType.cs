using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using System.Collections.Generic;
namespace Pascal.Tokens
{
    public class PascalTokenType : TokenType
    {
        public static HashSet<string> RESERVED_WORDS = new HashSet<string>() 
        {"BEGIN", "AND", "ARRAY", "BEGIN", "CASE", "CONST", "DIV", "DO", "DOWNTO", "ELSE", "END",
        "FILE", "FOR", "FUNCTION", "GOTO", "IF", "IN", "LABEL", "MOD", "NIL", "NOT",
        "OF", "OR", "PACKED", "PROCEDURE", "PROGRAM", "RECORD", "REPEAT", "SET",
        "THEN", "TO", "TYPE", "UNTIL", "VAR", "WHILE", "WITH" };

        private static int counter = 16;
        public static int IDENTIFIER = counter + 1;
        public static int RESERVED_WORD = counter + 2;
    }

    public class UndefinedToken : TokenType
    {
        public override string GetTokenName()
        {
            return "Undefined";
        }
    }

    public class IdentifierToken :TokenType
    {
        public override string GetTokenName()
        {
            return "Identifier";
        }
    }

    public class ReservedWordToken : TokenType
    {
        public override string GetTokenName()
        {
            return "ReservedWord";
        }
    }


}
