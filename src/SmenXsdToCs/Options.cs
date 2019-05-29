using CommandLine;
using CommandLine.Text;

namespace SmenXsdToCs
{
    class Options
    {
        [Option('x', "xsdfile", Required = true, HelpText = "Xsd file!")]
        public string XsdFile { get; set; }

        //[Option('n', "namespace", Required = true, HelpText = "Namespace!")]
        //public string Namespace { get; set; }

        [Option('o', "outputfile", Required = true, HelpText = "Output file (cs)!")]
        public string OutputFile { get; set; }

        [Option('c', "continue", HelpText = "Skip 'Press any key to continue!'", Required = false, DefaultValue = false)]
        public bool Continue { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("SmenCIM - xsdtocs", "1.0.0"),
                Copyright = new CopyrightInfo("SmenStorSys", 2019),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            
            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("Usage: xsdtocs -x XSDFILE.XSD -o OUTPUTFILE.CS");
            help.AddOptions(this);

            return help;
        }
    }
}
