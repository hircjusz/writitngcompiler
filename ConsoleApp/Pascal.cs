using Compiler;
using Backend;
using Compiler.Factory;
using Compiler.Messages;
using Intermediate.Code;
using Intermediate.Symbols;

namespace ConsoleApp
{
    public class Pascal
    {

        private Parser parser;
        private Source source;
        private ICode iCode;
        private ISymTab symTab;
        private IBackend backend;


        public Pascal(string operation,string filepath,string flags)
        {
            source = new Source(filepath);
            parser = FrontenedFactory.CreateParser("Pascal", "top-down", source);
            //var logger = new LoggerEventHandler();
            //parser.MessageEvents += logger.HandleMessage;
            var tokenEventHandler = new TokenEventHandler();
            parser.MessageEvents += tokenEventHandler.HandleMessage;

            backend = BackendFactory.Createbackend(operation);

            parser.Parse();
            source.Close();

            iCode = parser.Code;
            symTab = parser.SymTab;
            //backend.Process(iCode, symTab);
        
        }

    }
}
