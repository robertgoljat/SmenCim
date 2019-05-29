using CommandLine;
using CommandLine.Text;

namespace SmenCimWsdl
{
    class Options
    {
        [Option('n', "noun", Required = true, HelpText = "Noun file (CIM profile) in xsd format! The name without extension is usaed as a message noun!")]
        public string NounFile { get; set; }

        [Option('v', "verb", HelpText = "Wsdl verb type (Get, Send, Receive, Reply, Request, Execute)", Required = true)]
        public string WsdlVerb { get; set; }

        [Option('o', "out", HelpText = "Out file path", Required = false)]
        public string OutPath { get; set; }

        [Option('c', "continue", HelpText = "Skip 'Press any key to continue!'", Required = false, DefaultValue = false)]
        public bool Continue { get; set; }

        //[Option(DefaultValue = 0, HelpText ="", Required = true)]
        //public long Offset { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("SmenCIM - cimtowsdl", "1.0.1"),
                Copyright = new CopyrightInfo("SmenStorSys", 2017),
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            //help.AddPreOptionsLine("Copyright ©  2015 - 2017 SmenStorSys All rights reserved.");
            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("Usage: cimtowsdl -v VERB -n NOUNFILENAME.XSD");
            help.AddOptions(this);

            return help;
        }
    }

    enum WsdlVerbs
    {
        Get,
        Send,
        Receive,
        Reply,
        Request,
        Execute
    }
}
