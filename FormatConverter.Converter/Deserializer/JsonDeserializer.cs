using System.IO;
using FormatConverter.Convertion.Abstract;
using Newtonsoft.Json;

namespace FormatConverter.Convertion.Deserializer
{
    public sealed class JsonDeserializer : IDeserializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _jsonSerializer;

        public JsonDeserializer()
        {
            _jsonSerializer = new Newtonsoft.Json.JsonSerializer();
        }

        public object Deserilalize(string contents) =>
           _jsonSerializer.Deserialize(new JsonTextReader(new StringReader(contents)));
    }
}
