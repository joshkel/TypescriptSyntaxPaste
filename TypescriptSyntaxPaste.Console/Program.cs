using System;
using System.IO;
using TypescriptSyntaxPaste.VSIX;

namespace TypescriptSyntaxPaste.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string filename in args)
            {
                var cScript = File.ReadAllText(filename);
                CSharpToTypescriptConverter csharpToTypescriptConverter = new CSharpToTypescriptConverter();
                var typescript = csharpToTypescriptConverter.ConvertToTypescript(cScript, new MySettingStore());

                System.Console.WriteLine(typescript);
            }
        }
    }


    class MySettingStore : ISettingStore
    {
        public bool AddIPrefixInterfaceDeclaration => false;
        public bool IsConvertListToArray => true;
        public bool IsConvertMemberToCamelCase => true;
        public bool IsConvertToInterface => true;
        public bool IsInterfaceOptionalProperties => false;
        public TypeNameReplacementData[] ReplacedTypeNameArray => new TypeNameReplacementData[]
        {
            new TypeNameReplacementData() { OldTypeName="DateTime", NewTypeName="Date" },
        };
    }
}
