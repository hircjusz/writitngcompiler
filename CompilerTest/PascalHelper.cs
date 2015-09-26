using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend;
using Compiler;
using Compiler.Factory;
using Compiler.Messages;
using Intermediate.Code;
using Intermediate.Symbols;

namespace CompilerTest
{
    public class PascalHelper
    {
         private  Parser parser;
        private Source source;
        private ICode iCode;
        private ISymTab symTab;
        private IBackend _backend;


        public  Parser Pascal(string operation, string filepath, string flags)
        {
            source = new Source(filepath);
            parser = FrontenedFactory.CreateParser("Pascal", "top-down", source);
            var tokenEventHandler = new TokenEventHandler();
            
            parser.MessageEvents += tokenEventHandler.HandleMessage;
            _backend = BackendFactory.Createbackend(operation);
            
            parser.Parse();
            source.Close();
            return parser;
        }
    }
}
