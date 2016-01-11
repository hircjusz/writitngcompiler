using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Intermediate.Symbols;

namespace Intermediate.Type
{
    public class Predefined
    {
        public static ITypeSpec IntegerType;
        public static ITypeSpec RealType;
        public static ITypeSpec BooleanType;
        public static ITypeSpec CharType;

        public static void Initialise(ISymTabStack symTabStack)
        {
            InitializeTypes(symTabStack);
        }

        public static void InitializeTypes(ISymTabStack symTabStack)
        {
            var integerId = symTabStack.EnterLocal("integer");
            var integerType = TypeFactory.CreateType(TypeFormEnum.SCALAR);
            integerType.SetIdentifier(integerId);
            integerId.SetDefinition(new Definition(DefinitionEnum.TYPE));
            integerId.SetTypeSpec(integerType);
            Predefined.IntegerType = integerType;

            var realId = symTabStack.EnterLocal("real");
            var realType = TypeFactory.CreateType(TypeFormEnum.SCALAR);
            realType.SetIdentifier(realId);
            realId.SetDefinition(new Definition(DefinitionEnum.TYPE));
            realId.SetTypeSpec(realType);
            Predefined.RealType = realType;

            var booleanId = symTabStack.EnterLocal("boolean");
            var booleanType = TypeFactory.CreateType(TypeFormEnum.ENUMERATION);
            booleanType.SetIdentifier(booleanId);
            booleanId.SetDefinition(new Definition(DefinitionEnum.TYPE));
            booleanId.SetTypeSpec(booleanType);

            var charId = symTabStack.EnterLocal("char");
            var charType = TypeFactory.CreateType(TypeFormEnum.ENUMERATION);
            charType.SetIdentifier(charId);
            charId.SetDefinition(new Definition(DefinitionEnum.TYPE));
            charId.SetTypeSpec(charType);
            CharType = charType;

            var falseId = symTabStack.EnterLocal("false");
            falseId.SetDefinition(new Definition(DefinitionEnum.ENUMERATION_CONSTANT));
            falseId.SetTypeSpec(booleanType);
            falseId.SetAttribute(SymTabEnum.CONSTANT_VALUE, 0);

            var trueId = symTabStack.EnterLocal("true");
            trueId.SetDefinition(new Definition(DefinitionEnum.ENUMERATION_CONSTANT));
            trueId.SetTypeSpec(booleanType);
            trueId.SetAttribute(SymTabEnum.CONSTANT_VALUE, 0);
            booleanType.SetAttribute(TypeKeyEnum.ENUMERATION_CONSTANTS, new []{falseId,trueId});
            BooleanType = booleanType;

        }




    }
}
