using System.IO;
using System.Text;
using FormatConverter.Convertion.Abstract;

namespace FormatConverter.Convertion.Serializer
{
    public sealed class JsonSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;

        public JsonSerializer()
        {
            _jsonSerializer = new Newtonsoft.Json.JsonSerializer();
        }

        public string Serialize(object contents)
        {
            StringBuilder sb = new StringBuilder();
            _jsonSerializer.Serialize(new StringWriter(sb), contents);

            return sb.ToString();
        }
    }
}
