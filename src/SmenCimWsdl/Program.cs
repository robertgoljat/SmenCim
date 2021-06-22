using System;
using System.IO;

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
                    LogError($"Verb '{options.WsdlVerb}' is not correct!", true);
                    Console.WriteLine();

                    if (!options.Continue)
                    {
                        Console.Write("Press any key to continue!");
                        Console.ReadKey();
                    }

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
                    Console.WriteLine($"UseTargetNamespace: {(options.UseTargetNamespace ? "Yes" : "No")}");
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write(" 1. Creating message...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Message(outXsdPath));
                    Console.WriteLine();

                    string targetNamespace = "";
                    string noun2 = "";

                    Console.Write(" 2. Creating profie...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Profile(options.NounFile, outXsdPath, out noun2, out targetNamespace));
                    Console.WriteLine();

                    if (!options.UseTargetNamespace)
                    {
                        Console.Write(" 3. Creating noun file...");
                        Console.Write(" Created! {0}", convert.CreateArtifacts_NounMessage(wsdlVerb, noun, noun2, outXsdPath));
                        Console.WriteLine(); 
                    }
                    else
                    {
                        Console.Write(" 3. Creating noun file (with target namespace)...");
                        Console.Write(" Created! {0}", convert.CreateArtifacts_NounMessage(wsdlVerb, noun, noun2, outXsdPath, targetNamespace));
                        Console.WriteLine();
                    }

                    Console.Write(" 4. Creating WSDL...");
                    Console.Write(" Created! {0}", convert.CreateArtifacts_Wsdl(wsdlVerb, noun, outPath));
                    Console.WriteLine();

                }
                catch (Exception e1)
                {
                    LogError(e1.Message);
                }

                Console.WriteLine();

                if (!options.Continue)
                {
                    Console.Write("Press any key to continue!");
                    Console.ReadKey();
                }
            }
        }

        static void LogError(string Message, bool OverridePretext = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(OverridePretext ? $"{Message}" : $"Error! Message: {Message}");
            Console.ResetColor();
        }
    }
}
