using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Messages
{
    public enum MessageType
    {
        SOURCE_LINE, SYNTAX_ERROR,
        PARSER_SUMMARY, INTERPRETER_SUMMARY, COMPILER_SUMMARY,
        MISCELLANEOUS, TOKEN,
        ASSIGN, FETCH, BREAKPOINT, RUNTIME_ERROR,
        CALL, RETURN,
    }


    public class Message
    {

        public string text;
        public object obj;
        public MessageType messageType;

        public Message(string text)
        {
            this.text = text;
        }

        public Message(MessageType type, Object obj)
        {
            this.messageType = type;
            this.obj = obj;

        }

    }
}
