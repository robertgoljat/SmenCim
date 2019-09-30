using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SmenXsdToCs
{
    public static class Helper
    {
        public static CodeAttributeDeclarationCollection Remove(this CodeAttributeDeclarationCollection attributes, string[] names)
        {
            if (names == null || names.Length == 0)
                return attributes;

            var toDelete = new List<CodeAttributeDeclaration>();

            foreach (CodeAttributeDeclaration attr in attributes)
            {
                if (names.Where(_ => _.ToUpperInvariant() == attr.Name.ToUpperInvariant()).Any())
                {
                    toDelete.Add(attr);
                }
            }

            if (toDelete.Count > 0)
            {
                foreach (CodeAttributeDeclaration attr in toDelete)
                {
                    attributes.Remove(attr);
                }
            }

            return attributes;
        }
        public static CodeAttributeDeclarationCollection Add(this CodeAttributeDeclarationCollection attributes, string[] names)
        {
            if (names == null || names.Length == 0)
                return attributes;

            var toAdd = new List<CodeAttributeDeclaration>();

            if (attributes.Count > 0)
            {
                names
                    .Where(_ => attributes.Contains(new CodeAttributeDeclaration(_)) == false)?
                    .ToList()
                    .ForEach(_ => toAdd.Add(new CodeAttributeDeclaration(_)));
            }
            else
            {
                names
                    .ToList()
                    .ForEach(_ => toAdd.Add(new CodeAttributeDeclaration(_)));
            }

            if (toAdd.Count > 0)
            {
                attributes.AddRange(toAdd.ToArray());
            }

            return attributes;
        }

        public static bool CleanXsd(string xsdFile, string outXsdFile)
        {
            try
            {
                XmlSchema xsd;

                using (FileStream fs = new FileStream(xsdFile, FileMode.Open))
                {
                    xsd = XmlSchema.Read(fs, null);
                    xsd.Compile(null);
                }

                var cleanedNamespaces = xsd.Namespaces
                    .ToArray()
                    .Select(_ =>
                    {
                        if (_.Namespace.EndsWith("#"))
                        {
                            return new XmlQualifiedName(_.Name, _.Namespace.TrimEnd('#'));
                        }
                        else
                        {
                            return _;
                        }
                    })
                    .ToArray();

                xsd.Namespaces = new XmlSerializerNamespaces(cleanedNamespaces);

                if (xsd.TargetNamespace.EndsWith("#"))
                {
                    xsd.TargetNamespace = xsd.TargetNamespace.TrimEnd('#');
                }

                using (FileStream fs = new FileStream(outXsdFile, FileMode.CreateNew))
                {
                    xsd.Write(fs);
                }

                return true;
            }
            catch (Exception e1)
            {
                return false;
            }
        }
        public static CodeNamespace ProcessXsd(this string xsdFile, string targetNamespace)
        {
            // Load the XmlSchema and its collection.
            XmlSchema xsd;

            using (FileStream fs = new FileStream(xsdFile, FileMode.Open))
            {
                xsd = XmlSchema.Read(fs, null);
                xsd.Compile(null);
            }

            XmlSchemas schemas = new XmlSchemas();
            schemas.Add(xsd);

            // Create the importer for these schemas.
            XmlSchemaImporter importer = new XmlSchemaImporter(schemas);

            // System.CodeDom namespace for the XmlCodeExporter to put classes in.
            CodeNamespace ns = new CodeNamespace(targetNamespace);
            XmlCodeExporter exporter = new XmlCodeExporter(ns);

            // Iterate schema top-level elements and export code for each.
            foreach (XmlSchemaElement element in xsd.Elements.Values)
            {
                // Import the mapping first.
                XmlTypeMapping mapping = importer.ImportTypeMapping(element.QualifiedName);

                // Export the code finally.
                exporter.ExportTypeMapping(mapping);
            }

            return ns;
        }

        public static IEnumerable<string> WildcardSearch(this IEnumerable<string> data, string q)
        {
            //string regexSearch = q
            //    .Replace("*", ".+")
            //    .Replace("%", ".+")
            //    .Replace("#", "\\d")
            //    .Replace("@", "[a-zA-Z]")
            //    .Replace("?", "\\w");

            //Regex regex = new Regex(regexSearch);

            //return data
            //    .Where(s => regex.IsMatch(s));

            var regEx = "^" + Regex.Escape(q).Replace("\\*", ".*").Replace("\\?", ".") + "$"; 

            return data.Where(item => Regex.IsMatch(item, regEx));
        }
        public static string NounFromWildcard(this string name, string q)
        {
            var splitted = q.Split('*', '%', '#', '@', '?').Where(_ => _ != "").ToList();

            string str = name;

            splitted
                .ForEach(_ => 
                {
                    str = str.Replace(_, "");
                });

            return str;
        }
        public static string ToLowercaseFirst(this string data)
        {
            return data.Substring(0, 1).ToLower() + data.Substring(1);
        }

        public static string ReadDataFromEmbeddedResource(this string resource)
        {
            Assembly _assembly;
            StreamReader _textStreamReader;

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream($"SmenXsdToCs.Resources.{resource}"));

                var data = _textStreamReader.ReadToEnd();

                return data;
            }
            catch (Exception e1)
            {
                Console.WriteLine($" --> Error accessing resources! Message: {e1.Message}");

                throw new Exception("ReadDataFromEmbeddedResource exception...");
            }
        }
        public static string WriteDataToDisk(this string data, string filePath, bool overwrite)
        {
            try
            {
                if (File.Exists(filePath) && overwrite == false)
                    return filePath;

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
    }
}
