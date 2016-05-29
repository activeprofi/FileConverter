using System;
using System.Collections.Generic;
using FormatConverter.Convertion;
using FormatConverter.Convertion.Abstract;
using FormatConverter.Convertion.Deserializer;
using FormatConverter.Convertion.Serializer;
using SimpleInjector;

namespace FormatConverter.CUI
{
    public class Program
    {
        private static readonly Container InjectorContainer = new Container();

        public static void Main(string[] args)
        {
            try
            {
                ConfigureSimpleInjector();

                if (args.Length == 0)
                {
                    PrintUsageInformation();
                }

                if (args.Length < 2)
                {
                    Console.WriteLine("Error: not enough arguments!");
                }
                
                if (args.Length == 2)
                {
                    IConverter converter = InjectorContainer.GetInstance<IConverter>();
                    converter.Convert(args[0], args[1]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR!");
                Console.WriteLine(ex.Message);
            }
        }

        private static void ConfigureSimpleInjector()
        {
            InjectorContainer.Register<IConverter>(() => new Converter(new Dictionary<string, ISerializer>
            {
                { "yaml", new YamlSerializer() },
                { "json", new JsonSerializer() }
            }, new Dictionary<string, IDeserializer>
            {
                { "yaml", new YamlDeserializer() },
                { "json", new JsonDeserializer() }
            }), Lifestyle.Transient);

            InjectorContainer.Verify();
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
