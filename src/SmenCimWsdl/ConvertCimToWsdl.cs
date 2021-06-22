using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmenCimWsdl
{
    public class ConvertCimToWsdl
    {
        public List<string> Verbs { get; } = new List<string>() { "Get", "Send", "Receive", "Reply", "Request", "Execute" };

        public string BeautifyVerb(string verb)
        {
            if (!Verbs.Contains(verb.UppercaseFirst()))
            {
                return "";
            }
            
            return Verbs.Where(_ => _ == verb.UppercaseFirst()).Single();
        }

        public string GetNoun(string nounFile)
        {
            if (!File.Exists(nounFile))
            {
                throw new Exception($"Noun File '{nounFile}' doesn't exist!");
            }

            return Path.GetFileNameWithoutExtension(nounFile);
        }
        public string GetOutPath(string outPath)
        {
            var path = outPath != null ? outPath : "";

            return Path.GetFullPath(Path.IsPathRooted(path) ? path : Path.Combine(Directory.GetCurrentDirectory(), path));
        }
        public string CheckAndCreateOutPath(string outPath)
        {
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
                Console.WriteLine($" --> Directory '{outPath}' was created!");
            }
            else
            {
                Console.WriteLine($" --> Directory '{outPath}' already exists!");
            }

            return outPath;
        }

        public string CreateArtifacts_Profile(string nounFile, string outXsdPath, out string noun2, out string targetNamespace)
        {
            noun2 = "";
            targetNamespace = "";

            if (!File.Exists(nounFile))
                throw new Exception($"Noun file '{nounFile}' doesn't exist!");

            if (!Directory.Exists(outXsdPath))
                throw new Exception($"Directory '{outXsdPath}' doesn't exist!");

            string data = "";
            
            data = nounFile.ReadDataFromFile();

            data = data.ReplaceEATypes();

            targetNamespace = data.GetTargetNamespace();
            noun2 = targetNamespace.GetNounFromTargetNamespace();

            return data.WriteDataToDisk(Path.Combine(outXsdPath, Path.GetFileName(nounFile)));
        }
        public string CreateArtifacts_Message(string outPath)
        {
            try
            {
                var data = "Message.xsd".ReadDataFromEmbeddedResource();
                
                return data.WriteDataToDisk(Path.Combine(outPath, "Message.xsd"));
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");
            }

            return "";
        }
        public string CreateArtifacts_NounMessage(string verb, string noun, string noun2, string outPath)
        {
            try
            {
                string data = "", nameVerb = "";

                if (verb == "Get" || verb == "Reply")
                {
                    data = "GetReplyMessage.xsd".ReadDataFromEmbeddedResource();
                    nameVerb = "Get";
                }
                else if (verb == "Send" || verb == "Receive" || verb == "Request" || verb == "Execute")
                    data = "SendReceiveReplyRequestExecuteMessage.xsd".ReadDataFromEmbeddedResource();
                else
                    throw new Exception($"Wrong verb '{verb}'");

                data = data.ReplaceInformationObjectName(noun, noun2);

                return data.WriteDataToDisk(Path.Combine(outPath, $"{nameVerb}{noun}Message.xsd"));
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");
            }

            return "";
        }
        public string CreateArtifacts_NounMessage(string verb, string noun, string noun2, string outPath, string targetNamespace)
        {
            try
            {
                string data = "", nameVerb = "";

                if (verb == "Get" || verb == "Reply")
                {
                    data = "GetReplyMessage2.xsd".ReadDataFromEmbeddedResource();
                    nameVerb = "Get";
                }
                else if (verb == "Send" || verb == "Receive" || verb == "Request" || verb == "Execute")
                    data = "SendReceiveReplyRequestExecuteMessage2.xsd".ReadDataFromEmbeddedResource();
                else
                    throw new Exception($"Wrong verb '{verb}'");

                data = data.ReplaceInformationObjectName(noun, noun2, targetNamespace);

                return data.WriteDataToDisk(Path.Combine(outPath, $"{nameVerb}{noun}Message.xsd"));
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");
            }

            return "";
        }
        public string CreateArtifacts_Wsdl(string verb, string noun, string outPath)
        {
            try
            {
                string data = "";

                if (verb == "Get")
                    data = "GetWSDL.wsdl".ReadDataFromEmbeddedResource();
                else if (verb == "Request" || verb == "Execute")
                    data = "RequestExecuteWSDL.wsdl".ReadDataFromEmbeddedResource().Replace(@"{Request | Execute}", verb);
                else if (verb == "Send" || verb == "Receive" || verb == "Reply")
                    data = "SendReceiveReplyWSDL.wsdl".ReadDataFromEmbeddedResource().Replace(@"{Send | Receive | Reply}", verb);
                else
                    throw new Exception($"Wrong verb '{verb}'");

                data = data.Replace(@"{Information_Object_Name}#", noun).Replace(@"{Information_Object_Name}", noun);

                return data.WriteDataToDisk(Path.Combine(outPath, $"{verb}{noun}Message.wsdl"));
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");
            }

            return "";
        }

    }
}
