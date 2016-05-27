using System.IO;
using System.Text;
using FormatConverter.Convertion.Abstract;

namespace FormatConverter.Convertion.Serializer
{
    public sealed class YamlSerializer : ISerializer
    {
        private readonly YamlDotNet.Serialization.Serializer _yamlSerializer;

        public YamlSerializer()
        {
            _yamlSerializer = new YamlDotNet.Serialization.Serializer();
        }

        public string Serialize(object contents)
        {
            StringBuilder sb = new StringBuilder();
            _yamlSerializer.Serialize(new StringWriter(sb), contents);

            return sb.ToString();
        }
    }
}
