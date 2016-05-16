namespace Compiler.Exception
{
    public class ParserException
    {

        private Token token;
        private ParserExceptionEnum exceptionType;

        public ParserException(Token token, ParserExceptionEnum exceptionEnum)
        {
            this.token = token;
            this.exceptionType = exceptionEnum;

        }
    }

    public enum ParserExceptionEnum
    {
        MISSING_SEMICOLON,UNEXPECTED_TOKEN,MISSING_RIGHT_PARENT,MISSING_END,MISSING_BEGIN,
        IDENTIFIER_UNDEFINED, MISSING_DO, MISSING_OF,MISSING_EQUALS, INVALID_CONSTANT, INVALID_TYPE, INVALID_INDEX_TYPE,
        MISSING_DOT_DOT, INCOMPATIBLE_TYPES, INVALID_SUBRANGE_TYPE, MIN_GT_MAX, IDENTIFIER_REDEFINED,
        MISSING_IDENTIFIER, NO_TYPE_IDENTIFIER, MISSING_LEFT_BRACKET, MISSING_RIGHT_BRACKET, MISSING_COLON

    }
}
