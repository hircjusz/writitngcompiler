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
        MISSING_SEMICOLON,UNEXPECTED_TOKEN,MISSING_RIGHT_PARENT,
        IDENTIFIER_UNDEFINED
    }
}
