using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using FormatConverter.Convertion.Abstract;
using FormatConverter.Convertion.Deserializer;
using FormatConverter.Convertion.Serializer;

namespace FormatConverter.Convertion
{
    public class Converter : IConverter
    {
        private readonly IDictionary<string, ISerializer> _serializers;
        private readonly IDictionary<string, IDeserializer> _deserializers;

        public Converter(IDictionary<string, ISerializer> serializers, IDictionary<string, IDeserializer> deserializers)
        {
            _serializers = serializers;
            _deserializers = deserializers;
        }

        public void Convert(string source, string destination)
        {
            string sourceFormat = GetExtension(source);
            string destinationFormat = GetExtension(destination);
            string sourceContents = File.ReadAllText(source);
            string destinationFileContent = ConvertToFormat(sourceContents, sourceFormat, destinationFormat);

            File.WriteAllText(destination, destinationFileContent);
        }

        private string ConvertToFormat(string sourceContent, string sourceFormat, string destinationFormat)
        {
            IDeserializer deseralizer = GetDeserializer(sourceFormat);
            ISerializer serializer = GetSerializer(destinationFormat);
            object deserialized = deseralizer.Deserilalize(sourceContent);

            return serializer.Serialize(deserialized);
        }

        private IDeserializer GetDeserializer(string sourceFormat)
        {
            if (_deserializers.ContainsKey(sourceFormat))
            {
                return _deserializers[sourceFormat];
            }

            throw new InvalidOperationException("Extension is not supported");
        }

        private ISerializer GetSerializer(string destinationFormat)
        {
            if (_serializers.ContainsKey(destinationFormat))
            {
                return _serializers[destinationFormat];
            }

            throw new InvalidOperationException("Extension is not supported");
        }

        private static string GetExtension(string source) =>
            Path.GetExtension(source).Remove(0, 1);
    }
}
