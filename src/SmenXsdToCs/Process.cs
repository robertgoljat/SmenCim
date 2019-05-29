using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SmenXsdToCs
{
    public sealed class Processor
    {
        public static void XsdToCs(string xsdFile, string targetNamespace, string outputFile)
        {
            if (!File.Exists(xsdFile))
                throw new Exception($"Xsd file doesn't exist! Path: {xsdFile}");

            if (targetNamespace == "")
                throw new Exception($"Target namespace is not defined!");

            if (outputFile == "")
                throw new Exception($"Output file is not defined!");

            // Get the namespace for the schema.
            CodeNamespace ns = xsdFile.ProcessXsd(targetNamespace);

            foreach (CodeTypeDeclaration type in ns.Types)
            {
                if (type.IsClass)
                {
                    type.IsPartial = false;
                    type.CustomAttributes.Remove(new string[] 
                    {
                        "System.SerializableAttribute",
                        "System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Diagnostics.DebuggerStepThroughAttribute",
                        "System.ComponentModel.DesignerCategoryAttribute",
                        "System.Xml.Serialization.XmlTypeAttribute",
                        "System.Xml.Serialization.XmlRootAttribute"
                    }).Add(new string[] 
                    {
                        "DataContract"
                    });

                    foreach (CodeTypeMember member in type.Members)
                    {
                        if ((member.Attributes & MemberAttributes.AccessMask) == MemberAttributes.Public)
                        {
                            member.CustomAttributes.Remove(new string[]
                            {
                                "System.Xml.Serialization.XmlElementAttribute",
                                "System.Xml.Serialization.XmlIgnoreAttribute"
                            }).Add(new string[]
                            {
                                "DataMember"
                            });
                        }                         
                    }
                }
                else if (type.IsEnum)
                {
                    type.CustomAttributes.Remove(new string[]
                    {
                        "System.SerializableAttribute",
                        "System.CodeDom.Compiler.GeneratedCodeAttribute",
                        "System.Diagnostics.DebuggerStepThroughAttribute",
                        "System.ComponentModel.DesignerCategoryAttribute",
                        "System.Xml.Serialization.XmlTypeAttribute",
                        "System.Xml.Serialization.XmlRootAttribute"
                    }).Add(new string[]
                    {
                        "DataContract"
                    });

                    foreach (CodeTypeMember member in type.Members)
                    {
                        member.CustomAttributes.Add(new string[]
                        {
                            "EnumMember"
                        });
                    }
                }
            }

            // Create the appropriate generator for the language.
            //CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();

            // Write the code to the output file.
            using (StreamWriter sw = new StreamWriter(outputFile, false))
            {
                CodeDomProvider.CreateProvider("cs").GenerateCodeFromNamespace(ns, sw, new CodeGeneratorOptions());
                //provider.CreateGenerator().GenerateCodeFromNamespace(ns, sw, new CodeGeneratorOptions());
            }
        }
    }
}
