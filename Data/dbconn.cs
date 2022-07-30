using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Backrooms.Data {
    [BsonIgnoreExtraElements]
    public class RoomsData {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId id { get; set; } 
        public string name { get; set; }
        public string owner { get; set; }
    }
    public class Session {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId id { get; set; }
        public string token { get; set; }
        public UserData user { get; set; }
        public List<RoomsData> rooms { get; set; }
    }
}