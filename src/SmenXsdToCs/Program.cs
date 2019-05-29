using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenXsdToCs
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                try
                {
                    // Get the namespace for the schema.
                    //CodeNamespace ns = options.XsdFile.ProcessXsd(options.Namespace); //args[0].ProcessXsd(args[1]);

                    Console.Write(" Creating CS file...");
                    Processor.XsdToCs(options.XsdFile, "CIM", options.OutputFile);
                    Console.Write(" Created! {0}", options.OutputFile);
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
