using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SmenSplitCs
{
    public static class Helper
    {
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
        public static CodeNamespace ProcessCs(this string csFile, string targetNamespace)
        {
            // System.CodeDom namespace for the XmlCodeExporter to put classes in.
            CodeNamespace ns = new CodeNamespace(targetNamespace);

            //using (TextReader rd = File.OpenText(csFile))
            //{
            //    CodeCompileUnit xxx = CodeDomProvider.CreateProvider("cs").Parse(rd); 
            //}

            CodeCompileUnit xxx = CodeDomProvider.CreateProvider("cs").Parse(File.OpenText(csFile));

            var code = File.ReadAllText(csFile);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(code);
            SyntaxNode root = tree.GetRoot();
            var children = root.ChildNodes().ToList();

            var children2 = children[1];

            //CSharpSyntaxRewriter

            //var attr = root.ChildNodes().Where(_ => _.a)

            //File.WriteAllText("../../../GetMeterReadingsMessageXXX.cs", root.ToFullString());

            return ns;
        }
    }
}
