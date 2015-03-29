using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Utility
{
    public class CrossReferencer
    {
        readonly StringBuilder builder=new StringBuilder();

        public string Info
        {
            get { return builder.ToString(); }
        }

        public void Print(SymTabStack symTabStack)
        {


        }


    }
}
