using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Code
{
    public interface ICode
    {
        ICodeNode SetRoot(ICodeNode node);
        ICodeNode GetRoot();
    }

    public class Code : ICode
    {
        private ICodeNode _codeNode;

        public ICodeNode SetRoot(ICodeNode node)
        {
            _codeNode = node;
            return _codeNode;
        }

        public ICodeNode GetRoot()
        {
            return _codeNode;
        }
    }
}
