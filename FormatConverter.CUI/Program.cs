using System;
using System.IO;
using System.Text;
using YamlDotNet.Serialization;
using Newtonsoft.Json;
using FormatConverter.Convertion;

namespace FormatConverter.CUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) PrintUsageInformation();
                if (args.Length < 2) Console.WriteLine("Error: not enough arguments!");
                if (args.Length == 2) new Converter(args[0], args[1]).Convert();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void PrintUsageInformation()
        {
            Console.WriteLine("convert util => Using:");
            Console.WriteLine("\tconvert source output");
            Console.WriteLine("\t\t*source - xml, json, yaml file ");
            Console.WriteLine("\t\t*output - xml, json, yaml file ");
            Console.WriteLine("\nExample: convert in.xml out.json");
        }
    }
}
