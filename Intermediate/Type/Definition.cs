using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intermediate.Type
{
    public class Definition
    {

        private DefinitionEnum _def = DefinitionEnum.UNDEFINED;

        public Definition(DefinitionEnum def)
        {
            this._def = def;
        }

        public string GetText()
        {
            return _def.ToString().ToLower();
        }
    }


    public enum DefinitionEnum
    {
     CONSTANT,
        TYPE,VARIABLE,PROGRAM, PROCEDURE,FUNCTION,UNDEFINED,
        FIELD,VALUE_PARAM,VAR_PARAM,ENUMERATION_CONSTANT
    }
}
