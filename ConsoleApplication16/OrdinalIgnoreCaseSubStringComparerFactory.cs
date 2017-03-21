namespace ConsoleApplication16
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;
    using Sigil;

    public class OrdinalIgnoreCaseSubStringComparerEx : IEqualityComparer<SubString>
    {
        public int GetHashCode(SubString s)
        {
            return 0;
        }

        public bool Equals(SubString x, SubString y)
        {
            return sd(x, y);
        }

        static readonly Func<SubString, SubString, bool> sd = CompileAndCreate();

        public static Func<SubString, SubString, bool> CompileAndCreate()
        {
            Emit<Func<SubString, SubString, bool>> emiter = Emit<Func<SubString, SubString, bool>>.NewDynamicMethod(typeof(OrdinalIgnoreCaseSubStringComparerEx));
            MethodInfo method = typeof(TextInfo).GetMethod("CompareOrdinalIgnoreCaseEx", BindingFlags.NonPublic | BindingFlags.Static, null, new[] { typeof(string), typeof(int), typeof(string), typeof(int), typeof(int), typeof(int) }, null);
            FieldInfo sourceField = typeof(SubString).GetField("source", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo offsetField = typeof(SubString).GetField("offset", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo lengthField = typeof(SubString).GetField("length", BindingFlags.Instance | BindingFlags.NonPublic);
            emiter.LoadArgument(0);
            emiter.LoadField(sourceField);
            emiter.LoadArgument(0);
            emiter.LoadField(offsetField);
            emiter.LoadArgument(1);
            emiter.LoadField(sourceField);
            emiter.LoadArgument(1);
            emiter.LoadField(offsetField);
            emiter.LoadArgument(0);
            emiter.LoadField(lengthField);
            emiter.LoadArgument(0);
            emiter.LoadField(lengthField);
            emiter.Call(method);
            emiter.LoadConstant(0);
            emiter.CompareEqual();
            emiter.Return();

            return emiter.CreateDelegate();
        }
    }
}