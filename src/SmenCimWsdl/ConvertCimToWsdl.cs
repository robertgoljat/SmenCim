using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmenCimWsdl
{
    public class ConvertCimToWsdl
    {
        private List<string> _verbs = new List<string>() { "Get", "Send", "Receive", "Reply", "Request", "Execute" };

        public List<string> Verbs
        {
            get
            {
                return _verbs;
            }
        }

        public string BeautifyVerb(string verb)
        {
            if (!_verbs.Contains(UppercaseFirst(verb)))
            {
                return "";
            }
            
            return _verbs.Where(_ => _ == UppercaseFirst(verb)).Single();
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

            data = ReadDataFromFile(nounFile);

            data = data.Replace("type=\"\"", "");

            //File.Copy(nounFile, Path.Combine(outXsdPath, nounFile));

            //return Path.Combine(outXsdPath, nounFile);

            return WriteDataToDisk(data, Path.Combine(outXsdPath, nounFile));
        }
        public string CreateArtifacts_Message(string outPath)
        {
            try
            {
                var data = ReadDataFromEmbeddedResource("Message.xsd");
                
                return WriteDataToDisk(data, Path.Combine(outPath, "Message.xsd"));
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
                    data = ReadDataFromEmbeddedResource("GetReplyMessage.xsd");
                    nameVerb = "Get";
                }
                else if (verb == "Send" || verb == "Receive" || verb == "Request" || verb == "Execute")
                    data = ReadDataFromEmbeddedResource("SendReceiveReplyRequestExecuteMessage.xsd");
                else
                    throw new Exception($"Wrong verb '{verb}'");
                
                data = data.Replace(@"{Information_Object_Name}#", noun).Replace(@"{Information_Object_Name}", noun);

                return WriteDataToDisk(data, Path.Combine(outPath, $"{nameVerb}{noun}Message.xsd"));
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
                    data = ReadDataFromEmbeddedResource("GetWSDL.wsdl");
                else if (verb == "Request" || verb == "Execute")
                    data = ReadDataFromEmbeddedResource("RequestExecuteWSDL.wsdl").Replace(@"{Request | Execute}", verb);
                else if (verb == "Send" || verb == "Receive" || verb == "Reply")
                    data = ReadDataFromEmbeddedResource("SendReceiveReplyWSDL.wsdl").Replace(@"{Send | Receive | Reply}", verb);
                else
                    throw new Exception($"Wrong verb '{verb}'");

                data = data.Replace(@"{Information_Object_Name}#", noun).Replace(@"{Information_Object_Name}", noun);

                return WriteDataToDisk(data, Path.Combine(outPath, $"{verb}{noun}Message.wsdl"));
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");
            }

            return "";
        }

        private string ReadDataFromFile(string filePath)
        {
            StreamReader _textStreamReader;

            try
            {
                _textStreamReader = new StreamReader(filePath);

                var data = _textStreamReader.ReadToEnd();
                
                return data;
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing file! Message: {e1.Message}");

                throw new Exception("ReadDataFromFile exception...");
            }
        }
        private string ReadDataFromEmbeddedResource(string resource)
        {
            Assembly _assembly;
            StreamReader _textStreamReader;

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream($"SmenCimWsdl.Resources.{resource}"));

                var data = _textStreamReader.ReadToEnd();

                return data;
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");

                throw new Exception("ReadDataFromEmbeddedResource exception...");
            }
        }
        private string WriteDataToDisk(string data, string filePath)
        {
            try
            {
                var _textStreamWriter = new StreamWriter(filePath);
                _textStreamWriter.Write(data);
                _textStreamWriter.Flush();

                return filePath;
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error witing data to disk! Message: {e1.Message}");

                throw new Exception("WriteDataToDisk exception...");
            }
        }

        private string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
