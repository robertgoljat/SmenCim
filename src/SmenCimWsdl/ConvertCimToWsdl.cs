using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmenCimWsdl
{
    public class ConvertCimToWsdl
    {
        private List<string> _verbs = new List<string>() { "Get", "Send", "Receive", "Reply", "Request", "Execute" };
        //private Dictionary<string, string> _typesToReplace = new Dictionary<string, string>()
        //{
        //    { "Boolean", "xs:boolean" }
        //};

        public List<string> Verbs
        {
            get
            {
                return _verbs;
            }
        }

        public string BeautifyVerb(string verb)
        {
            if (!_verbs.Contains(verb.UppercaseFirst()))
            {
                return "";
            }
            
            return _verbs.Where(_ => _ == verb.UppercaseFirst()).Single();
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

        public string CreateArtifacts_Profile(string nounFile, string outXsdPath)
        {
            if (!File.Exists(nounFile))
                throw new Exception($"Noun file '{nounFile}' doesn't exist!");

            if (!Directory.Exists(outXsdPath))
                throw new Exception($"Directory '{outXsdPath}' doesn't exist!");

            string data = "";
            
            data = nounFile.ReadDataFromFile();

            data = data.Replace("type=\"\"", "");

            var nmspc = GetProfilesNamespace(data);

            if (nmspc != "")
            {
                data = data.Replace($"type=\"{nmspc}:Boolean\"", "type =\"xs:boolean\"");
                data = data.Replace($"type=\"{nmspc}:String\"", "type =\"xs:string\"");
                data = data.Replace($"type=\"{nmspc}:Integer\"", "type =\"xs:integer\"");
                data = data.Replace($"type=\"{nmspc}:Decimal\"", "type =\"xs:decimal\"");
                data = data.Replace($"type=\"{nmspc}:Float\"", "type =\"xs:float\"");
                data = data.Replace($"type=\"{nmspc}:Double\"", "type =\"xs:double\"");
                data = data.Replace($"type=\"{nmspc}:DateTime\"", "type =\"xs:dateTime\"");
                data = data.Replace($"type=\"{nmspc}:Duration\"", "type =\"xs:duration\"");
                data = data.Replace($"type=\"{nmspc}:Date\"", "type =\"xs:date\"");
                data = data.Replace($"type=\"{nmspc}:Time\"", "type =\"xs:time\""); 
            }

            data = data.Replace($"type=\"Boolean\"", "type =\"xs:boolean\"");
            data = data.Replace($"type=\"String\"", "type =\"xs:string\"");
            data = data.Replace($"type=\"Integer\"", "type =\"xs:integer\"");
            data = data.Replace($"type=\"Decimal\"", "type =\"xs:decimal\"");
            data = data.Replace($"type=\"Float\"", "type =\"xs:float\"");
            data = data.Replace($"type=\"Double\"", "type =\"xs:double\"");
            data = data.Replace($"type=\"DateTime\"", "type =\"xs:dateTime\"");
            data = data.Replace($"type=\"Duration\"", "type =\"xs:duration\"");
            data = data.Replace($"type=\"Date\"", "type =\"xs:date\"");
            data = data.Replace($"type=\"Time\"", "type =\"xs:time\"");

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
        public string CreateArtifacts_NounMessage(string verb, string noun, string outPath)
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
                
                data = data.Replace(@"{Information_Object_Name}#", noun).Replace(@"{Information_Object_Name}", noun);

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
        public string GetProfilesNamespace(string data)
        {
            var nmspc = "";
            int start = 0, end = 0;

            while (true)
            {
                start = data.IndexOf("xmlns:", start);

                if (start == -1)
                {
                    nmspc = "";

                    break;
                }

                end = data.IndexOf("=", start);

                nmspc = data.Substring(start + 6, end - start - 6);

                if (nmspc != "xs")
                    break;

                start = end;
            }
            
            return nmspc;
        }
    }
}
