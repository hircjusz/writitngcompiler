using System.Collections.Generic;

namespace Compiler.Exception
{
    public class ExceptionHandler
    {

        private readonly List<ParserException> exceptions = new List<ParserException>();

        public void Register(Token token, ParserExceptionEnum exceptionEnum)
        {
            exceptions.Add(new ParserException(token, exceptionEnum));
        }

        public bool HasException()
        {
            return exceptions.Count > 0;
        }

        public int GetErrorCount()
        {
            return exceptions.Count;
        }
    }
}
