using MongoDB.Bson;
using Newtonsoft.Json;

namespace BlueGrassDigitalAPI.Models.Person
{
    public class PersonResponse
    {
        [JsonProperty("_id")]
        public MongoDbId _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressCountry { get; set; }
        public string AddressCity { get; set; }
        public string? ProfilePicture { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
    }

}
