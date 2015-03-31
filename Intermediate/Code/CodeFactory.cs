using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Code
{
    public class CodeFactory
    {
        public static ICode CreateICode()
        {
            return new Code();
        }

        public static ICodeNode CreateICodeNode(CodeNodeTypeEnum type)
        {
            return new CodeNode(type);
        }
    }
}
