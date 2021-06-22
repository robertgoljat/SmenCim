using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmenSplitCs
{
    class Options
    {
        [Option('i', "inputfile", Required = true, HelpText = "Input file (cs)!")]
        public string InputFile { get; set; }

        [Option('o', "outputfile", Required = true, HelpText = "Output file (cs)!")]
        public string OutputFile { get; set; }

        [Option('n', "namespace", Required = false, DefaultValue = "CIM", HelpText = "Target namespace!")]
        public string Namespace { get; set; }

        [Option('c', "continue", HelpText = "Skip 'Press any key to continue!'", Required = false, DefaultValue = false)]
        public bool Continue { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("SmenCIM - splitcs", "1.0.0"),
                Copyright = new CopyrightInfo("SmenStorSys", 2019),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("Usage: splitcs -i INPUTFILE.CS -o OUTPUTFILE.CS -n NMSP");
            help.AddOptions(this);

            return help;
        }
    }
}
