using System.IO;
using FormatConverter.Convertion.Abstract;

namespace FormatConverter.Convertion.Deserializer
{
    public sealed class YamlDeserializer : IDeserializer
    {
        private readonly YamlDotNet.Serialization.Deserializer _yamlDeserializer;

        public YamlDeserializer()
        {
            _yamlDeserializer = new YamlDotNet.Serialization.Deserializer();
        }

        public object Deserilalize(string contents) =>
            _yamlDeserializer.Deserialize(new StringReader(contents));

    }
}
