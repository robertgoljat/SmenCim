using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenCimWsdl
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var convert = new ConvertCimToWsdl();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var wsdlVerb = convert.BeautifyVerb(options.WsdlVerb);

                if (wsdlVerb == "")
                {
                    Console.WriteLine($"Verb '{options.WsdlVerb}' is not correct!");
                    Console.WriteLine();
                    Console.Write("Press any key to continue!");
                    Console.ReadKey();

                    return;
                }

                try
                {
                    var outPath = convert.CheckAndCreateOutPath(convert.GetOutPath(options.OutPath));
                    var outXsdPath = convert.CheckAndCreateOutPath(Path.Combine(outPath, "xsd"));
                    var noun = convert.GetNoun(options.NounFile);

                    Console.WriteLine($"Verb: {wsdlVerb}");
                    Console.WriteLine($"Noun: {convert.GetNoun(options.NounFile)} File: '{options.NounFile}'");
                    Console.WriteLine($"Path: '{outPath}' Xsd path: '{outXsdPath}'");
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write(" 1. Create message...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Message(outXsdPath));
                    Console.WriteLine();

                    Console.Write(" 2. Create profie...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Profile(options.NounFile, outXsdPath));
                    Console.WriteLine();

                    Console.Write(" 3. Create noun file...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_NounMessage(wsdlVerb, noun, outXsdPath));
                    Console.WriteLine();

                    Console.Write(" 4. Create WSDL...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Wsdl(wsdlVerb, noun, outPath));
                    Console.WriteLine();

                    //convert.CreateArtifacts_Wsdl(wsdlVerb, noun, outPath);

                    //convert.CreateArtifacts_Message(outXsdPath);
                    //convert.CreateArtifacts_NounMessage(wsdlVerb, noun, outXsdPath);
                }
                catch (Exception e1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error! Message: {e1.Message}");
                    Console.ResetColor();
                }
                
                //// consume Options instance properties
                //if (options.Verbose)
                //{
                //    Console.WriteLine(options.InputFile);
                //    Console.WriteLine(options.MaximumLength);
                //}
                //else
                //    Console.WriteLine("working ...");

                Console.WriteLine();
                Console.Write("Press any key to continue!");
                Console.ReadKey();
            }
            else
            {
                // Display the default usage information
                //Console.WriteLine(options.GetUsage());
            }
        }
    }
}
