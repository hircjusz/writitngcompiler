using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Code;
using Intermediate.Symbols;

namespace Utility
{
    public class ParserTreePrint
    {
        readonly StringBuilder _builder = new StringBuilder();

        public ParserTreePrint()
        {
            _builder.AppendLine("INTERMEDIATE CODE");
        }

        private void StringLevelBuilder(string value, int level, bool attribute = false)
        {
            if (attribute)
            {
                _builder.Append(string.Format(" {0}", value));
            }
            else
            {
                var space = string.Empty;
                for (int i = 0; i < level; i++)
                {
                    space += " ";
                }
                _builder.Append(string.Format("\n{0}{1}", space, value));
            }
        }

        public string Print(ICodeNode nodeCode, int level = 0)
        {
            var attributes = nodeCode.Attributes;
            StringLevelBuilder(string.Format("+{0}", nodeCode.Type), level);

            foreach (var attr in attributes)
            {
                _builder.Append("{");
                var symTabEntry = attr.Value as SymTabEntry;
                if (symTabEntry != null)
                {
                    StringLevelBuilder(string.Format("{0}", symTabEntry.GetName()), level, true);
                    foreach (var key in symTabEntry.Keys)
                    {
                        StringLevelBuilder(string.Format("{0} {1}", key, symTabEntry[key]), level, true);
                    }
                }
                else
                {
                    StringLevelBuilder(string.Format("{0} {1}", attr.Key, attr.Value), level, true);
                }
                _builder.Append("}");
            }

            var childeNodes = nodeCode.Children;

            foreach (var childeNode in childeNodes)
            {
                Print(childeNode, level + 1);
            }

            return _builder.ToString();
        }


    }
}
