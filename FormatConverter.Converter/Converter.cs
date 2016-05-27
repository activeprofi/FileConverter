using System;
using FormatConverter.Convertion.Abstract;
using FormatConverter.Convertion.Deserializer;
using FormatConverter.Convertion.Serializer;
using File = FormatConverter.Convertion.Utils.File;

namespace FormatConverter.Convertion
{
    public sealed class Converter
    {
        private readonly string _source;
        private readonly string _destination;

        public Converter(string source, string destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Convert()
        {
            string sourceFormat = _extensionFrom(_source);
            string destinationFormat = _extensionFrom(_destination);
            string sourceContents = new File(_source).Content();

            string destinationFileContent = _convertToFormat(sourceContents, sourceFormat, destinationFormat);
            File.WriteFile(_destination, destinationFileContent);

        }

        private string _convertToFormat(string sourceContent, string sourceFormat, string destinationFormat)
        {
            IDeserializer deseralizer = _deserializerFromFormat(sourceFormat);
            ISerializer serializer = _serializerFromFormat(destinationFormat);

            object deserialized = deseralizer.Deserilalize(sourceContent);
            return serializer.Serialize(deserialized);
        }

        private IDeserializer _deserializerFromFormat(string sourceFormat)
        {
            switch (sourceFormat)
            {
                case "yaml":
                    return new YamlDeserializer();
                case "json":
                    return new JsonDeserializer();
                default:
                    throw new ArgumentException("Unknown format", sourceFormat);
            }
        }

        private ISerializer _serializerFromFormat(string destinationFormat)
        {
            switch (destinationFormat)
            {

                case "yaml":
                    return new YamlSerializer();
                case "json":
                    return new JsonSerializer();
                default:
                    throw new ArgumentException("Unknown format", destinationFormat);

            }
        }

        private string _extensionFrom(string source) =>
            System.IO.Path.GetExtension(source).Remove(0, 1);
    }
}
