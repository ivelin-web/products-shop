namespace App.Models.Users
{
    using App.Models.Interfaces;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User : IUser
    {
        [BsonId]
        public ObjectId Id { get; private set; }

        [BsonElement("email")]
        public string Email { get; private set; }

        [BsonElement("username")]

        public string Username { get; private set; }

        [BsonElement("password")]

        public string Password  { get; private set; }

        public User(string email, string username, string password)
        {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
    }
}
