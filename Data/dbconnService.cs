using System;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backrooms.Data {
    public class dbconnService {
        public async Task<List<RoomsData>> GetRoomsData(string id) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<RoomsData>("rooms");
            var filter = Builders<RoomsData>.Filter.Eq("owner", id);
            var result = await collection.Find(filter).ToListAsync();
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
        public async Task<Session> GetSession(string token) {
            var client = new MongoClient(Environment.GetEnvironmentVariable("MONGODB_URI"));
            var database = client.GetDatabase("DiscordBackrooms");
            var collection = database.GetCollection<Session>("sessions");
            var filter = Builders<Session>.Filter.Eq("token", token);
            var result = await collection.Find(filter).FirstOrDefaultAsync();
            return result;
        }
    }
}