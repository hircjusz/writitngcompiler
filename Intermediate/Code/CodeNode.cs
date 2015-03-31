using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Code
{
    public interface ICodeNode
    {
        CodeNodeTypeEnum Type { get; }
        ICodeNode Parent { get; set; }
        ICodeNode AddChild(ICodeNode node);
        IList<ICodeNode> Children { get; set; }
        void SetAttribute(CodeKeyEnum key, Object value);
        Object GetAttribute(CodeKeyEnum key);
        ICodeNode Copy();
    }

    public class CodeNode : Dictionary<CodeKeyEnum, Object>, ICodeNode
    {
        private readonly CodeNodeTypeEnum _type;

        public CodeNode(CodeNodeTypeEnum type)
        {
            _type = type;
            Parent = null;
            Children = new List<ICodeNode>();
        }

        public ICodeNode Parent { get; set; }

        public IList<ICodeNode> Children { get; set; }

        public CodeNodeTypeEnum Type
        {
            get { return _type; }
        }

        public ICodeNode AddChild(ICodeNode node)
        {
            if (node != null)
            {
                Children.Add(node);
                ((CodeNode)node).Parent = this;
            }
            return node;
        }


        public void SetAttribute(CodeKeyEnum key, object value)
        {
            Add(key, value);
        }

        public object GetAttribute(CodeKeyEnum key)
        {
            return this[key];
        }

        public ICodeNode Copy()
        {
            var copy = CodeFactory.CreateICodeNode(_type);
            foreach (var key in this.Keys)
            {
                copy.SetAttribute(key, this[key]);
            }
            return copy;
        }

        public override string ToString()
        {
            return _type.ToString();
        }
    }
}
