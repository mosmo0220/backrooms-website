using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backrooms.Data {
    public class dbconnService {
        public async Task<RoomsData> GetRoomsData(string id) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<RoomsData>("Rooms");
            var filter = Builders<RoomsData>.Filter.Eq("id", id);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
    }
}