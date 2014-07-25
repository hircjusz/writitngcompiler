using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compiler;
using Compiler.Core;
using Backend;
using Compiler.Factory;
using Compiler.Messages;

namespace ConsoleApp
{
    public class Pascal
    {

        private Parser parser;
        private Source source;
        private ICode iCode;
        private SymTab symTab;
        private IBackend backend;


        public Pascal(string operation,string filepath,string flags)
        {
            source = new Source(filepath);
            parser = FrontenedFactory.CreateParser("Pascal", "top-down", source);
            var logger = new LoggerEventHandler();
            parser.MessageEvents += logger.HandleMessage;

            backend = BackendFactory.Createbackend(operation);

            parser.Parse();
            source.Close();

            iCode = parser.Code;
            symTab = parser.SymTab;
            backend.Process(iCode, symTab);
        
        }

    }
}
