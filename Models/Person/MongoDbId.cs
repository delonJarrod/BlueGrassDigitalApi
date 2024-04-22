using Newtonsoft.Json;

namespace BlueGrassDigitalAPI.Models.Person
{
    public class MongoDbId
    {
        [JsonProperty("$oid")]
        public string Oid { get; set; }
    }
}
