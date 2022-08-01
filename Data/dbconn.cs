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
        public string category { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Session {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId id { get; set; }
        public string token { get; set; }
        public string ipv4 { get; set; }
        public UserData user { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Rooms {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public List<Chat> chats { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Chat {
        public string channelid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int voice_max { get; set; }
    }
    [BsonIgnoreExtraElements]
    public class Changes {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId id { get; set; }
        public Rooms Room { get; set; }
        public List<string> chatToRemove { get; set;}
    }
}