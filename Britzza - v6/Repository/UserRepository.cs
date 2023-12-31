﻿using Britzza___v6.Interfaces;
using Britzza___v6.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Britzza___v6.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        public UserRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _users = database.GetCollection<User>("users");
        }

        public void CreateUser(User user)
        {
            user.UserId = ObjectId.GenerateNewId();
            _users.InsertOne(user);
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username) & Builders<User>.Filter.Eq(u => u.Password, password);
            return _users.Find(filter).FirstOrDefault();
        }
    }
}
