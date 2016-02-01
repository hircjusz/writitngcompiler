using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Intermediate.Type
{
    public class TypeSpec : Dictionary<TypeKeyEnum, Object>, ITypeSpec
    {
        private TypeFormEnum form;
        private ISymTabEntry identifier;


        public TypeSpec(TypeFormEnum form)
        {
            this.form = form;
            this.identifier = null;
        }


        public TypeSpec(string value)
        {
            this.form = TypeFormEnum.ARRAY;
            var indexType = new TypeSpec(TypeFormEnum.SUBRANGE);
            indexType.SetAttribute(TypeKeyEnum.AARRAY_INDEX_TYPE, Predefined.IntegerType);
            indexType.SetAttribute(TypeKeyEnum.SUBRANGE_MIN_VALUE, 0);
            indexType.SetAttribute(TypeKeyEnum.SUBRANGE_MAX_VALUE, value.Length);
            SetAttribute(TypeKeyEnum.AARRAY_INDEX_TYPE, indexType);
            SetAttribute(TypeKeyEnum.ARRAY_ELEMENT_COUNT, value.Length);
            SetAttribute(TypeKeyEnum.ARRAY_ELEMENT_TYPE, Predefined.CharType);
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

        public object GetAttribute(TypeKeyEnum key)
        {
            if (this.ContainsKey(key))
            {
                return this[key];
            }
            return null;

        }

        public bool IsPascalString()
        {
            if (form != TypeFormEnum.ARRAY) return false;
            var elmtType = (ITypeSpec)GetAttribute(TypeKeyEnum.ARRAY_ELEMENT_TYPE);
            var indexType = (ITypeSpec)GetAttribute(TypeKeyEnum.AARRAY_INDEX_TYPE);
            return (elmtType == Predefined.CharType && indexType == Predefined.IntegerType);
        }


        public void SetAttribute(TypeKeyEnum key, object obj)
        {
            if (ContainsKey(key))
            {
                throw new Exception("Podany klucz istnieje");
            }
            Add(key, obj);
        }
    }


    public interface ITypeSpec
    {
        TypeFormEnum GetForm();
        ISymTabEntry GetIdentifier();
        void SetIdentifier(ISymTabEntry entry);
        Object GetAttribute(TypeKeyEnum key);
        void SetAttribute(TypeKeyEnum key, Object obj);
        bool IsPascalString();


    }

    public enum TypeFormEnum
    {
        SCALAR, ENUMERATION, SUBRANGE, ARRAY, RECORD
    }

    public enum TypeKeyEnum
    {
        //Enumeration
        ENUMERATION_CONSTANTS,

        //SUbrange
        SUBRANGE_INDEX_TYPE, SUBRANGE_MIN_VALUE, SUBRANGE_MAX_VALUE,

        //ARRAY
        AARRAY_INDEX_TYPE, ARRAY_ELEMENT_TYPE, ARRAY_ELEMENT_COUNT,

        //REcord
        RECORD_SYMBOL,RECORD_SYMTAB

    }
}
