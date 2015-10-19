using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Type
{
    public class TypeFactory
    {

        public static ITypeSpec CreateType(TypeFormEnum form)
        {
            return new TypeSpec(form);
        }

        //public static ITypeSpec CreateStringType(string form)
        //{
        //    return new TypeSpec(form);
        //}

    }
}
