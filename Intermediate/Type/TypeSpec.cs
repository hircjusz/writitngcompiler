using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Intermediate.Type
{
    public class TypeSpec:Dictionary<TypeKeyEnum,Object>,ITypeSpec
    {
        private TypeFormEnum form;
        private ISymTabEntry identifier;


        public TypeSpec(TypeFormEnum form)
        {
            this.form = form;
            this.identifier = null;
        }


        public TypeFormEnum GetForm()
        {
            return form;
        }

        public ISymTabEntry GetIdentifier()
        {
            return identifier;
        }

        public void SetIdentifier(ISymTabEntry entry)
        {
            this.identifier = entry;
        }

        public object GetAttribute( TypeKeyEnum key)
        {
            if (this.ContainsKey(key))
            {
                return this[key];
            }
            return null;

        }

        public bool IsPascalString()
        {
            throw new NotImplementedException();
        }


        public void SetAttribute(TypeKeyEnum key, object obj)
        {
            if (ContainsKey(key))
            {
                throw new Exception("Podany klucz istnieje");
            }
            Add(key,obj);
        }
    }


    public interface ITypeSpec
    {
        TypeFormEnum GetForm();
        ISymTabEntry GetIdentifier();
        void SetIdentifier(ISymTabEntry entry);
        Object GetAttribute(TypeKeyEnum key);
        void SetAttribute(TypeKeyEnum key,Object obj);
        bool IsPascalString();


    }

    public enum TypeFormEnum
    {
        SCALAR, ENUMERATION,SUBRANGE,ARRAY,RECORD
    }

    public enum TypeKeyEnum
    {
        //Enumeration
        ENUMERATION_CONSTANTS,

        //SUbrange
        SUBRANGE_INDEX_TYPE,SUBRANGE_MIN_VALUE,SUBRANGE_MAX_VALUE,

        //ARRAY
        AARRAY_INDEX_TYPE,ARRAY_ELEMENT_TYPE,ARRAY_ELEMENT_COUNT,

        //REcord
        RECORD_SYMBOL

    }
}
