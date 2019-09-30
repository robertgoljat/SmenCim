using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SmenXsdToCs
{
    public sealed class Processor
    {
        public static void XsdToCsWithServices(string xsdFileGet, string xsdFile, string targetNamespace, string outputFile)
        {
            var noun = GetNoun(xsdFile);

            CreateCommonFiles(targetNamespace, outputFile);

            XsdToCsWithService(xsdFileGet, $"{targetNamespace}.Get{noun}", GetOutFileWithPrefix(outputFile, "Get"), SrvcType.Get);
            XsdToCsWithService(xsdFile, $"{targetNamespace}.Reply{noun}", GetOutFileWithPrefix(outputFile, "Reply"), SrvcType.Reply);
            XsdToCsWithService(xsdFile, $"{targetNamespace}.Request{noun}", GetOutFileWithPrefix(outputFile, "Request"), SrvcType.Request);
        }
        public static void XsdToCs(string xsdFile, string targetNamespace, string outputFile, SrvcType serviceType, bool withService)
        {
            if (withService)
            {
                CreateCommonFiles(targetNamespace, xsdFile);
                XsdToCsWithService(xsdFile, targetNamespace, outputFile, serviceType);
            }
            else
                XsdToCsWithoutService(xsdFile, targetNamespace, outputFile, serviceType);
        }
        public static void XsdToCsWithoutService(string xsdFile, string targetNamespace, string outputFile, SrvcType serviceType)
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

            var names = CleanAndReplace(ns);
            
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
                ns.Types.Add(CreateClass("", noun, "Response", true));
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

            // Write the code to the output file.
            using (StreamWriter sw = new StreamWriter(outputFile, false))
            {
                CodeDomProvider.CreateProvider("cs").GenerateCodeFromNamespace(ns, sw, new CodeGeneratorOptions());
            }
        }
        public static void XsdToCsWithService(string xsdFile, string targetNamespace, string outputFile, SrvcType serviceType)
        {
            if (!File.Exists(xsdFile))
                throw new Exception($"Xsd file doesn't exist! Path: {xsdFile}");

            if (targetNamespace == "")
                throw new Exception($"Target namespace is not defined!");

            if (outputFile == "")
                throw new Exception($"Output file is not defined!");

            // COMMON

            // Get the namespace for the schema.
            CodeNamespace ns = xsdFile.ProcessXsd(targetNamespace);

            ns.Imports.AddRange(new CodeNamespaceImport[] { new CodeNamespaceImport("System.Runtime.Serialization") });

            var names = CleanAndReplace(ns);

            DeleteClasses(ns, toDeleteClasses);
            DeleteEnums(ns, toDeleteEnums);

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

                #region Repair

                ns.Imports.Add(new CodeNamespaceImport("System"));
                ns.Imports.Add(new CodeNamespaceImport("System.ServiceModel"));

                DeleteClasses(ns, new List<string>() { $"Get{noun}RequestType" });
                var rt = CreateClassEmpty("Get", noun, "RequestType");
                rt.BaseTypes.Add(new CodeTypeReference("GetRequestType"));
                ns.Types.Add(rt);

                DeleteClasses(ns, new List<string>() { $"{noun}FaultMessageType" });
                rt = CreateClassEmpty("", noun, "FaultMessageType");
                rt.BaseTypes.Add(new CodeTypeReference("FaultMessageType"));
                ns.Types.Add(rt);

                var index = FindType(ns, $"Get{noun}RequestMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IGetRequestMessageType", new CodeTypeReference($"Get{noun}RequestType"), new CodeTypeReference($"{noun}PayloadType")));

                index = FindType(ns, $"{noun}PayloadType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IPayloadType", new CodeTypeReference($"{noun}")));

                index = FindType(ns, $"{noun}ResponseMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IResponseMessageType", new CodeTypeReference($"{noun}PayloadType")));

                #endregion

                #region Create

                ns.Types.Add(CreateClass("Get", noun, "Request"));
                ns.Types.Add(CreateClass("Get", noun, "Response", true));

                ns.Types
                    .Add(CreateInterface($"IGet{noun}Service", new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Get{noun}", $"Get{noun}Request", "request", $"Get{noun}Response")
                    }));

                ns.Types
                    .Add(CreateClassForService($"Get{noun}Service", $"IGet{noun}Service", noun, new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>($"GetHandler", $"Get{noun}Request", $"Get{noun}Response")
                    }, new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Get{noun}", $"Get{noun}Request", "request", $"Get{noun}Response")
                    }));

                #endregion
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

                #region Repair

                ns.Imports.Add(new CodeNamespaceImport("System"));
                ns.Imports.Add(new CodeNamespaceImport("System.ServiceModel"));

                DeleteClasses(ns, new List<string>() { $"{noun}FaultMessageType" });
                var rt = CreateClassEmpty("", noun, "FaultMessageType");
                rt.BaseTypes.Add(new CodeTypeReference("FaultMessageType"));
                ns.Types.Add(rt);

                var index = FindType(ns, $"{noun}RequestMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IRequestMessageType", new CodeTypeReference($"{noun}PayloadType")));

                index = FindType(ns, $"{noun}PayloadType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IPayloadType", new CodeTypeReference($"{noun}")));

                //index = FindType(ns, $"{noun}ResponseMessageType");
                //ns.Types[index].BaseTypes.Add(new CodeTypeReference("IResponseMessageType", new CodeTypeReference($"{noun}PayloadType")));

                index = FindType(ns, $"{noun}EventMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IEventMessageType", new CodeTypeReference($"{noun}PayloadType")));

                #endregion

                #region Create

                ns.Types.Add(CreateClass("", noun, "Response", true));
                index = FindType(ns, $"{noun}ResponseMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IResponseMessageType", new CodeTypeReference($"{noun}PayloadType")));

                ns.Types.Add(CreateClass("Created", noun, "Event", true));
                ns.Types.Add(CreateClass("Changed", noun, "Event", true));
                ns.Types.Add(CreateClass("Canceled", noun, "Event", true));
                ns.Types.Add(CreateClass("Closed", noun, "Event", true));
                ns.Types.Add(CreateClass("Deleted", noun, "Event", true));

                ns.Types
                    .Add(CreateInterface($"IReply{noun}Service", new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Created{noun}", $"Created{noun}Event", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Changed{noun}", $"Changed{noun}Event", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Canceled{noun}", $"Canceled{noun}Event", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Closed{noun}", $"Closed{noun}Event", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Deleted{noun}", $"Deleted{noun}Event", "request", $"{noun}Response")
                    }));

                ns.Types
                    .Add(CreateClassForService($"Reply{noun}Service", $"IReply{noun}Service", noun, new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>($"CreatedHandler", $"Created{noun}Event", $"{noun}Response"),
                        new Tuple<string, string, string>($"ChangedHandler", $"Changed{noun}Event", $"{noun}Response"),
                        new Tuple<string, string, string>($"CanceledHandler", $"Canceled{noun}Event", $"{noun}Response"),
                        new Tuple<string, string, string>($"ClosedHandler", $"Closed{noun}Event", $"{noun}Response"),
                        new Tuple<string, string, string>($"DeletedHandler", $"Deleted{noun}Event", $"{noun}Response")
                    }, new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Created{noun}", $"Created{noun}Event", "request", $"Created{noun}Response"),
                        new Tuple<string, string, string, string>($"Changed{noun}", $"Changed{noun}Event", "request", $"Changed{noun}Response"),
                        new Tuple<string, string, string, string>($"Canceled{noun}", $"Canceled{noun}Event", "request", $"Canceled{noun}Response"),
                        new Tuple<string, string, string, string>($"Closed{noun}", $"Closed{noun}Event", "request", $"Closed{noun}Response"),
                        new Tuple<string, string, string, string>($"Deleted{noun}", $"Deleted{noun}Event", "request", $"Deleted{noun}Response")
                    }));

                #endregion
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

                #region Repair

                ns.Imports.Add(new CodeNamespaceImport("System"));
                ns.Imports.Add(new CodeNamespaceImport("System.ServiceModel"));

                DeleteClasses(ns, new List<string>() { $"{noun}FaultMessageType" });
                var rt = CreateClassEmpty("", noun, "FaultMessageType");
                rt.BaseTypes.Add(new CodeTypeReference("FaultMessageType"));
                ns.Types.Add(rt);

                var index = FindType(ns, $"{noun}RequestMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IRequestMessageType", new CodeTypeReference($"{noun}PayloadType")));

                index = FindType(ns, $"{noun}PayloadType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IPayloadType", new CodeTypeReference($"{noun}")));

                index = FindType(ns, $"{noun}ResponseMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IResponseMessageType", new CodeTypeReference($"{noun}PayloadType")));

                index = FindType(ns, $"{noun}EventMessageType");
                ns.Types[index].BaseTypes.Add(new CodeTypeReference("IEventMessageType", new CodeTypeReference($"{noun}PayloadType")));

                #endregion

                #region Create

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

                ns.Types
                    .Add(CreateInterface($"IRequest{noun}Service", new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Create{noun}", $"Create{noun}Request", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Change{noun}", $"Change{noun}Request", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Cancel{noun}", $"Cancel{noun}Request", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Close{noun}", $"Close{noun}Request", "request", $"{noun}Response"),
                        new Tuple<string, string, string, string>($"Delete{noun}", $"Delete{noun}Request", "request", $"{noun}Response")
                    }));

                ns.Types
                    .Add(CreateClassForService($"Request{noun}Service", $"IRequest{noun}Service", noun, new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>($"CreateHandler", $"Create{noun}Request", $"{noun}Response"),
                        new Tuple<string, string, string>($"ChangeHandler", $"Change{noun}Request", $"{noun}Response"),
                        new Tuple<string, string, string>($"CancelHandler", $"Cancel{noun}Request", $"{noun}Response"),
                        new Tuple<string, string, string>($"CloseHandler", $"Close{noun}Request", $"{noun}Response"),
                        new Tuple<string, string, string>($"DeleteHandler", $"Delete{noun}Request", $"{noun}Response")
                    }, new List<Tuple<string, string, string, string>>()
                    {
                        new Tuple<string, string, string, string>($"Create{noun}", $"Create{noun}Request", "request", $"Create{noun}Response"),
                        new Tuple<string, string, string, string>($"Change{noun}", $"Change{noun}Request", "request", $"Change{noun}Response"),
                        new Tuple<string, string, string, string>($"Cancel{noun}", $"Cancel{noun}Request", "request", $"Cancel{noun}Response"),
                        new Tuple<string, string, string, string>($"Close{noun}", $"Close{noun}Request", "request", $"Close{noun}Response"),
                        new Tuple<string, string, string, string>($"Delete{noun}", $"Delete{noun}Request", "request", $"Delete{noun}Response")
                    }));

                #endregion
            }

            // Write the code to the output file.
            using (StreamWriter sw = new StreamWriter(outputFile, false))
            {
                CodeDomProvider.CreateProvider("cs").GenerateCodeFromNamespace(ns, sw, new CodeGeneratorOptions());
            }
        }
        public static void CreateCommonFiles(string targetNamespace, string outputFile)
        {
            var helpercs = "Helper.cs".ReadDataFromEmbeddedResource();
            helpercs = helpercs.Replace("namespace CIM", $"namespace {targetNamespace}");
            helpercs.WriteDataToDisk(Path.Combine(Path.GetDirectoryName(outputFile), "Helper.cs"), true);

            var commoncs = "Common.cs".ReadDataFromEmbeddedResource();
            commoncs = commoncs.Replace("namespace CIM", $"namespace {targetNamespace}");
            commoncs.WriteDataToDisk(Path.Combine(Path.GetDirectoryName(outputFile), "Common.cs"), true);
        }

        private static List<string> CleanAndReplace(CodeNamespace ns)
        {
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

            return names;
        }
        private static int DeleteClasses(CodeNamespace ns, List<string> toDelete)
        {
            int deleted = 0;

            CodeTypeDeclarationCollection toRemove = new CodeTypeDeclarationCollection();

            foreach (CodeTypeDeclaration type in ns.Types)
            {
                if (toDelete.Contains(type.Name) && type.IsClass)
                {
                    toRemove.Add(type);
                }
            }

            foreach (CodeTypeDeclaration type in toRemove)
            {
                ns.Types.Remove(type);
                deleted++;
            }

            return deleted;
        }
        private static int DeleteEnums(CodeNamespace ns, List<string> toDelete)
        {
            int deleted = 0;

            CodeTypeDeclarationCollection toRemove = new CodeTypeDeclarationCollection();

            foreach (CodeTypeDeclaration type in ns.Types)
            {
                if (toDelete.Contains(type.Name) && type.IsEnum)
                {
                    toRemove.Add(type);
                }
            }

            foreach (CodeTypeDeclaration type in toRemove)
            {
                ns.Types.Remove(type);
                deleted++;
            }

            return deleted;
        }
        private static int FindType(CodeNamespace ns, string name)
        {
            int index = -1;

            foreach (CodeTypeDeclaration type in ns.Types)
            {
                if (type.Name == name)
                {
                    index = ns.Types.IndexOf(type);
                    break;
                }
            }

            return index;
        }
        private static string GetNoun(string xsdFile)
        {
            CodeNamespace ns = xsdFile.ProcessXsd("TEST");

            var names = CleanAndReplace(ns);

            var faultmessage = names.WildcardSearch("*FaultMessageType").SingleOrDefault();

            if (faultmessage == null)
                throw new Exception("Can't find FaultMessage!");

            var noun = faultmessage.NounFromWildcard("*FaultMessageType");

            return noun;
        }
        private static string GetOutFileWithPrefix(string outputFile, string prefix)
        {
            var directory = Path.GetDirectoryName(outputFile);
            var file = Path.GetFileName(outputFile);
            var newfilepath = Path.Combine(directory, $"{prefix}{file}");

            return newfilepath;
        }

        private static CodeTypeDeclaration CreateClass(string prefix, string noun, string suffix, bool ignorePrefixType = false)
        {
            CodeTypeDeclaration getrequest = new CodeTypeDeclaration($"{prefix}{noun}{suffix}")
            {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.Public
            };

            getrequest.CustomAttributes.Add(new string[] { "DataContract" });

            string _prefix = ignorePrefixType ? "" : prefix;

            getrequest.Members.Add(CreateClassField($"{_prefix}{noun}{suffix}Message".ToLowercaseFirst(), $"{_prefix}{noun}{suffix}MessageType"));
            getrequest.Members.Add(CreateClassProperty($"{_prefix}{noun}{suffix}Message", $"{_prefix}{noun}{suffix}MessageType", "DataMember", $"{_prefix}{noun}{suffix}Message".ToLowercaseFirst()));

            return getrequest;
        }
        private static CodeTypeDeclaration CreateClassEmpty(string prefix, string noun, string suffix)
        {
            CodeTypeDeclaration getrequest = new CodeTypeDeclaration($"{prefix}{noun}{suffix}")
            {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.Public
            };

            return getrequest;
        }
        private static CodeTypeDeclaration CreateClassForService(string name, string interfc, string noun, List<Tuple<string, string, string>> functions, List<Tuple<string, string, string, string>> methods)
        {
            CodeTypeDeclaration srvclass = new CodeTypeDeclaration($"{name}")
            {
                IsClass = true,
                TypeAttributes = System.Reflection.TypeAttributes.Public
            };

            if (interfc != "")
                srvclass.BaseTypes.Add(new CodeTypeReference($"{interfc}"));

            foreach (var func in functions)
            {
                srvclass.Members.Add(CreateClassField(func.Item1.ToLowercaseFirst(), $"Func<{func.Item2}, {func.Item3}>"));
                srvclass.Members.Add(CreateClassProperty(func.Item1, $"Func<{func.Item2}, {func.Item3}>", "", func.Item1.ToLowercaseFirst()));
            }

            foreach (var meth in methods)
            {
                srvclass.Members.Add(CreateClassMethod(meth.Item1, meth.Item2, meth.Item3, meth.Item4, noun, ""));
                //srvclass.Members.Add(CreateClassMethod("GetComModuleConfig", "GetComModuleConfigRequest", "request", "GetComModuleConfigResponse", noun, ""));
            }

            return srvclass;
        }
        private static CodeMemberProperty CreateClassProperty(string name, string type, string attribute, string fieldLink)
        {
            CodeMemberProperty property = new CodeMemberProperty()
            {
                Name = name,    //Name = $"{prefix}{noun}RequestMessage",
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Type = new CodeTypeReference(type), //Type = new CodeTypeReference($"{prefix}{noun}RequestMessageType"),
                HasSet = true,
                HasGet = true
            };

            if (attribute != "")
                property.CustomAttributes.Add(new string[] { $"{attribute}" });

            if (fieldLink != "")
            {
                property.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldLink)));

                property.SetStatements.Add(new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldLink),
                    //new CodeVariableReferenceExpression(fieldLink), 
                    new CodeVariableReferenceExpression("value")));
            }

            return property;
        }
        private static CodeMemberProperty CreateClassPropertyEmpty(string name, string type, string attribute)
        {
            CodeMemberProperty property = new CodeMemberProperty()
            {
                Name = name, 
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                Type = new CodeTypeReference(type),
                HasSet = true,
                HasGet = true
            };

            if (attribute != "")
                property.CustomAttributes.Add(new string[] { $"{attribute}" });

            return property;
        }
        private static CodeMemberField CreateClassField(string name, string type)
        {
            CodeMemberField field = new CodeMemberField()
            {
                Attributes = MemberAttributes.Private,
                Name = name,
                Type = new CodeTypeReference(type)
            };

            return field;
        }
        private static CodeMemberMethod CreateClassMethod(string name, string inType, string inName, string outType, string noun, string attribute)
        {
            CodeMemberMethod method = new CodeMemberMethod()
            {
                Name = name,
                Attributes = MemberAttributes.Public | MemberAttributes.Final,
                ReturnType = new CodeTypeReference(outType)

            };

            method.Parameters.Add(new CodeParameterDeclarationExpression(inType, inName));

            if (attribute != "")
                method.CustomAttributes.Add(new string[] { $"{attribute}" });

            CodeTryCatchFinallyStatement try1 = new CodeTryCatchFinallyStatement();
            CodeCatchClause catch1 = new CodeCatchClause("e1");

            try1.TryStatements.Add(new CodeSnippetExpression($"{inName}.{inType}Message.IsHeaderOk(false, false, false)"));
            try1.TryStatements.Add(new CodeSnippetExpression($"{inName}.{inType}Message.IsRequestOk(true, true, true, true)"));
            try1.TryStatements.Add(new CodeSnippetStatement($""));
            try1.TryStatements.Add(new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "GetHandler", new CodeExpression[] { new CodeArgumentReferenceExpression($"{inName}") })));
            
            catch1.Statements.Add(new CodeSnippetStatement(GetErrorReplyStatement(inType, outType, noun)));

            try1.CatchClauses.Add(catch1);

            method.Statements.Add(try1);

            return method;
        }
        
        static CodeTypeDeclaration CreateInterface(string name, List<Tuple<string, string, string, string>> methods)
        {
            CodeTypeDeclaration intrfc = new CodeTypeDeclaration()
            {
                Name = $"{name}",
                IsInterface = true
            };

            intrfc.CustomAttributes.Add(new string[] { "ServiceContract" });

            foreach (var meth in methods)
            {
                intrfc.Members.Add(CreateInterfaceMethod(meth.Item1, meth.Item2, meth.Item3, meth.Item4));
                //intrfc.Members.Add(CreateInterfaceMethod("GetComModuleConfig", "GetComModuleConfigRequest", "request", "GetComModuleConfigResponse"));
            }

            return intrfc;
        }
        static CodeMemberMethod CreateInterfaceMethod(string name, string inType, string inName, string outType)
        {
            CodeMemberMethod method = new CodeMemberMethod()
            {
                Name = name,
                Attributes = MemberAttributes.AccessMask, //isInterface ? MemberAttributes.AccessMask : MemberAttributes.Public | MemberAttributes.Final,
                ReturnType = new CodeTypeReference(outType)

            };

            method.Parameters.Add(new CodeParameterDeclarationExpression(inType, inName));

            method.CustomAttributes.Add(new string[] { "OperationContract" });

            return method;
        }
        static string GetErrorReplyStatement(string inType, string outType, string noun)
        {
            var statement = @"
                return new #GetComModuleConfigResponse()
                {
                    #ComModuleConfigResponseMessage = new #ComModuleConfigResponseMessageType()
                    {
                        Header = new HeaderType()
                        {
                            Verb = request.#GetComModuleConfigRequestMessage.Header.Verb,
                            Noun = request.#GetComModuleConfigRequestMessage.Header.Noun
                        },
                        Reply = new ReplyType()
                        {
                            Result = ReplyTypeResult.FAILED,
                            Error = new ErrorType[] { new ErrorType() { level = ErrorTypeLevel.FATAL, details = e1.Message } }
                        }
                    }
                }; ";

            statement = statement
                .Replace("#GetComModuleConfigResponse", $"{outType}")
                .Replace("#ComModuleConfigResponseMessage", $"{noun}ResponseMessage")
                .Replace("#ComModuleConfigResponseMessageType", $"{noun}ResponseMessageType")
                .Replace("#GetComModuleConfigRequestMessage", $"Get{noun}RequestMessage")
                .Replace("#Get{noun}RequestMessage", $"{inType}Message");
            return statement;
        }

        private static List<string> toDeleteClasses = new List<string>()
        {
            "FaultMessageType",
            "HeaderType",
            "GetRequestType",
            "RequestType",
            "ReplyType",
            "MessageProperty",
            "UserType",
            "ReplayDetectionType",
            "OptionType",
            "OperationType",
            "OperationSet",
            "IdentifiedObject",
            "Name1",
            "NameType1",
            "NameTypeAuthority1",
            "ErrorType",
            "LocationType",
            "Status"
        };
        private static List<string> toDeleteEnums = new List<string>()
        {
            "HeaderTypeContext",
            "HeaderTypeVerb",
            "ReplyTypeResult",
            "ErrorTypeLevel"
        };
    }
}
