using System.Collections.Generic;
using System.Linq;
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


        public static IList<TokenType> GetReservedTokens(IList<PascalTokenReservedEnum> enums)
        {
            return enums.Select(item => new ReservedWordToken(item)).Cast<TokenType>().ToList();
        }

        public const string UndefinedToken = "Undefined";
        public const string SpecialToken = "Special";
        public const string IntegerToken = "Integer";
        public const string RealToken = "Real";
        public const string StringToken = "String";
        public const string ErrorToken = "Error";
        public const string IdentifierToken = "Identifier";

    }

    public enum PascalTokenReservedEnum
    {
        BEGIN, AND, ARRAY,  CASE, CONST, DIV, DO, DOWNTO, ELSE, END,
        FILE, FOR, FUNCTION, GOTO, IF, IN, LABEL, MOD, NIL, NOT,
        OF, OR, PACKED, PROCEDURE, PROGRAM, RECORD, REPEAT, SET,
        THEN, TO, TYPE, UNTIL, VAR, WHILE, WITH
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

    public class IntegerToken : TokenType
    {
        public override string GetTokenName()
        {
            return "Integer";
        }
    }

    public class RealToken : TokenType
    {
        public override string GetTokenName()
        {
            return "Real";
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
        private PascalTokenReservedEnum _reservedEnum;

        public ReservedWordToken(PascalTokenReservedEnum reservedEnum)
            : base(reservedEnum.ToString())
        {
            _reservedEnum = reservedEnum;
        }

        public ReservedWordToken(string reservedEnum)
            : base(reservedEnum)
        {
            PascalTokenReservedEnum enumReturn;
            PascalTokenReservedEnum.TryParse(reservedEnum,true,out  enumReturn);
            _reservedEnum = enumReturn;

        }

        public PascalTokenReservedEnum ReservedEnum
        {
            get { return _reservedEnum; }
        }

        public override string GetTokenName()
        {
            return ReservedEnum.ToString();
        }
    }


}
