using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backrooms.Data {
    public class MongoConnectService {
        public async Task<List<RoomsData>> GetRoomsData(string id) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<RoomsData>("rooms");
            var filter = Builders<RoomsData>.Filter.Where(x => x.owner == id && x.settings.ContainsKey("isArchived") == false);
            var result = await collection.Find(filter).ToListAsync();
            return result;
        }
        public async Task<Rooms> GetCurrentRoom(string category_id) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<Rooms>("rooms");
            var filter = Builders<Rooms>.Filter.Eq("category", category_id);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task SaveSession(Session session) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collectionExists = database.ListCollectionNames().ToList().Contains("sessions");
            if(!collectionExists) {
                database.CreateCollection("sessions");
            }
            database.GetCollection<Session>("sessions").InsertOne(session);
        }
        public async Task<Session> GetSession(string token, string ipv4) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<Session>("sessions");
            var filter = Builders<Session>.Filter.Where(x => x.token == token && x.ipv4 == ipv4);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
        public async Task SaveChanges(Changes changes) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collectionExists = database.ListCollectionNames().ToList().Contains("changes");
            if(!collectionExists) {
                database.CreateCollection("changes");
            }
            database.GetCollection<Changes>("changes").InsertOne(changes);
        }
    }
}