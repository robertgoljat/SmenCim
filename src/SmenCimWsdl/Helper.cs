using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SmenCimWsdl
{
    public static class Helper
    {
        public static string ReadDataFromFile(this string filePath)
        {
            StreamReader _textStreamReader;

            try
            {
                _textStreamReader = new StreamReader(filePath);

                return _textStreamReader.ReadToEnd();
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing file! Message: {e1.Message}");

                throw new Exception($"ReadDataFromFile exception... {e1.Message}");
            }
        }
        public static string ReadDataFromEmbeddedResource(this string resource)
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

        public static string WriteDataToDisk(this string data, string filePath)
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

                throw new Exception($"WriteDataToDisk exception... {e1.Message}");
            }
        }

        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static string GetNounFromTargetNamespace(this string targetNamespace)
        {
            var parts = targetNamespace.Split('/');

            if (parts.Length == 0)
                return "";

            return parts.Last();
        }

        public static string ReplaceEATypes(this string data)
        {
            data = data.Replace("type=\"\"", "");

            string profileNamespace = data.GetProfilesNamespace();

            if (profileNamespace != "")
            {
                data = data.Replace($"type=\"{profileNamespace}:Boolean\"", "type =\"xs:boolean\"");
                data = data.Replace($"type=\"{profileNamespace}:String\"", "type =\"xs:string\"");
                data = data.Replace($"type=\"{profileNamespace}:Integer\"", "type =\"xs:integer\"");
                data = data.Replace($"type=\"{profileNamespace}:Decimal\"", "type =\"xs:decimal\"");
                data = data.Replace($"type=\"{profileNamespace}:Float\"", "type =\"xs:float\"");
                data = data.Replace($"type=\"{profileNamespace}:Double\"", "type =\"xs:double\"");
                data = data.Replace($"type=\"{profileNamespace}:DateTime\"", "type =\"xs:dateTime\"");
                data = data.Replace($"type=\"{profileNamespace}:Duration\"", "type =\"xs:duration\"");
                data = data.Replace($"type=\"{profileNamespace}:Date\"", "type =\"xs:date\"");
                data = data.Replace($"type=\"{profileNamespace}:Time\"", "type =\"xs:time\"");
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

            return data;
        }

        public static string ReplaceInformationObjectName(this string data, string noun, string noun2)
        {
            if (noun == noun2)
                data = data.Replace(@"{Information_Object_Name}#", noun).Replace(@"{Information_Object_Name}", noun);
            else
                data = data.Replace(@"{Information_Object_Name}", noun);

            return data;
        }
        public static string ReplaceInformationObjectName(this string data, string noun, string noun2, string targetNamespace)
        {
            if (noun == noun2)
                data = data
                    .Replace(@"{Information_Object_Name}#", noun)
                    .Replace(@"{Information_Object_Name}", noun)
                    .Replace(@"{Information_Object_NameSpace}", targetNamespace);
            else
                data = data
                    .Replace(@"{Information_Object_Name}", noun)
                    .Replace(@"{Information_Object_NameSpace}", targetNamespace);

            return data;
        }

        public static string GetProfilesNamespace(this string data)
        {
            var nmspc = "";
            int start = 0, end = 0;
            List<string> nmspcList = new List<string>();

            while (true)
            {
                start = data.IndexOf("xmlns:", start);

                if (start == -1)
                {
                    nmspc = "";

                    break;
                }

                end = data.IndexOf("=", start);

                //nmspc = data.Substring(start + 6, end - start - 6);
                nmspcList.Add(data.Substring(start + 6, end - start - 6));

                //if (nmspc != "xs")
                //    break;

                start = end;
            }

            nmspc = nmspcList.Where(_ => _ != "xs").FirstOrDefault();

            return nmspc != null ? nmspc : "";
        }
        public static string GetTargetNamespace(this string data)
        {
            var nmspc = "";
            int start = 0, end = 0;

            while (true)
            {
                start = data.IndexOf("targetNamespace=\"", start);

                if (start == -1)
                {
                    nmspc = "";

                    break;
                }

                end = data.IndexOf("\"", start + 17);

                nmspc = data.Substring(start + 17, end - start - 17);

                break;
            }

            return nmspc;
        }
    }
}
