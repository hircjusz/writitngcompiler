using System.Collections.Generic;
using Compiler;

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

    public class SpecialToken : TokenType
    {
        public override string GetTokenName()
        {
            return "Special";
        }
    }

    public class StringToken : TokenType
    {
        public override string GetTokenName()
        {
            return "String";
        }
    }

    public class ErrorToken : TokenType
    {
        public override string GetTokenName()
        {
            return "Error";
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
        public ReservedWordToken(string name) : base(name)
        {
        }

        //public override string GetTokenName()
        //{
        //    return "ReservedWord";
        //}
    }


}
