using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backrooms.Data {
    public class dbconnService {
        public async Task<List<RoomsData>> GetRoomsData(string id) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            /var client = new MongoClient("mongodb+srv://mosmo0220:rf6w29Drdbhie1pl@cluster0.0aenioa.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("DiscordBackrooms");
            Console.WriteLine(database.ListCollectionsAsync().Result.ToList().ToJson());
            var collection = database.GetCollection<RoomsData>("rooms");
            var filter = Builders<RoomsData>.Filter.Eq("owner", id);
            var result = await collection.Find(filter).ToListAsync();
            Console.WriteLine(result.ToJson());
            return result;
        }
    }
}