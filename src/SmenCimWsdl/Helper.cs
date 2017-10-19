using System;
using System.IO;
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
    }
}
