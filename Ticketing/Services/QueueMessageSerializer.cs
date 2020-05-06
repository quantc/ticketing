using Newtonsoft.Json;
using Ticketing.Services.Interfaces;

namespace Ticketing.Services
{
    public class QueueMessageSerializer : ISerializer
    {
        public string Serialize(object toSerialize)
        {
            var serialized = JsonConvert.SerializeObject(toSerialize);
            return serialized;
        }

        public T Deserialize<T>(string serialized)
        {
            var result = JsonConvert.DeserializeObject<T>(serialized);
            return result;
        }
    }
}