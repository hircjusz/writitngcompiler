using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interpreter;

namespace Backend
{
    public class BackendFactory
    {
        public static IBackend Createbackend(string operation) {

            if (operation == "compile") {
                return new CodeGenerator();
            }

            if (operation == "execute") {
                return new Executor();
            }
            throw new Exception("Please provide correct opeartion type compiler or execute");
        }
    }
}
