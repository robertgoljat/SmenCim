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
        public static void XsdToCs(string xsdFile, string targetNamespace, string outputFile, SrvcType serviceType)
        {
            if (!File.Exists(xsdFile))
                throw new Exception($"Xsd file doesn't exist! Path: {xsdFile}");

            if (targetNamespace == "")
                throw new Exception($"Target namespace is not defined!");

            if (outputFile == "")
                throw new Exception($"Output file is not defined!");

            // Get the namespace for the schema.
            CodeNamespace ns = xsdFile.ProcessXsd(targetNamespace);

            ns.Imports.AddRange(new CodeNamespaceImport[] { new CodeNamespaceImport("System.Runtime.Serialization") });

            var names = new List<string>();

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
                                "System.Xml.Serialization.XmlIgnoreAttribute",
                                "System.Xml.Serialization.XmlAnyElementAttribute",
                                "System.ComponentModel.DefaultValueAttribute",
                                "System.Xml.Serialization.XmlAttributeAttribute"
                            });

                            if (!(member is CodeConstructor))
                            {
                                member.CustomAttributes.Add(new string[]
                                {
                                    "DataMember"
                                });
                            }
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
                else
                {
                    var xxx = "unknown";
                }

                names.Add(type.Name);
            }

            if (serviceType == SrvcType.Get)
            {
                var getrequestmessage = names.WildcardSearch("Get*RequestMessageType").SingleOrDefault();
                var responsemessage = names.WildcardSearch("*ResponseMessageType").SingleOrDefault();
                var faultmessage = names.WildcardSearch("*FaultMessageType").SingleOrDefault();

                if (getrequestmessage == null)
                    throw new Exception("Can't find Get*RequestMessage!");

                if (responsemessage == null)
                    throw new Exception("Can't find ResponseMessage!");

                if (faultmessage == null)
                    throw new Exception("Can't find FaultMessage!");

                var noun = getrequestmessage.NounFromWildcard("Get*RequestMessageType");

                if (string.IsNullOrEmpty(noun))
                    throw new Exception("Unknown noun!");

                ns.Types.Add(CreateClass("Get", noun, "Request"));
                ns.Types.Add(CreateClass("Get", noun, "Response", true));
            }
            else if (serviceType == SrvcType.Reply)
            {
                var requestmessage = names.WildcardSearch("*RequestMessageType").SingleOrDefault();
                var responsemessage = names.WildcardSearch("*ResponseMessageType").SingleOrDefault();
                var faultmessage = names.WildcardSearch("*FaultMessageType").SingleOrDefault();

                if (requestmessage == null)
                    throw new Exception("Can't find Get*RequestMessage!");

                if (responsemessage == null)
                    throw new Exception("Can't find ResponseMessage!");

                if (faultmessage == null)
                    throw new Exception("Can't find FaultMessage!");

                var noun = requestmessage.NounFromWildcard("*RequestMessageType");

                if (string.IsNullOrEmpty(noun))
                    throw new Exception("Unknown noun!");

                ns.Types.Add(CreateClass("Created", noun, "Event", true));
                ns.Types.Add(CreateClass("Changed", noun, "Event", true));
                ns.Types.Add(CreateClass("Canceled", noun, "Event", true));
                ns.Types.Add(CreateClass("Closed", noun, "Event", true));
                ns.Types.Add(CreateClass("Deleted", noun, "Event", true));
            }
            else if (serviceType == SrvcType.Request)
            {
                var getrequestmessage = names.WildcardSearch("*RequestMessageType").SingleOrDefault();
                var responsemessage = names.WildcardSearch("*ResponseMessageType").SingleOrDefault();
                var faultmessage = names.WildcardSearch("*FaultMessageType").SingleOrDefault();

                if (getrequestmessage == null)
                    throw new Exception("Can't find Get*RequestMessage!");

                if (responsemessage == null)
                    throw new Exception("Can't find ResponseMessage!");

                if (faultmessage == null)
                    throw new Exception("Can't find FaultMessage!");

                var noun = getrequestmessage.NounFromWildcard("*RequestMessageType");

                if (string.IsNullOrEmpty(noun))
                    throw new Exception("Unknown noun!");

                ns.Types.Add(CreateClass("Create", noun, "Request", true));
                ns.Types.Add(CreateClass("Create", noun, "Response", true));

                ns.Types.Add(CreateClass("Change", noun, "Request", true));
                ns.Types.Add(CreateClass("Change", noun, "Response", true));

                ns.Types.Add(CreateClass("Cancel", noun, "Request", true));
                ns.Types.Add(CreateClass("Cancel", noun, "Response", true));

                ns.Types.Add(CreateClass("Close", noun, "Request", true));
                ns.Types.Add(CreateClass("Close", noun, "Response", true));

                ns.Types.Add(CreateClass("Delete", noun, "Request", true));
                ns.Types.Add(CreateClass("Delete", noun, "Response", true));
            }

            // Create the appropriate generator for the language.
            //CodeDomProvider provider = new Microsoft.CSharp.CSharpCodeProvider();

            // Write the code to the output file.
            using (StreamWriter sw = new StreamWriter(outputFile, false))
            {
                CodeDomProvider.CreateProvider("cs").GenerateCodeFromNamespace(ns, sw, new CodeGeneratorOptions());
            }
        }

        static CodeTypeDeclaration CreateClass(string prefix, string noun, string suffix, bool ignorePrefixType = false)
        {
            CodeTypeDeclaration getrequest = new CodeTypeDeclaration($"{prefix}{noun}{suffix}")
            {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.Public
            };

            getrequest.CustomAttributes.Add(new string[] { "DataContract" });

            string _prefix = ignorePrefixType ? "" : prefix;

            getrequest.Members.Add(CreateField($"{_prefix}{noun}{suffix}Message".ToLowercaseFirst(), $"{_prefix}{noun}{suffix}MessageType"));
            getrequest.Members.Add(CreateProperty($"{_prefix}{noun}{suffix}Message", $"{_prefix}{noun}{suffix}MessageType", $"{_prefix}{noun}{suffix}Message".ToLowercaseFirst()));

            return getrequest;
        }
        static CodeMemberProperty CreateProperty(string name, string type, string fieldLink)
        {
            CodeMemberProperty getrequestproperty = new CodeMemberProperty()
            {
                Name = name,    //Name = $"{prefix}{noun}RequestMessage",
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Type = new CodeTypeReference(type), //Type = new CodeTypeReference($"{prefix}{noun}RequestMessageType"),
                HasSet = true,
                HasGet = true
            };

            getrequestproperty.CustomAttributes.Add(new string[] { "DataMember" });

            if (fieldLink != "")
            {
                getrequestproperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldLink)));

                getrequestproperty.SetStatements.Add(new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldLink),
                    //new CodeVariableReferenceExpression(fieldLink), 
                    new CodeVariableReferenceExpression("value")));
            }

            return getrequestproperty;
        }
        static CodeMemberField CreateField(string name, string type)
        {
            CodeMemberField getrequestfield = new CodeMemberField()
            {
                Attributes = MemberAttributes.Private,
                Name = name,
                Type = new CodeTypeReference(type)
            };

            return getrequestfield;
        }
    }
}
